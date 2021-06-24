using System;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;

namespace Harmonic.Subtitles
{
	public partial class SettingForm : Form
	{
		private CultureInfo currentCultureInfo;
		public SettingForm()
		{
			InitializeComponent();
		}

		private Boolean ValidateSettings()
		{
			Boolean result = true;
			if (hoursUpDown.Value * 60 + minutesUpDown.Value <= 0)
				result = false;
			if (String.IsNullOrWhiteSpace(FoldersListFileTextBox.Text))
				result = false;
			return result;
		}

		private void SaveSettings()
		{
			var set = Properties.Settings.Default;

			set.CheckInterval = (Int32)(hoursUpDown.Value * 60 + minutesUpDown.Value);
			set.FoldersListFile = FoldersListFileTextBox.Text.Trim();
			set.SubtitlesFile = SubtitlesFileTextBox.Text.Trim();
			set.ExtSubtitles = subtitlesExtTextBox.Text.Trim();
			set.Suffix = suffixTextBox.Text.Trim();
			set.ExtSource = ExtSourcesTextBox.Text;
			set.ShowWindow = !ShowWindowCheckBox.Checked;
			set.Language = currentCultureInfo.Name;

			set.Save();
		}

		private void RestoreSettings()
		{
			var set = Properties.Settings.Default;
			hoursUpDown.Value = (Int32)Math.DivRem(set.CheckInterval, 60, out int minutes);
			minutesUpDown.Value = (Int32)minutes;
			FoldersListFileTextBox.Text = set.FoldersListFile;
			SubtitlesFileTextBox.Text = set.SubtitlesFile;
			subtitlesExtTextBox.Text = set.ExtSubtitles;
			suffixTextBox.Text = set.Suffix;
			ExtSourcesTextBox.Text = set.ExtSource;
			ShowWindowCheckBox.Checked = !set.ShowWindow;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			if (!ValidateSettings())
				return;
			SaveSettings();
			Close();
		}

		private void cancelButton_Click(object sender, EventArgs e) 
			=> Close();


		private void FoldersListFileButton_Click(object sender, EventArgs e)
		{
			using (var dlg = new OpenFileDialog())
			{
				String defaultPath = PathAddBackslash(Path.GetFullPath(Path.GetDirectoryName(Application.ExecutablePath)));
				dlg.InitialDirectory = defaultPath;
				dlg.Filter = "xml (*.xml)|*.xml|txt (*.txt)|*.txt|All files (*.*)|*.*";
				dlg.DefaultExt = "xml";
				dlg.CheckFileExists = false;
				if (dlg.ShowDialog() == DialogResult.OK)
					FoldersListFileTextBox.Text = dlg.FileName.Replace(defaultPath, "");
			}
		}

		private void SubtitlesFileButton_Click(object sender, EventArgs e)
		{
			using (var dlg = new OpenFileDialog())
			{
				String defaultPath = PathAddBackslash(Path.GetFullPath(Path.GetDirectoryName(Application.ExecutablePath)));
				dlg.InitialDirectory = defaultPath;
				string ext = !String.IsNullOrWhiteSpace(subtitlesExtTextBox.Text) ? 
					subtitlesExtTextBox.Text.Trim() : 
					!String.IsNullOrWhiteSpace(Properties.Settings.Default.ExtSubtitles)? 
					Properties.Settings.Default.ExtSubtitles : "*";

				dlg.Filter = $"{ext} (*.{ext})|*.{ext}|All files (*.*)|*.*";
				dlg.DefaultExt = ext;
				dlg.CheckFileExists = false;
				if (dlg.ShowDialog() == DialogResult.OK)
					SubtitlesFileTextBox.Text = dlg.FileName.Replace(defaultPath, "");
			}
		}

		private String PathAddBackslash(String path)
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
			currentCultureInfo = Thread.CurrentThread.CurrentUICulture;
			switch (currentCultureInfo.Name)
			{
				case "en-EN":
					ruRadioButton.Checked = false;
					enRadioButton.Checked = true;
					break;
				case "ru-RU":
					ruRadioButton.Checked = true;
					enRadioButton.Checked = false;
					break;
				default:
					ruRadioButton.Checked = false;
					enRadioButton.Checked = true;
					break;
			}
			
			RestoreSettings();
		}

		private void ChangeCulture(String cultureName)
		{
			if (this.currentCultureInfo.Name.Equals(cultureName, StringComparison.OrdinalIgnoreCase))
				return;
			currentCultureInfo = CultureInfo.GetCultureInfo(cultureName);
			this.ChangeLanguage(currentCultureInfo);
		}

		private void ruRadioButton_Click(object sender, EventArgs e)
		{
			ChangeCulture("ru-RU");
		}

		private void enRadioButton_Click(object sender, EventArgs e)
		{
			ChangeCulture("en-EN");
		}

		private void SettingForm_HelpRequested(object sender, HelpEventArgs hlpevent)
		{
			var helpFile = Path.Combine(Application.StartupPath, Application.CurrentCulture.TwoLetterISOLanguageName, "SubtitlesChecker.chm");
			if (File.Exists(helpFile))
				Help.ShowHelp(this, @"file://" + helpFile, HelpNavigator.KeywordIndex, helpLabel.Text);
			hlpevent.Handled = true;
		}

	}
}