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
using Harmonic;

namespace FolderObserver
{
	public partial class SettingForm : Form
	{
		public SettingForm()
		{
			InitializeComponent();
		}

		private void RestoreSettings()
		{
			var set=Properties.Settings.Default;
			Int32 minutes;
			hoursUpDown.Value=(Int32)Math.DivRem(set.CheckInterval, 60, out minutes);
			minutesUpDown.Value=(Int32)minutes;
			stringUpDown.Value=set.NumOfShowString;
			folderSelectControl.folderTextBox.Text=set.CheckFolder;
			conditionTextBox.Text=set.ConditionFile;
			ShowWindowCheckBox.Checked=!set.ShowWindow;
		}

		private void ConfirmSettings()
		{
			var set=Properties.Settings.Default;
			set.CheckFolder=folderSelectControl.folderTextBox.Text.Trim();
			set.ConditionFile=conditionTextBox.Text.Trim();
			set.CheckInterval = (Int32)(hoursUpDown.Value*60+minutesUpDown.Value);
			set.NumOfShowString=(Int32)stringUpDown.Value;
			set.ShowWindow=!ShowWindowCheckBox.Checked;
		}

		private Boolean CheckConditionFile(String file)
		{
			String message=String.Empty;
			Boolean result=false;
			try
			{
				var Conditions=ComplexLex.LoadFromFile(file);
				result=true;
			}
			catch (Exception ex)
			{
#if DEBUG
				MessageBox.Show(String.Format("Ошибка {0}:\r\n{1}", ex.Message, ex.InnerException));
#endif
				message=ex.Message;
				result=false;
			}

			if (result==false)
				MessageBox.Show(String.Format("Не удалось прочитать файл с условиями.\r\n{0}", message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);

			return result;
		}


		private void okButton_Click(object sender, EventArgs e)
		{
			ConfirmSettings();
		}

		private void ConditionOpenButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog fd = new OpenFileDialog();
			fd.DefaultExt="xml";
			fd.Filter="condition files (*.xml)|*.xml|All files|*.*";
			fd.RestoreDirectory=true;
			fd.Multiselect=false;
			if (fd.ShowDialog()==DialogResult.Cancel)
				return;
			if (!CheckConditionFile(fd.FileName))
				return;
			conditionTextBox.Text=fd.FileName;
		}

		private void SettingForm_Load(object sender, EventArgs e)
		{
			RestoreSettings();
		}


	}
}
