using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Harmonic.Subtitles
{
	public partial class TestForm : Form
	{
		private readonly List<FolderGridInfo> _folderList;

		private List<FolderGridInfo> FolderList { get { return _folderList; } }

		private FolderGridInfo CurrentFolderInfo { get { return (FolderGridInfo)FolderBindingSource.Current; } }

		public TestForm()
		{
			_folderList = new List<FolderGridInfo>();
			FolderList.Add(new FolderGridInfo(new FolderInfo()
			{
				Name = "Test",
				SourceFolder = @"d:\_pjt\_net\harmonic\TestFolder\mxf1\",
				TargetFolder = @"d:\_pjt\_net\harmonic\TestFolder\stl\stl1\",
				Suffixes = "",
				TemplateFile= @"D:\_pjt\_net\harmonic\TestFolder\stl\empty\_tmpMxf1.stl",
				Off=false
			})) ;

			InitializeComponent();
			InitFolderGrid();
		}

		private CancellationToken cancellationToken;
		private CancellationTokenSource tokenSource=new CancellationTokenSource();

		private async void button1_Click(object sender, EventArgs e)
		{
			//FolderGridView.CurrentRow.Cells["Progress"].Value = ((int)(FolderGridView.CurrentRow.Cells["Progress"].Value??0))+10;
			//_folderList[0].Progress = _folderList[0].Progress + 10;
			//FolderGridView.Refresh();
			var progress = new Progress<ProgressState>((s)=> { 
				textBox1.Text = CurrentFolderInfo.Progress; FolderGridView.Refresh(); 
			});
			//progress.ProgressChanged += progress;
			
			cancellationToken = tokenSource.Token;
			//IList<Task> tasks = new List<Task>();
			//tasks.Add(Check(progress, cancellationToken));
			Task task = CheckAsync(CurrentFolderInfo, progress, cancellationToken);
			//await Check(progress, cancellationToken);
			await task;
		}

		private void fProg(object sender, ProgressReport e)
		{
			string msg;
			switch (e.State)
			{
				case ProgressState.None:
					msg = String.Empty;
					break;
				case ProgressState.ScanDest:
					msg = $"{String.Format(Messages.ProgressStage, 1, 4)} {Messages.ProgressStage1}";
					break;
				case ProgressState.ScanTarget:
					msg = $"{String.Format(Messages.ProgressStage, 2, 4)} {Messages.ProgressStage2}";
					break;
				case ProgressState.Check:
					msg = $"{String.Format(Messages.ProgressStage, 3, 4)} {Messages.ProgressStage3}";
					break;
				case ProgressState.Copy:
					msg = $"{String.Format(Messages.ProgressStage, 4, 4)} {Messages.ProgressStage4}";
					break;
				default:
					msg = String.Empty;
					break;
			}
			textBox1.Text=$"{msg} {e.FilesDest}/{e.FilesTarget}/{e.FilesAbsent}";
			//_folderList[0].Progress = e;
			//FolderGridView.Refresh();
		}

		/*
		private async void CheckFolder(FolderGridInfo folder, String defaultSubtitles, IProgress<FolderGridInfo.State> progress, CancellationToken cancellation)
		{
			//const Int32 timeOut=5*1000;

			if (folder.Status == FolderGridInfo.State.Checking)
				return;

			lock (folder.ClearLock)
			{
				if (folder.Status == FolderGridInfo.State.Checking)
					return;
				folder.Status = FolderGridInfo.State.Checking;
			}

			folder.SetMessage(Messages.CheckNow);
			progress?.Report(FolderGridInfo.State.Checking);
			//!!
			//Thread.Sleep(3000);
			//!!
			FolderInfo fi = folder.FolderInfo;


			if (fi.ValidateFolder(out String err))
			{
				var suffixes = fi.Suffixes.Split(',', ';');

				StringBuilder sb = new StringBuilder();
				bool result;
				String errMsg = String.Empty;
				try
				{
					var scanProgress = new Progress<Int32>();
					scanProgress.ProgressChanged += folderProgress;

					var srcFiles = await Network.GetFiles(fi.SourceFolder, scanProgress, cancellation);

					var targetFiles = Directory.EnumerateFiles(fi.TargetFolder, "*." + ExtSubtitles);

					var subtitlesFile = SubtitlesFor(fi);
					//!!
					//Thread.Sleep(5000);
					//!!

					foreach (var s in suffixes)
					{
						FilePart[] cmp = SubtitleChecker.Compare(srcFiles, ExtSources, targetFiles, s).ToArray();
						if (cmp.Length > 0)
						{
							foreach (var fp in cmp)
							{
								var target = fp.Name + s + "." + ExtSubtitles;
								File.Copy(subtitlesFile, Path.Combine(fi.TargetFolder, target), false);
								sb.AppendLine(target);
							}
						}
					}
					result = true;
				}
				catch (UnauthorizedAccessException ex)
				{
					errMsg = $"{Messages.CheckErrors}\r\n{ex.Message}";
					result = false;
				}
				catch (IOException ex)
				{
					errMsg = $"{Messages.CheckErrors}\r\n{ex.Message}";
					result = false;
				}
				catch (Exception ex)
				{
					errMsg = $"{Messages.CheckErrors}\r\n{ex.Message}";
					result = false;
				}

				string msg;
				if (sb.Length > 0)
				{
					string added = sb.ToString();
					LogFolder(folder, added, true);
					msg = $"{Messages.CheckAdded}:\r\n{added}";
					sb.Clear();
				}
				else
					msg = result == true ? Messages.CheckOk : "!";

				if (result == true)
					folder.Ok(msg);
				else
					folder.RaiseError($"{msg}\r\n{errMsg}");
			}
			else
			{
				folder.RaiseError(err);
			}

			progress?.Invoke();

		}//CheckFolder
		*/

		private async Task Emulate(int val, IProgress<int> progress) 
		{
			progress?.Report(0);
			for (int i = 0; i < val; i++)
			{
				await Task.Run(() => Thread.Sleep(700));
				progress?.Report(i);
			}
		}
		
		private async Task CheckAsync(FolderGridInfo folder, IProgress<ProgressState> progress, CancellationToken cancellation) 
		{

			const int fCnt= 10;
			IProgress<int> prg = new Progress<int>((x) => {
				folder.Progress = $"{String.Format(Messages.ProgressStage, 1, 4)}: {Messages.ProgressStage1} {x}";
				progress?.Report(ProgressState.ScanDest);
				});
			await Emulate(fCnt,prg);
			
			//for (int i = 1; i <= fCnt; i++)
			//{
			//	await Task.Run(()=>Thread.Sleep(700));
			//	if (progress != null)
			//		progress.Report( new ProgressReport(ProgressState.ScanDest, i, 0, 0));
			//	if (cancellation.IsCancellationRequested)
			//		break;
			//}
			//for (int i = 1; i <= fCnt; i++)
			//{
			//	await Task.Run(() => Thread.Sleep(700));
			//	if (progress != null)
			//		progress.Report(new ProgressReport(ProgressState.ScanTarget, fCnt, i, 0));
			//	if (cancellation.IsCancellationRequested)
			//		break;
			//}
			//for (int j = 1; j <= 5; j++)
			//{
			//	await Task.Run(() => Thread.Sleep(700));
			//	if (progress != null)
			//		progress.Report(new ProgressReport(ProgressState.Check, fCnt, fCnt, j));
			//	if (cancellation.IsCancellationRequested)
			//		break;
			//}

			//for (int j = 5; j >= 0; j--)
			//{
			//	await Task.Run(() => Thread.Sleep(700));
			//	if (progress != null)
			//		progress.Report(new ProgressReport(ProgressState.Copy, fCnt, fCnt, j));
			//	if (cancellation.IsCancellationRequested)
			//		break;
			//}
		}

		private void cancel_Click(object sender, EventArgs e)
		{
			tokenSource.Cancel();
		}


		private void fProgress(object sender, Int32 e)
		{
			textBox1.Text = e.ToString();
		}

		private async void button3_Click(object sender, EventArgs e)
		{
			cancellationToken = tokenSource.Token;
			const string path = @"\\ntbkfs\prog\Piramida\Krk2a\pic\borodki";
			var progress = new Progress<int>();
			progress.ProgressChanged += fProgress;
			
			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();
			var ff = await Network.GetFiles(path, progress, cancellationToken);
			stopWatch.Stop();
			
			timeTextBox.Text = stopWatch.Elapsed.TotalSeconds.ToString();
		}
	}
}
