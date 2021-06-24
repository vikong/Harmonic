using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FolderObserver.Properties;
using Harmonic;

namespace FolderObserver
{
	public partial class ObserverForm : Form
	{
		private AutoResetEvent _resetEvent = new AutoResetEvent(false);

		private class CheckResult
		{
			public String Message { get; private set;}
			public Boolean Found { get; private set;}
			public String File { get; private set; }

			public CheckResult(String message, Boolean found, String file=null)
			{
				Message=message;
				Found=found;
				File=file;
			}
		}
		private class Result
		{
			public enum MessageType { Normal, Balloon, PopUp };
			public String Message { get; private set; }
			public MessageType Popup { get; private set; }
			public Result(String message, MessageType popup=MessageType.Normal)
			{
				Message=message;
				Popup=popup;
			}
		}
		public ObserverForm()
		{
			InitializeComponent();
			InitializeMy();
			RestoreSettings();
			ConditionLoad();
			if ((Conditions==null || Conditions.Empty) && !Visible)
				PopupMsg("Conditions not defined!", Color.Red);
			else
				if (checkTimer.Enabled)
					notifyIcon.ShowBalloonTip(5000, Application.ProductName, "Observing "+folderTextBox.Text.Trim(), ToolTipIcon.Info);
				else
					notifyIcon.ShowBalloonTip(5000, Application.ProductName, "Automatic check disabled.", ToolTipIcon.Warning);
		}


		private void ObserverForm_Load(object sender, EventArgs e)
		{
		}

		public void ObserverForm_Message(object sender, EventArgs e)
		{
			Expand();
		}

		private void SettingsButton_Click(object sender, EventArgs e)
		{
			DoUserSettings();
		}

		private void checkBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			var worker=(BackgroundWorker)sender;

			if (Conditions==null || Conditions.Empty)
			{
				e.Result=new Result("Undefined conditions!", Result.MessageType.PopUp);
				return;
			}

			IEnumerable<FilePosInfo> changed=null;
			ObservedFolder checkingFolder=new ObservedFolder(folderTextBox.Text);
			try
			{
				if (CheckAnew==false && ((Boolean)e.Argument)==false)
				{
					checkingFolder.LoadCheckInfo(checkedFileInfo);
					checkingFolder.Compare();
				}
				else
					checkingFolder.Set();
				changed=checkingFolder.GetChanged();
			}
			catch (IOException ex)
			{
				e.Result= new Result("Couldn't read folder:\r\n"+ex.Message, Result.MessageType.Balloon);
				return;
			}
			catch (Exception ex)
			{
				e.Result=new Result("Error:\r\n"+ex.Message, Result.MessageType.Balloon); 
				return;
			}
			
			CheckAnew=false;
			if (changed.Count()==0)
			{
				checkingFolder.SaveCheckInfo(checkedFileInfo);
				e.Result=new Result("No new rows detected.");
				return;
			}

			if (worker.CancellationPending==true)
			{
				e.Cancel=true;
				return;
			}
			_resetEvent.Reset();

			StringBuilder inFileSb=new StringBuilder();
			StringBuilder totalSb=new StringBuilder("Found new matches in\r\n");
			Boolean foundInFile=false, totalFound=false;
			EntranceChecker checker=new EntranceChecker(Conditions);

			foreach (var f in changed)
			{
				//Int64 total=changed.Sum(t => (t.Pos<=t.FLen? t.FLen-t.Pos: t.FLen));
				foundInFile=false;
				Encoding enc;
				using (Stream stream=Infrastructure.OpenRead(f.File, out enc))
				{
					Int64 curPos=f.Pos;
					if (curPos>f.FLen) //Размер файла уменьшился? Тогда нужно проверять с начала
						curPos=0;
					var matches = checker.SearchBackground(stream, ref curPos, worker);
					if (matches.Count>0)
					{
						totalFound=foundInFile=true;
						totalSb.AppendFormat("  >> {0}", Path.GetFileName(f.File)); totalSb.AppendLine();
						matches.ForEach(match => { inFileSb.AppendLine(match); });
					}
					f.Pos=curPos;
				}
				checkingFolder.SaveCheckInfo(checkedFileInfo);
				worker.ReportProgress(0, new CheckResult(inFileSb.ToString(), foundInFile, f.File));
				inFileSb.Clear();
				if (worker.CancellationPending==true)
				{
					totalSb.AppendLine("Current search canceled.");
					worker.ReportProgress(100, new CheckResult(totalSb.ToString(), false));
					e.Cancel=true;
					break;
				}
			}
			if (totalFound)
				e.Result=new Result(totalSb.ToString());
			else
				e.Result=new Result("No new matches found.");
			
