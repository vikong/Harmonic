#if DEBUG
#define _DELAY
#endif
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Harmonic.Subtitles
{
    public class FolderGridInfo
    {
        public enum State
        {
            None,
            Ok,
            Checking,
            Warning,
            Error
        };
		
        #region prop

		public FolderInfo FolderInfo { get; set; }

		/// <summary>
		/// Для lock
		/// </summary>
		public readonly object ClearLock = new object();

		public Boolean NowClearing { get; set; }

		public DateTime? LastCheck { get; set; }

		/// <summary>
		/// Журнал
		/// </summary>
		public String Message { get; protected set; }

		public State Status { get; set; } = State.None;

		/// <summary>
		/// Сообщение о прогрессе
		/// </summary>
		public String Progress { get; set; }

		public Boolean Off
		{
			get { return FolderInfo.Off; }
			set { FolderInfo.Off = value; }
		}

		private static readonly Char[] _splitSymbols = new Char[] { ',', ';' };
        
        #endregion        
        
        public FolderGridInfo() 
            : this(new FolderInfo())
        { }

        public FolderGridInfo(FolderInfo folderInfo)
        {
            FolderInfo = folderInfo;
        }

        public void RaiseError(String message = "", State level = State.Error)
        {
            Progress = String.Format(Messages.Finished, DateTime.Now);
            if (!String.IsNullOrEmpty(message))
                SetMessage(message);
            Status = level;
        }

        public void Ok(String message = "")
        {
            Progress = String.Format(Messages.Finished, DateTime.Now);
            if (!String.IsNullOrEmpty(message))
                SetMessage(message);
            Status = State.Ok;
        }

        public void SetMessage(String message)
        {
            Message = $"{message} \r\n ( {DateTime.Now} )\r\n";
        }

        public void AddMessage(String message)
        {
            Message = $"{message} \r\n({DateTime.Now})\r\n\r\n{Message}";
        }

        public String GetSubtitleTemplate(String defaultSubtitles)
        {
            return String.IsNullOrWhiteSpace(FolderInfo.TemplateFile) ? defaultSubtitles : FolderInfo.TemplateFile;
        }

        public String[] GetSuffixes(String defaultSuffixes)
        {
            return (String.IsNullOrWhiteSpace(FolderInfo.Suffixes) ? defaultSuffixes : FolderInfo.Suffixes)
                .Split(_splitSymbols);
        }

        public String[] GetSourceExtensions(IEnumerable<String> defaultExtensions)
        {
            return defaultExtensions.ToArray();
        }

        private Task SimulateDelay(CancellationToken cancellation)
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(100);
                    if (cancellation.IsCancellationRequested)
                    {
                        throw new TaskCanceledException();
                    }
                }
            });

        }

        /// <summary>
        /// Проверяет наличие субтитров для папки
        /// </summary>
        /// <param name="defaultSourceExtensions"></param>
        /// <param name="defaultSuffixes"></param>
        /// <param name="subtitlesExtension"></param>
        /// <param name="subtitlesTemplate"></param>
        /// <param name="logger"></param>
        /// <param name="progress"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        internal async Task CheckSubtitlesAsync(IEnumerable<String> defaultSourceExtensions, String defaultSuffixes, String subtitlesExtension, String subtitlesTemplate, ILogger logger, IProgress<ProgressState> progress, CancellationToken cancellation)
        {
            if (Status == FolderGridInfo.State.Checking)
                return;

            lock (ClearLock)
            {
                if (Status == FolderGridInfo.State.Checking)
                    return;
                Status = FolderGridInfo.State.Checking;
            }
            
            // список добавленных файлов субтитров
            List<String> addedSubtitles = new List<String>();

            try
            {
                // проверим доступность папок и шаблона субтитров
                Progress = String.Format(Messages.ProgressStage, 1, 4);
                
                progress?.Report(ProgressState.ScanDest);

                string subtitlesTemplateFile = GetSubtitleTemplate(subtitlesTemplate);

                if ((await Task.Run(() => File.Exists(subtitlesTemplateFile))) == false)
                {
                    RaiseError($"{Messages.SubtitlesFileNotFound}: {subtitlesTemplateFile}");
                    progress?.Report(ProgressState.None);
                    return;
                }

                String error =
                    await FolderInfo.ValidateFolderAsync();
                if (error != null)
                {
                    RaiseError(error);
                    progress?.Report(ProgressState.None);
                    return;
                }

                //
                string[] suffixes = GetSuffixes(defaultSuffixes);

                // сканируем папку-источник (FolderInfo.SourceFolder)

                // сформируем функцию для отображения прогресса
                IProgress<int> stageProgress;
                ProgressReport progressReport = new ProgressReport()
                {
                    State = ProgressState.ScanDest,
                    Message = $"{String.Format(Messages.ProgressStage, 1, 4)}, {Messages.ProgressStage1}: ",
                };
                stageProgress = new Progress<int>((filesCnt) =>
                {
                    progressReport.FilesDest = filesCnt;
                    Progress = progressReport.ToString();
                    progress?.Report(ProgressState.ScanDest);
                });

                List<String> srcFiles =
                    await Network.GetFiles(FolderInfo.SourceFolder, stageProgress, cancellation);

                if (cancellation.IsCancellationRequested) 
                { 
                    throw new TaskCanceledException(); 
                }
                progress?.Report(ProgressState.ScanDest);

                // отфильтруем полученные файлы и преобразуем
                var extForCheck = defaultSourceExtensions;
                List<FilePart> source =
                    srcFiles
                    .Where(f => extForCheck.Contains(Path.GetExtension(f)))
                    .Select(s => new FilePart(s))
                    .ToList();


                // сканируем файлы в папке субтитров FolderInfo.TargetFolder

                // сформируем функцию для отображения прогресса
                progressReport.Message = $"{String.Format(Messages.ProgressStage, 2, 4)}, {Messages.ProgressStage2}: ";
                stageProgress = new Progress<int>((x) =>
                {
                    progressReport.FilesTarget = x;
                    Progress = progressReport.ToString();
                    progress?.Report(ProgressState.ScanTarget);
                });
                
                List<String> targetFiles =
                    await Network.GetFiles(FolderInfo.TargetFolder, stageProgress, cancellation);

                if (cancellation.IsCancellationRequested) 
                { 
                    throw new TaskCanceledException(); 
                }

                progress?.Report(ProgressState.ScanDest);
                
                // преобразуем
                var target = new Dictionary<String, FilePart>(targetFiles.Count);
                foreach (var f in targetFiles)
                {
#if _DELAY
                    await SimulateDelay(cancellation);
#endif
                    target.Add(Path.GetFileName(f), new FilePart(f));
                }

                // ищем недостающие субтитры
                foreach (var suffix in suffixes)
                {
                    progressReport.Message = $"{String.Format(Messages.ProgressStage, 3, 4)}, {Messages.ProgressStage3} ({suffix}) ";
                    Progress = progressReport.ToString();
                    // отсутствующие
                    IReadOnlyCollection<FilePart> absent =
                        source.FindAbsent(suffix, subtitlesExtension, target);

                    progressReport.FilesAbsent = absent.Count;
                    Progress = progressReport.ToString();
                    progress?.Report(ProgressState.Check);
                    if (cancellation.IsCancellationRequested) 
                    { 
                        throw new TaskCanceledException(); 
                    }

                    // копируем недостающие
                    progressReport.Message = $"{String.Format(Messages.ProgressStage, 4, 4)}, {Messages.ProgressStage4} ({suffix}) ";

                    stageProgress = new Progress<int>((x) =>
                    {
                        progressReport.FilesAbsent = x;
                        Progress = progressReport.ToString();
                        progress?.Report(ProgressState.Copy);
                    });
                    await CopySubtitlesTemplateAsync(absent, suffix, subtitlesExtension, subtitlesTemplateFile, addedSubtitles, stageProgress, cancellation);
                }

                if (addedSubtitles.Count == 0)
                {
                    Ok(Messages.CheckOk);
                }
                else
                {
                    if (addedSubtitles.Count <= 10)
                    {
                        Ok($"{Messages.CheckAdded}:{Environment.NewLine}{String.Join(Environment.NewLine, addedSubtitles)}");
                    }
                    else
                    {
                        Ok($"{Messages.CheckAdded}:{Environment.NewLine}{addedSubtitles.Count}");
                    }
                }

                progress?.Report(ProgressState.None);
            }
            catch (TaskCanceledException)
            {
                RaiseError(Messages.Canceled, State.Warning);
            }
            catch (Exception ex)
            {
                RaiseError($"{Messages.CheckErrors}\r\n{ex.Message}");
            }
            finally
            {
                if (addedSubtitles.Count > 0)
                {
                    var added = String.Join(Environment.NewLine, addedSubtitles);
                    logger.Log(added);
                }
                Progress = $"Finish {DateTime.Now}";
                lock (ClearLock)
                {
                    if (Status == FolderGridInfo.State.Checking)
                        Status = FolderGridInfo.State.None;
                }
                progress?.Report(ProgressState.None);
            }
        }

        /// <summary>
        /// Копирует шаблон субтитров для указанного списка асинхронно
        /// </summary>
        /// <param name="fileParts">Список файлов, для которых копируется шаблон</param>
        /// <param name="suffix">суффикс языка файла субтитров</param>
        /// <param name="subtitlesExtension">расширение файла субтитров</param>
        /// <param name="subtitleTemplateFile">шаблон файла субтитров</param>
        /// <param name="added">добавленные файлы субтитров</param>
        /// <param name="progress">прогресс</param>
        /// <param name="cancellation">токен отмены</param>
        private Task CopySubtitlesTemplateAsync(
            IEnumerable<FilePart> fileParts, 
            String suffix, 
            String subtitlesExtension, 
            String subtitleTemplateFile, 
            ICollection<String> added, 
            IProgress<Int32> progress, 
            CancellationToken cancellation
            )
        {
            return Task.Run(() =>
            {
                int counter = 0;
                foreach (var fp in fileParts)
                {
                    var subtitle = fp.Name + suffix + "." + subtitlesExtension;
                    File.Copy(subtitleTemplateFile, Path.Combine(FolderInfo.TargetFolder, subtitle), false);

                    added.Add(subtitle);
                    progress?.Report(++counter);
                    Thread.Sleep(50);
                    if (cancellation.IsCancellationRequested) 
                    { 
                        throw new TaskCanceledException(); 
                    }
                }
                return;
            });
        }
    }
}