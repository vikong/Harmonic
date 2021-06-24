using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Harmonic.Subtitles.Properties;

namespace Harmonic.Subtitles
{
	partial class MainForm : Form
	{
		#region Properties

		private String _folderListSource;

		private String FolderListSource
		{
			get { return _folderListSource; }
			set { FolderListReload(value); _folderListSource = value; }
		}

		private readonly List<FolderGridInfo> _folderList;

		private List<FolderGridInfo> FolderList => _folderList;

		private FolderGridInfo CurrentFolderInfo => (FolderGridInfo)FolderBindingSource.Current;

		private CultureInfo CurrentCultureInfo { get; set; }

		//private readonly SynchronizationContext synchronizationContext;

		private static readonly Char[] _splitSymbols = new Char[] { ',', ';' };

		/// <summary>
		/// Расширение файла субтитров по умолчанию
		/// </summary>
		String DefaultSubtitlesExtension 
			=> Settings.Default.ExtSubtitles;
		
		/// <summary>
		/// Список расширений исходных файлов по умолчанию
		/// </summary>
		private IEnumerable<String> DefaultSourcesExtensions 
			=> Settings.Default.ExtSource.Split(_splitSymbols).Select(s => "." + s);

		String ErrorFile 
			=> Settings.Default.LogFolder + @"\Error " + DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + ".xml";

		private Boolean Error { get; set; } = false;

		private Boolean _auto;

		/// <summary>
		/// Флаг, сигнализирующий о том, что активирована проверка по таймеру.
		/// </summary>
		private Boolean Auto
		{
			get { return _auto; }
			set
			{
				if (_auto == value)
					return;
				if (value == true)
				{
					checkTimer.Interval = Settings.Default.CheckInterval * 60 * 1000;
					checkTimer.Enabled = true;
					autoPictureBox.Image = Resources.play_green_24;
				}
				else
				{
					checkTimer.Enabled = false;
					autoPictureBox.Image = Resources.pause_24;
				}
				_auto = value;
			}
		}

		private static readonly object _cancellationLocker = new object();
		private CancellationToken CancellationToken { get ; set; }
		private CancellationTokenSource _tokenSource = new CancellationTokenSource();

		private bool _checkingAllInProgress = false;

		/// <summary>
		/// Флаг, сигнализирующий, что идёт проверка всех папок
		/// </summary>
		private bool CheckingAllInProgress
		{
			get { return _checkingAllInProgress; }
			set
			{
				_checkingAllInProgress = value;
				CheckAllButton.Enabled =
					checkToolStripMenuItem1.Enabled =
					modifyToolStripMenuItem1.Enabled =
					deleteToolStripMenuItem1.Enabled =
					SettingsButton.Enabled =
					!value;
			}
		}

		/// <summary>
		/// Флаг, сигнализирующий о том, что запущена проверка в ручном режиме
		/// </summary>
		private Boolean Manual { get; set; }

		#endregion Properties

		public MainForm()
		{
			CurrentCultureInfo = Thread.CurrentThread.CurrentUICulture;
			if (!Directory.Exists(Settings.Default.LogFolder))
				Directory.CreateDirectory(Settings.Default.LogFolder);
			_folderList = new List<FolderGridInfo>();
			//synchronizationContext = SynchronizationContext.Current;
			CancellationToken = _tokenSource.Token;
			InitializeComponent();
			InitFolderGrid();
			CustomInitialize();
		}

		private void CustomInitialize()
		{
#if DEBUG
			button1.Visible = true;
#endif

			if (Settings.Default.FrmLocation.X > 0 && Settings.Default.FrmLocation.Y > 0)
			{
				this.StartPosition = FormStartPosition.Manual;
				Left = Settings.Default.FrmLocation.X;
				Top = Settings.Default.FrmLocation.Y;
			}
			if (Settings.Default.ShowWindow)
				this.Show();
			ShowInTaskbar =
				Visible =
				Settings.Default.ShowWindow;

			AutoToolStripMenuItem.Checked =
				Auto =
				Settings.Default.AutoCheck;

			AutoToolStripMenuItem.Image = Auto ? Resources.check_green_16 : null;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			FolderListSource = Settings.Default.FoldersListFile;
		}