			_resetEvent.Set();
		}

		private void checkBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			CheckResult res=e.UserState as CheckResult;
			//progressBar.PerformStep();
			if (res.Found)
			{
				PopupMsg(res.Message, res.File, Conditions.Keywords);
				return;
			}
			if (!String.IsNullOrWhiteSpace(res.Message))
			{
				AddMsg(res.Message, res.Found);
				return;
			}

		}

		private void checkBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Cancelled == true)
			{
				AddMsg("Search is canceled by user");
			}
			else if (e.Error != null)
				AddMsg("An error has occurred. Please send error log to developer.");
			else if (e.Result!=null)
			{
				var res=e.Result as Result;
				switch (res.Popup)
				{
					case Result.MessageType.Normal:
						AddMsg(res.Message);
						break;
					case Result.MessageType.PopUp:
						PopupMsg(res.Message,Color.Red);
						break;
					case Result.MessageType.Balloon:
						AddMsg(res.Message, true);
						break;
					default:
						AddMsg(res.Message);
						break;
				}
			}

			progressBar.Visible=false;
			checkNowButton.Visible=true;
			stopButton.Visible=false;
			SettingsButton.Enabled=editContButton.Enabled=true;

			GC.Collect();
		}

		private void editContButton_Click(object sender, EventArgs e)
		{
			if (Conditions==null)
				Conditions=new ComplexLex();

			using (var frm=new ConditionEditForm(Conditions))
			{
				var scr=Screen.GetWorkingArea(sender as Control);
				if (Cursor.Position.X+frm.Width<(scr.Width+scr.Left))
					frm.Left=Cursor.Position.X;
				else
					frm.Left=(scr.Width+scr.Left)-frm.Width;

				if (Cursor.Position.Y+frm.Height<(scr.Height+scr.Top))
					frm.Top=Cursor.Position.Y;
				else
					frm.Top=(scr.Height+scr.Top)-frm.Height;

				
				if (frm.ShowDialog()==DialogResult.Cancel)
					return;
			}

			var newCond=Conditions.ToString();
			if (conditionTextBox.Text==newCond)
				return;

			AddMsg(String.Format("Condition has been changed to: {0}",newCond));
			ConditionSave();

			if (!CheckAnew)
				CheckAnew = (
					MessageBox.Show("You changed the checking condition.\r\nDo you want to recheck all files in the observed folder?\r\n'No' button means that only NEW matches will be detect.", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
					==DialogResult.Yes
				);

			conditionTextBox.Text=newCond;

		}

		private void checkTimer_Tick(object sender, EventArgs e)
		{
			StartCheck();
		}

		private void ObserverForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason==CloseReason.UserClosing)
			{
				if (checkBackgroundWorker.IsBusy)
				{
					MessageBox.Show("Checking is in progress.\r\nStop current checking before close application.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					e.Cancel=true;
					return;
				}

				if (
					this.checkOnTimer==true 
					&& MessageBox.Show("Do you want to stop automatic check and close application?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
						==DialogResult.Cancel
				)
				{
					e.Cancel=true;
					return;
				}
			}
			Settings.Default.FrmLocation = new Point(this.Left, this.Top);
			Settings.Default.Save();
			Application.Exit();
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

		private void notifyIcon_Click(object sender, EventArgs e)
		{
			Expand();
		}

		private void notifyIcon_DoubleClick(object sender, EventArgs e)
		{
			Expand();
		}

		private void checkNowButton_Click(object sender, EventArgs e)
		{
			StartCheck();
		}

		private void autoPictureBox_Click(object sender, EventArgs e)
		{
			if (checkOnTimer
				&& MessageBox.Show("Do you want to switch off automatic check?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.Cancel
			)
				return;
			SetCheckOnTimer(!checkOnTimer);
		}

		private void autoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem m=(ToolStripMenuItem)sender;
			SetCheckOnTimer(m.Checked);
		}

		private void checkAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StartCheck(true);
		}

		private void resetForFutureCheckToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CheckAnew=true;
			AddMsg("Start position has been reset.");
		}

		private void stopButton_Click(object sender, EventArgs e)
		{
			if (checkBackgroundWorker.IsBusy)
				checkBackgroundWorker.CancelAsync();
		}


	}
}
