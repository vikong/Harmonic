using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FolderChecker.Properties;

namespace FolderChecker
{
	public partial class MainForm : Form
	{
		private const String LogPath = @".\Logs";
		private readonly List<FolderInfo> _folderList;
		private List<FolderInfo> FolderList { get { return _folderList; } }

		private BackgroundWorker _saveBackgroundWorker;
		private BackgroundWorker SaveBackgroundWorker
		{
			get
			{
				if (_saveBackgroundWorker == null)
				{
					_saveBackgroundWorker = new BackgroundWorker();
					_saveBackgroundWorker.WorkerReportsProgress = false;
					_saveBackgroundWorker.WorkerSupportsCancellation = false;
					_saveBackgroundWorker.DoWork += save_DoWork;
				}
				return _saveBackgroundWorker;
			}
		}

		public MainForm()
		{
			if (!Directory.Exists(LogPath))
				Directory.CreateDirectory(LogPath);
			String foldersFile = Settings.Default.FoldersListFile;
			if (System.IO.File.Exists(foldersFile))
				_folderList = Serializer.Restore<List<FolderInfo>>(foldersFile);
			else
				_folderList = new List<FolderInfo>();

			InitializeComponent();
			InitFolderGrid();
			InitializeMy();
		}
		private void FolderGridView_DoubleClick(object sender, EventArgs e)
		{
			EditCurrent();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing
				&& this.Auto == true
				&& MessageBox.Show("Прекратить проверку по таймеру и закрыть приложение?", "FolderChecker", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel
			)
			{
				e.Cancel = true;
				return;
			}
			SaveFolders();
			Settings.Default.FrmLocation = new Point(this.Left, this.Top);
			Settings.Default.Save();
			Application.Exit();
		}

		private void SaveTimer_Tick(object sender, EventArgs e)
		{
			SaveBackgroundWorker.RunWorkerAsync();
		}

		private void CheckButton_Click(object sender, EventArgs e)
		{
			CheckCurrent();
		}

		private void FolderGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
		{
			if (e.RowIndex < 0) return;
			switch (FolderGridView.Columns[e.ColumnIndex].Name)
			{
				case "State":
					String msg = (String)FolderGridView.Rows[e.RowIndex].Cells["Message"].Value;
					FolderGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = msg;

					switch ((FolderInfo.State)FolderGridView.Rows[e.RowIndex].Cells["Status"].Value)
					{
						case FolderInfo.State.Ok:
							e.Value = Resources.check_green_16;
							break;

						case FolderInfo.State.Checking:
							e.Value = Resources.timer_16;
							break;

						case FolderInfo.State.Error:
							e.Value = Resources.error_16;
							break;

						case FolderInfo.State.Warning:
							e.Value = Resources.warning_16;
							break;

						default:
							e.Value = Resources.empty_16;
							break;

					}
					break;
			}

		}

		private void CheckAllButton_Click(object sender, EventArgs e)
		{
			CheckAll();
		}

		private void CheckCurrent()
		{
			FolderInfo fld = FolderBindingSource.Current as FolderInfo;
			if (fld == null)
			{
				MessageBox.Show("Не выбрано расположения.");
				return;
			}
			fld.Status = FolderInfo.State.Checking;
			FolderBindingSource.ResetCurrentItem();
			FolderGridView.Refresh();
			CheckFolder(fld, 1024 * 10);
			FolderBindingSource.ResetCurrentItem();
			FolderGridView.Refresh();

		}
		private void CheckAll()
		{
			if (FoldrCheckBackgroundWorker.IsBusy)
				return;
			Manual = true;
			FoldrCheckBackgroundWorker.RunWorkerAsync();
		}

		private void FoldrCheckBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			LogClear();
			try
			{
				Parallel.ForEach(FolderList.Where(t => t.Off == false), (fld) =>
				{
					CheckFolder(fld, Settings.Default.TestFileSize);
					LogFolder(fld);
					FoldrCheckBackgroundWorker.ReportProgress(0);
				});

			}
			catch (AggregateException ex)
			{
				String errorFile = LogPath + @"\Error " + DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + ".xml";
				ErrorHandler.Log(ex.InnerExceptions, errorFile);
				throw new Exception("При выполнении проверки возникли непредвиденные ошибки. Подробности в файле " + errorFile);
			}

		}

		private void FoldrCheckBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (Visible)
				FolderGridView.Refresh();
		}

		private void FoldrCheckBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (Visible)
				FolderGridView.Refresh();
			if (Manual)
				if (e.Error == null)
					MessageBox.Show("Проверка завершена.", "CheckFolder", MessageBoxButtons.OK, MessageBoxIcon.Information);
				else
					MessageBox.Show("При проверке возникли ошибки.\r\n" + e.Error.Message, "CheckFolder", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			else
			{
				if (e.Error == null && !Error)
				{
					notifyIcon.Icon = Resources.folder_set;
					return;
				}

				notifyIcon.Icon = Resources.folder_warning_16ico;
				String errorMessage = "При проверке возникли ошибки:\r\n";
				if (e.Error != null)
				{
					LogSave("Программные ошибки.");
					errorMessage += "Программные ошибки.\r\n";
				}
				if (Error)
				{
					String log = LogText;
					LogSave(log);
					errorMessage += log;
				}

				if (Settings.Default.EmlSend)
					SendWarn(errorMessage);

				notifyIcon.ShowBalloonTip(15);

			}
		}

		private void checkTimer_Tick(object sender, EventArgs e)
		{
			if (FoldrCheckBackgroundWorker.IsBusy)
				return;
			Manual = false;
			FoldrCheckBackgroundWorker.RunWorkerAsync();

		}

		private void eMailToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var frm = new EMailSettingForm();
			frm.ShowDialog();
		}

		private void paramsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var frm = new SettingForm();
			frm.ShowDialog();
			checkTimer.Interval = Settings.Default.CheckInterval * 60 * 1000;
		}

		private void offButton_Click(object sender, EventArgs e)
		{
			var currentItem = FolderBindingSource.Current as FolderInfo;
			if (currentItem == null)
				return;
			currentItem.Off = (!currentItem.Off);
			FolderListChanged();
			FolderBindingSource.ResetCurrentItem();
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			RemoveCurrent();
		}

		private void FolderGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
		{
			if ((Boolean)FolderGridView.Rows[e.RowIndex].Cells["Off"].Value == false)
				FolderGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
			else
				FolderGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkGray;
		}

		private void FolderGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				FolderGridView.CurrentCell = FolderGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
				FolderGridView.Rows[e.RowIndex].Selected = true;
				FolderGridView.Focus();
			}
		}

		private void offToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SwitchCurrent(true);
		}

		private void onToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SwitchCurrent(false);
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RemoveCurrent();
		}

		private void appendToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddItems();
		}

		private void editToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EditCurrent();
		}

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

		private void autoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem m = (ToolStripMenuItem)sender;
			Auto = m.Checked;
			if (m.Checked)
				m.Image = Resources.check_green_16;
			else
				m.Image = null;
		}

		private void SettingsButton_Click(object sender, EventArgs e)
		{

			if (e.GetType() == typeof(MouseEventArgs))
			{
				var evnt = e as MouseEventArgs;
				mainContextMenuStrip.Show(sender as Control, evnt.Location);
			}

		}

		private void allToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			CheckAll();
		}

		private void currentToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			CheckCurrent();
		}


	}
}