		private void FolderListReload(String foldersFile)
		{
			FolderBindingSource.SuspendBinding();
			_folderList.Clear();

			try
			{
				if (!File.Exists(foldersFile))
					return;

				_folderList.AddRange(
					Serializer.Restore<List<FolderInfo>>(foldersFile)
					.Select(fi => new FolderGridInfo(fi))
				);
			}
			catch (Exception)
			{
				throw new Exception("!");
			}
			finally
			{
				FolderBindingSource.ResumeBinding();
				FolderBindingSource.ResetBindings(false);
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				if (this.Auto == true
					&& MessageBox.Show(Messages.AppExit, Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel
				)
				{
					e.Cancel = true;
					return;
				}
				Cancel();
				Application.Exit();
			}
			else
			{
				try
				{
					Cancel();
					SaveFolders();
					Settings.Default.FrmLocation = this.Location;
					Settings.Default.Save();
				}
				catch (Exception)
				{ }
			}
		}

		private async void CheckButton_Click(object sender, EventArgs e)
		{
			await CheckCurrentAsync();
		}

		private async void CheckAllButton_Click(object sender, EventArgs e)
			=> await CheckAllAsync(true);


		private async void checkTimer_Tick(object sender, EventArgs e)
			=> await CheckAllAsync(false);

		private void paramsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var frm = new SettingForm())
				frm.ShowDialog();
			checkTimer.Interval = Settings.Default.CheckInterval * 60 * 1000;
		}

