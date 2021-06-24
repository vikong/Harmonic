using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderChecker
{
	public partial class SettingForm : Form
	{
		public SettingForm()
		{
			InitializeComponent();
			RestoreSettings();
		}
		private Boolean Validate()
		{
			Boolean result=true;
			if (hoursUpDown.Value*60+minutesUpDown.Value<=0)
				result=false;
			if (String.IsNullOrWhiteSpace(FoldersListFileTextBox.Text))
				result=false;
			return result;
		}
		//private void RaiseError(String message)
		private void SaveSettings()
		{
			var set=Properties.Settings.Default;
			
			set.CheckInterval = (Int32)(hoursUpDown.Value*60+minutesUpDown.Value);
			set.FoldersListFile=FoldersListFileTextBox.Text;
			set.LogFile=LogFileTextBox.Text;
			set.EmlSend=EmlSendCheckBox.Checked;
			set.ShowWindow=!ShowWindowCheckBox.Checked;
			set.TestFileSize=(Int32)fileSizeNumericUpDown.Value;
			set.Save();
		}
		private void RestoreSettings()
		{
			var set=Properties.Settings.Default;
			Int32 minutes;
			hoursUpDown.Value=(Int32)Math.DivRem(set.CheckInterval, 60, out minutes);
			minutesUpDown.Value=(Int32)minutes;
			FoldersListFileTextBox.Text=set.FoldersListFile;
			LogFileTextBox.Text=set.LogFile;
			EmlSendCheckBox.Checked=set.EmlSend;
			ShowWindowCheckBox.Checked=!set.ShowWindow;
			fileSizeNumericUpDown.Value=set.TestFileSize;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			if (!Validate())
				return;
			SaveSettings();
			Close();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void mailSettingButton_Click(object sender, EventArgs e)
		{
			using (var frm=new EMailSettingForm())
			{
				frm.ShowDialog();
			}
		}

		private void FoldersListFileButton_Click(object sender, EventArgs e)
		{
			using (var dlg=new OpenFileDialog())
			{
				String defaultPath = PathAddBackslash(Path.GetFullPath(Path.GetDirectoryName(Application.ExecutablePath)));
				dlg.InitialDirectory=defaultPath;
				dlg.Filter="xml (*.xml)|*.xml|txt (*.txt)|*.txt|All files (*.*)|*.*";
				dlg.DefaultExt="xml";
				dlg.CheckFileExists=false;
				if (dlg.ShowDialog()==DialogResult.OK)
					FoldersListFileTextBox.Text=dlg.FileName.Replace(defaultPath, "");
			}
		}
		private void LogFileButton_Click(object sender, EventArgs e)
		{
			using (var dlg=new OpenFileDialog())
			{
				String defaultPath = PathAddBackslash(Path.GetFullPath(Path.GetDirectoryName(Application.ExecutablePath)));
				dlg.InitialDirectory=defaultPath;
				dlg.Filter="txt (*.txt)|*.txt|All files (*.*)|*.*";
				dlg.DefaultExt="txt";
				dlg.CheckFileExists=false;
				if (dlg.ShowDialog()==DialogResult.OK)
					LogFileTextBox.Text=dlg.FileName.Replace(defaultPath, "");
			}
		}
		String PathAddBackslash(String path)
		{
			String separator1 = Path.DirectorySeparatorChar.ToString();
			String separator2 = Path.AltDirectorySeparatorChar.ToString();
			path = path.TrimEnd();

			if (path.EndsWith(separator1) || path.EndsWith(separator2))
				return path;

			if (path.Contains(separator2))
				return path + separator2;

			return path + separator1;
		}

		private void SettingForm_Load(object sender, EventArgs e)
		{

		}

	}
}
