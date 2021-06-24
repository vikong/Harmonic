using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using FolderObserver.Properties;
using Harmonic;
using System.Drawing;

namespace FolderObserver
{
	public partial class ObserverForm
	{
		/// <summary>
		/// Файл со списком проверенных файлов
		/// </summary>
		private const String checkedFileInfo="CheckList.xml";
		private Boolean checkOnTimer=false;
		private Boolean popUp=true;

		private ComplexLex _conditions;
		private ComplexLex Conditions
		{
			get { return _conditions; }
			set	{_conditions=value;}
		}

		private Boolean CheckAnew { get; set; }

		private static Int32 NumOfShownString=50;
		private readonly List<String> _msgList=new List<String>(NumOfShownString);

		private void InitializeMy()
		{
			stopButton.Left=checkNowButton.Left;
			stopButton.Top=checkNowButton.Top;
			stopButton.Width=checkNowButton.Width;
			stopButton.Height=checkNowButton.Height;
			stopButton.Anchor=( (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Right) );

			var set=Settings.Default;
			if (set.ShowWindow)
				this.Show();

			if (set.FrmLocation.X>0 && set.FrmLocation.Y>0)
			{
				this.StartPosition=FormStartPosition.Manual;
				Left=set.FrmLocation.X;
				Top=set.FrmLocation.Y;
			}
			ShowInTaskbar=Visible=set.ShowWindow;
		}

		private void ConditionLoad()
		{
			var set=Properties.Settings.Default;
			if (String.IsNullOrWhiteSpace(set.ConditionFile))
			{
				AddMsg("Conditions not defined!");
				return;
			}
			try
			{
				ConditionLoad(set.ConditionFile);
			}
			catch (Exception ex)
			{
				AddMsg(String.Format("Can't load check conditions.\r\n{0}", ex.Message));
#if DEBUG
				MessageBox.Show(String.Format("Error load conditions {0}:\r\n{1}", ex.Message, ex.InnerException));
#endif
			}

		}
		
		/// <summary>
		/// Загружает условия из файла
		/// </summary>
		private void ConditionLoad(String file)
		{
			try
			{
				var newCond=ComplexLex.LoadFromFile(file);
				if (newCond==null)
					throw new Exception("Wrong conditions.");
				Conditions=newCond;
				conditionTextBox.Text=Conditions.ToString();
			}
			catch (Exception ex)
			{
				conditionTextBox.Text="Can't load check conditions. "+ex.Message;
			} 
		}

		private void ConditionSave()
		{
			try
			{
				Conditions.SaveToFile(Properties.Settings.Default.ConditionFile);
			}
			catch (Exception ex)
			{
				MessageBox.Show(String.Format("Error of saving conditions.\r\n"+ex.Message));
			}
		}

		private void SetCheckFolder(String path)
		{
			String newPath=Path.GetFullPath(path);
			if (folderTextBox.Text==newPath)
				return;

			if (!CheckAnew)
			{
				DialogResult checkAnew=
					MessageBox.Show("You changed the observed folder's path.\r\nDo you want to fully check all files in it?\r\n'No' button means that only NEW matches will be detect.", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				CheckAnew=(checkAnew==DialogResult.Yes);
			}
			folderTextBox.Text=newPath;

			AddMsg("The observed folder has been changed to: "+newPath);

		}
		
		private void StartCheck(Boolean checkAnew=false)
		{
			if (checkBackgroundWorker.IsBusy)
				return;
			progressBar.Visible=true;
			progressBar.Value=0;
			checkNowButton.Visible=false;
			stopButton.Visible=true;
			SettingsButton.Enabled=editContButton.Enabled=false;
			checkBackgroundWorker.RunWorkerAsync(checkAnew);
		}

		private void SetCheckOnTimer(Boolean mode)
		{
			if (mode==true)
			{
				checkTimer.Interval=Settings.Default.CheckInterval*60*1000;
				checkTimer.Enabled=true;
				autoPictureBox.Image=Resources.play_green_24;
				autoToolStripMenuItem.Checked=true;
				autoToolStripMenuItem.Image=Resources.check_green_16;
				notifyIcon.Icon=Resources.folder_run;
				notifyIcon.Text="Observing "+folderTextBox.Text.Trim();
				Int32 minutes;
				Int32 hours=Math.DivRem(Settings.Default.CheckInterval, 60, out minutes);
				AddMsg(String.Format("Automatic check turn ON. Check interval is {0} hrs. {1} min.", hours, minutes));
			}
			else
			{
				checkTimer.Enabled=false;
				autoPictureBox.Image=Resources.pause_24;
				autoToolStripMenuItem.Checked=false;
				autoToolStripMenuItem.Image=null;
				notifyIcon.Icon=Resources.folder_stop;
				notifyIcon.Text="Lazing";
				AddMsg("Automatic check turn OFF");
			}
			checkOnTimer=mode;
			Settings.Default.CheckOnTimer=mode;
			Settings.Default.Save();

		}
		private void AddMsg(String msg, Boolean showBalloonTip=false)
		{
			if (String.IsNullOrEmpty(msg))
				return;

			if (_msgList.Count>=NumOfShownString)
				_msgList.RemoveAt(0);

			_msgList.Add(String.Format("{0} {1} -\t{2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), msg));

			StringBuilder sb=new StringBuilder();
			_msgList.ForEach(row=>sb.AppendLine(row));
			logTextBox.Text=sb.ToString();
			logTextBox.SelectionStart=logTextBox.Text.Length;
			logTextBox.ScrollToCaret();
			if (showBalloonTip) // && !Visible)
				if (!popUp)
					notifyIcon.ShowBalloonTip(10000, null, msg, ToolTipIcon.Info);
				else
				{
					var frm=new PopUpForm();
					frm.Show();
				}
		}


		private void PopupMsg(String msg, String file, IEnumerable<String> keyWords)
		{
			var frm=new PopUpForm(file);
			var splitString=Infrastructure.Split(msg, keyWords);
			foreach (var entrance in splitString)
				frm.AppendText(entrance.Word, entrance.Keyword? Color.Red : Color.Black);

			frm.Show();
		}

		private void PopupMsg(String msg, Color color)
		{
			var frm=new PopUpForm();
			frm.AppendText(msg, color);
			frm.Show();
		}

		private void PopupMsg(String msg)
		{
			var frm=new PopUpForm();
			frm.AppendText(msg);
			frm.Show();
		}

		private void RestoreSettings()
		{
			var set=Properties.Settings.Default;
			NumOfShownString=set.NumOfShowString;
			folderTextBox.Text=set.CheckFolder;
			SetCheckOnTimer(set.CheckOnTimer);
		}

		private void DoUserSettings()
		{
			using (SettingForm frm =new SettingForm())
			{
				if (frm.ShowDialog()==DialogResult.Cancel)
					return;
			}

			var set=Settings.Default;
			SetCheckFolder(set.CheckFolder);

			RestoreSettings();
			ConditionLoad();
		}

		private void Expand()
		{
			bool top = TopMost;
			TopMost = true;

			if (!Visible)
			{
				Visible = ShowInTaskbar = true;
			}
			if (WindowState==FormWindowState.Minimized)
				WindowState = FormWindowState.Normal;
			
			TopMost = top;
		}

	}
}