		private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FolderBindingSource.DeleteCurrent();
			await SaveFolderAsync();
		}

		private void appendToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddItems();
		}

		private void editToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EditCurrent();
		}

		#region Resizing

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (WindowState == FormWindowState.Minimized)
			{
				ShowInTaskbar = false;
				Visible = false;
			}
		}

		private void Expand()
		{
			if (!Visible)
			{
				Visible = true;
				ShowInTaskbar = true;
			}
			if (WindowState == FormWindowState.Minimized)
				WindowState = FormWindowState.Normal;
			FolderBindingSource.ResetBindings(false);
			FolderGridView.Refresh();
		}

		private void notifyIcon_DoubleClick(object sender, EventArgs e)
		{
			Expand();
		}

		private void notifyIcon_Click(object sender, EventArgs e)
		{
			Expand();
		}

		#endregion Resizing

		private void autoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem m = (ToolStripMenuItem)sender;
			Auto = m.Checked;
			if (m.Checked)
				m.Image = Resources.check_green_16;
			else
				m.Image = null;
			Settings.Default.AutoCheck = m.Checked;
			Settings.Default.Save();
		}

		private void SettingsButton_Click(object sender, EventArgs e)
		{
			bool auto = Auto;
			Auto = false;
			if (_checkingAllInProgress)
			{
				Auto = auto;
				return;
			}

			DialogResult result;
			using (var frm = new SettingForm())
				result = frm.ShowDialog();
			Auto = auto;
			if (result == DialogResult.Cancel)
				return;

			string folderListFile = Settings.Default.FoldersListFile;
			if (!String.Equals(folderListFile, FolderListSource, StringComparison.OrdinalIgnoreCase))
			{
				FolderListSource = folderListFile;
			}

			if (MessageBox.Show(Messages.AppChangeSettings, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
				Application.Restart();
		}

		private async void allToolStripMenuItem1_Click(object sender, EventArgs e)
			=> await CheckAllAsync(true);

		private async void currentToolStripMenuItem1_Click(object sender, EventArgs e)
			=> await CheckCurrentAsync();

		private async void ClearSubtitles_Click(object sender, EventArgs e)
		{
			FolderGridInfo folder = CurrentFolderInfo;
			if (folder == null)
			{
				MessageBox.Show(Messages.CheckNoSelected, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			Task clearTask = ClearSubtitlesAsync(folder);
			FolderBindingSource.ResetCurrentItem();
			FolderGridView.Refresh();
			await clearTask;
			FolderBindingSource.ResetCurrentItem();
			FolderGridView.Refresh();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//Cancel();
			//await CheckAllAsync(true);

			//var testForm = new TestForm();
			//testForm.Show();

			//helpProvider
			//FolderInfo newFolder = new FolderInfo
			//{
			//	Name = "Temp" + DateTime.Now.ToLongTimeString(),
			//	SourceFolder = @"d:\temp\",
			//	TargetFolder = @"s:\temp\",
			//	TemplateFile = @"s:\temp\t.stl"
			//};

			//FolderList.Add(new FolderGridInfo(newFolder));
			//FolderBindingSource.ResetBindings(false);

			//CultureInfo cultureInfo = CurrentCultureInfo.Name=="en-EN"? new CultureInfo("ru-RU") : new CultureInfo("en-EN");
			//this.ChangeLanguage(cultureInfo);
			//button1.Show();
			//this.Refresh();

			//CurrentCultureInfo = cultureInfo;
		}

		private async void switchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SwitchCurrent();
			FolderGridView.Refresh();
			await SaveFolderAsync();
		}

		private void FolderMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			var fi = CurrentFolderInfo;
			if (fi == null)
				return;
			switchToolStripMenuItem.Text = fi.Off ? Messages.EditSwitchOn : Messages.EditSwitchOff;
		}

		private void TimerMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			byTimerToolStripMenuItem.Checked = this.Auto;
			manuallyToolStripMenuItem.Checked = !this.Auto;
		}

		private async Task SetCheckByTimer(Boolean state)
		{
			Settings.Default.AutoCheck = Auto = state;
			await Task.Run(() => Settings.Default.Save());
		}

		private async void TimerMenuStrip_Click(object sender, EventArgs e)
			=> await SetCheckByTimer(true);

		private async void manuallyToolStripMenuItem_Click(object sender, EventArgs e)
			=> await SetCheckByTimer(false);

		private void addedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var fi = CurrentFolderInfo;
			if (fi == null)
				return;
			var file = Path.GetFullPath(LogFor(fi, true));
			if (!File.Exists(file))
			{
				MessageBox.Show(Messages.CheckNoLog, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			System.Diagnostics.Process.Start(file);
		}

		private void clearedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var fi = CurrentFolderInfo;
			if (fi == null)
				return;
			var file = Path.GetFullPath(LogFor(fi, false));
			if (!File.Exists(file))
			{
				MessageBox.Show(Messages.CheckNoLog, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			System.Diagnostics.Process.Start(file);
		}


		#region Edit

		private void AddItems()
		{
			using (var frm = new EditFolderForm())
			{
				frm.EditConfirm += ItemAdded;
				frm.ShowDialog();
			}
		}

		private void EditItem(FolderGridInfo folder)
		{
			using (var editForm = new EditFolderForm(folder.FolderInfo))
			{
				editForm.EditConfirm += ItemEdited;
				editForm.ShowDialog();
			}
		}

		private async void ItemAdded(object sender, EditFolderForm.EditArgs e)
		{
			// проверим на дублирование имени хоста
			if (FolderList.Any(t => String.Equals(t.FolderInfo.Name, e.FolderInfo.Name, StringComparison.OrdinalIgnoreCase)))
			{
				e.Confirm = false;
				e.Message = Messages.EditHostExists;
				return;
			}
			// проверим на дублирование папок
			if (FolderList.Any(t =>
					Path.Equals(t.FolderInfo.SourceFolder, e.FolderInfo.SourceFolder)
					&& Path.Equals(t.FolderInfo.TargetFolder, e.FolderInfo.TargetFolder)
				))
			{
				e.Confirm = false;
				e.Message = Messages.EditFolderExists;
				return;
			}

			FolderBindingSource.Position = FolderBindingSource.Add(new FolderGridInfo(e.FolderInfo));
			e.Confirm = true;

			await SaveFolderAsync();
		}

		private async void ItemEdited(object sender, EditFolderForm.EditArgs e)
		{
			if (FolderList.Any(t =>
					!String.Equals(t.FolderInfo.Name, e.CurrentName, StringComparison.OrdinalIgnoreCase)
					&& String.Equals(t.FolderInfo.Name, e.FolderInfo.Name, StringComparison.OrdinalIgnoreCase))
				)
			{
				e.Confirm = false;
				e.Message = Messages.EditHostExists;
				return;
			}
			var currentFolder = ((FolderGridInfo)FolderBindingSource.Current).FolderInfo;

			currentFolder.CopyProperties(e.FolderInfo);

			e.Confirm = true;
			FolderBindingSource.ResetCurrentItem();
			FolderGridView.Refresh();

			await SaveFolderAsync();
		}

		private void EditCurrent()
		{
			if (FolderBindingSource.Current == null)
				return;
			EditItem((FolderGridInfo)FolderBindingSource.Current);
		}

		private void SwitchCurrent()
		{
			if (FolderBindingSource.Current == null)
				return;
			FolderGridInfo fi = (FolderGridInfo)FolderBindingSource.Current;
			fi.FolderInfo.Off = !fi.FolderInfo.Off;
			FolderBindingSource.ResetCurrentItem();
		}

		private async Task SaveFolderAsync()
		{
			await Task.Run(() => SaveFolders());
		}

		private void SaveFolders()
		{
			Serializer.Save(Settings.Default.FoldersListFile, FolderList.Select(f => f.FolderInfo).ToList());
		}

		#endregion Edit

		#region Actions
		private String LogFor(FolderGridInfo folder, Boolean add)
		{
			return Path.Combine(Settings.Default.LogFolder, add ? folder.FolderInfo.LogFileAdded : folder.FolderInfo.LogFileCleared);
		}


		private Task ClearSubtitlesAsync(FolderGridInfo folder)
		{
			if (folder.NowClearing)
				return Task.FromResult(false);

			lock (folder.ClearLock)
			{
				if (folder.NowClearing)
					return Task.FromResult(false);
				folder.NowClearing = true;
			}

			return Task.Run(() => 
			{ 
				ClearSubtitles(folder); 
				folder.NowClearing = false; 
			});
		}

		private void ClearSubtitles(FolderGridInfo folder)
		{
			var fi = folder.FolderInfo;
			var sourceFiles = Directory.EnumerateFiles(fi.SourceFolder)
				.Where(f => DefaultSourcesExtensions.Contains(Path.GetExtension(f)))
				.Select(f => Path.GetFileNameWithoutExtension(f))
				.ToArray();
			var targetFiles = Directory.EnumerateFiles(fi.TargetFolder, "*." + DefaultSubtitlesExtension)
				.Select(f => Path.GetFileNameWithoutExtension(f))
				.ToArray();
			var suffixes = (!String.IsNullOrEmpty(fi.Suffixes) ?
				fi.Suffixes :
				Settings.Default.Suffix)
				.Split(_splitSymbols);
			var unrelFiles = SubtitleChecker.GetUnrelated(sourceFiles, targetFiles, suffixes)
				.ToList();

			if (!unrelFiles.Any())
				return;

			var arc = Path.Combine(fi.TargetFolder, "Arc" + DateTime.Now.ToString("yyyy-MM-dd HH-mm") + ".zip");
			File.Delete(arc);
			SubtitleChecker.ZipFiles(fi.TargetFolder, unrelFiles, "." + DefaultSubtitlesExtension, arc);
			StringBuilder sb = new StringBuilder();
			foreach (String f in unrelFiles)
			{
				String fileName = f + "." + DefaultSubtitlesExtension;
				sb.AppendLine(fileName);
				File.Delete(Path.Combine(fi.TargetFolder, fileName));
			}
			LogFolder(folder, sb.ToString(), false);
		}

		private string GetSubtitleTemplate(FolderInfo fi) =>
			String.IsNullOrWhiteSpace(fi.TemplateFile) ?
						Settings.Default.SubtitlesFile :
						fi.TemplateFile;

		private String[] GetSuffixes(FolderInfo fi) =>
			(String.IsNullOrWhiteSpace(fi.Suffixes) ?
						Settings.Default.Suffix :
						fi.Suffixes).Split(_splitSymbols);

		//private async Task Emulate(int val, IProgress<int> progress)
		//{
		//	progress?.Report(0);
		//	for (int i = 0; i < val; i++)
		//	{
		//		await Task.Run(() => Thread.Sleep(700));
		//		progress?.Report(i);
		//	}
		//}


		/// <summary>
		/// Отображение прогресса проверки
		/// </summary>
		/// <param name="progressState">состояние</param>
		private void OnProgressChanged(ProgressState progressState)
		{
			if (Visible)
			{
				FolderGridView.Refresh();
			}
		}

		/// <summary>
		/// Запуск проверки для текущего назначения
		/// </summary>
		private async Task CheckCurrentAsync()
		{
			FolderGridInfo currentFolderInfo = CurrentFolderInfo;
			if (currentFolderInfo == null)
			{
				MessageBox.Show(Messages.CheckNoSelected, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			
			OnCheckStarted();
			ILogger logger = new FileLogger(LogFor(currentFolderInfo, true));
			IProgress<ProgressState> progress = new Progress<ProgressState>(OnProgressChanged);
			Task checkTask = currentFolderInfo.CheckSubtitlesAsync(
				DefaultSourcesExtensions, 
				Settings.Default.Suffix, 
				DefaultSubtitlesExtension, 
				Settings.Default.SubtitlesFile, 
				logger, 
				progress, 
				CancellationToken);
			
			await checkTask;
			
			OnCheckFinished();
		}

		/// <summary>
		/// Проверяет все активные назначения
		/// </summary>
		/// <param name="manual">Признак ручного запуска</param>
		private async Task CheckAllAsync(bool manual)
		{
			if (CheckingAllInProgress)
				return;

			CheckingAllInProgress = true;
			OnCheckStarted();
			Manual = manual;
			Error = false;
			toolStripStatusLabel1.Text = Messages.CheckNow;

			// список для проверки
			var folderList = FolderList.Where(f => !f.Off);

			IProgress<ProgressState> progress = new Progress<ProgressState>(OnProgressChanged);
			// формируем задачи
			var ext = DefaultSourcesExtensions;
			List<Task> tasks = new List<Task>(folderList.Count());
			foreach (var f in folderList)
			{
				tasks.Add(f.CheckSubtitlesAsync(
					ext,
					Settings.Default.Suffix,
					DefaultSubtitlesExtension,
					Settings.Default.SubtitlesFile,
					new FileLogger(LogFor(f, true)),
					progress,
					CancellationToken));
			}

			bool result = false;
			String userMessage;

			Task checkAllTask = Task.WhenAll(tasks);
			try
			{
				await checkAllTask;
				result = true;
			}
			catch (Exception e)
			{
				result = false;
				userMessage = Messages.CheckUnhandledError;
				ErrorHandler.Log(e, ErrorFile);
				//LogSave("Программные ошибки.");
			}

			if (checkAllTask.IsFaulted)
			{
				result = false;
				userMessage = Messages.CheckErrors;
			}
			else
			{
				if (folderList.Any(f => f.Status == FolderGridInfo.State.Error))
				{
					result = false;
					userMessage = Messages.CheckErrors;
				}
				else
				{
					result = true;
					userMessage = Messages.CheckCompleted;
				}
			}
			
			toolStripStatusLabel1.Text = $"{userMessage} ({DateTime.Now})";

			OnProgressChanged(ProgressState.None);

			CheckingAllInProgress = false;
			
			// сообщение для пользователя
			if (Manual)
			{
				if (result == false)
				{
					MessageBox.Show(userMessage, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else
			{
				if (result == true)
				{
					notifyIcon.Icon = Resources.folder_set;
					return;
				}

				notifyIcon.Icon = Resources.folder_warning_16ico;
				notifyIcon.ShowBalloonTip(15);
			}

			OnCheckFinished();
		}

		private void Cancel()
		{
			lock (_cancellationLocker)
			{
				if (_tokenSource.IsCancellationRequested)
				{
					return;
				}
				_tokenSource.Cancel();
			}
		}

		private void OnCheckStarted()
		{
			this.CancelButton.Visible = true;
		}

		private void OnCheckFinished()
		{
			lock (_cancellationLocker)
			{
				if (!FolderList.Any(f => f.Status == FolderGridInfo.State.Checking))
				{
					this.CancelButton.Visible = false;
					if (_tokenSource.IsCancellationRequested)
					{
						_tokenSource = new CancellationTokenSource();
						CancellationToken = _tokenSource.Token;
					}
				}
			}
		}

		private void LogFolder(FolderGridInfo folder, String message, Boolean add)
		{
			File.AppendAllText(LogFor(folder, add),
				$">> {DateTime.Now}\r\n{message}\r\n\r\n");
		}

		private void LogSave(String message)
		{
			//const String line="---------------------------------------------------------------------------------------------------------------------\r\n";
			//File.AppendAllText(Settings.Default.LogFile, line+DateTime.Now.ToString()+"\r\n"+line + message+"\r\n\r\n", Encoding.Default);
		}

		//private void SendWarn(String messageBody)
		//{
		//var set=Properties.Settings.Default;

		//MailMessage mail = new MailMessage(set.EmlFrom, set.EmlTo);
		//mail.BodyEncoding=mail.SubjectEncoding=Encoding.UTF8;
		//mail.Subject=set.EmlSubject;
		//mail.IsBodyHtml=false;
		//mail.Body = messageBody;

		//smtpClient.Host=set.EmlHost;
		//smtpClient.Port=set.EmlPort;
		//smtpClient.EnableSsl=set.EmlSsl;
		//smtpClient.UseDefaultCredentials = set.EmlUseCurUser;
		//if (!String.IsNullOrWhiteSpace(set.EmlLogin))
		//	smtpClient.Credentials = new System.Net.NetworkCredential(set.EmlLogin, set.EmlPass);

		//smtpClient.SendAsync(mail, "warning message");
		//}

		//private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
		//{
		//if (e.Error==null)
		//	LogSave("Отправлено сообщение "+Settings.Default.EmlTo);
		//else
		//	LogSave("Не удалось отправить сообщение по электронной почте.\r\n"+e.Error.Message+(e.Error.InnerException==null?String.Empty:"\r\n"+e.Error.InnerException.Message));
		//}

		#endregion Actions

		private void MainForm_HelpRequested(object sender, HelpEventArgs hlpevent)
		{
			var helpFile = Path.Combine(Application.StartupPath, Application.CurrentCulture.TwoLetterISOLanguageName, "SubtitlesChecker.chm");
			if (File.Exists(helpFile))
				Help.ShowHelp(this, @"file://" + helpFile, HelpNavigator.KeywordIndex, helpLabel.Text);
			hlpevent.Handled = true;
		}

		private void cancelCurrentOperationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Cancel();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			Cancel();
		}
	}
}