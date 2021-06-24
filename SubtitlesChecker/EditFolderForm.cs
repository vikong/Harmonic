using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Harmonic.Subtitles
{
	public partial class EditFolderForm : Form
	{
		private readonly String _currentFolderName;

		private Boolean AppendMode { get; set; }

		/// <summary>
		/// data-объект для передачи данных
		/// </summary>
		internal class EditArgs : EventArgs
		{
			public String CurrentName { get; set; }
			public FolderInfo FolderInfo { get; }

			/// <summary>
			/// сохранение подтверждено
			/// </summary>
			public Boolean Confirm { get; set; }

			/// <summary>
			/// сообщение об ошибке
			/// </summary>
			public String Message { get; set; }

			public EditArgs()
			{ }

			public EditArgs(FolderInfo folderInfo)
			{
				FolderInfo = folderInfo;
			}


		}

		/// <summary>
		/// редактирование завершено
		/// </summary>
		internal event EventHandler<EditArgs> EditConfirm;

		private void OnEditConfirm(EditArgs arg)
		{
			if (EditConfirm == null)
				return;

			EditConfirm(this, arg);
			if (arg.Confirm)
				if (AppendMode)
				{
					NameTextBox.Text
						= sourceFolderSelectControl.folderTextBox.Text
						= targetFolderSelectControl.folderTextBox.Text
						= SubtitlesFileTextBox.Text
						= String.Empty;
					sourceFolderSelectControl.Focus();
				}
				else
					this.Close();
			else
				MessageBox.Show(arg.Message);
		}

		public EditFolderForm()
		{
			AppendMode = true;
			InitializeComponent();
		}

		public EditFolderForm(FolderInfo folderPar)
			: this()
		{
			AppendMode = false;
			_currentFolderName = folderPar.Name;
			sourceFolderSelectControl.folderTextBox.Text = folderPar.SourceFolder;
			targetFolderSelectControl.folderTextBox.Text = folderPar.TargetFolder;
			SubtitlesFileTextBox.Text = folderPar.TemplateFile;
			NameTextBox.Text = folderPar.Name;
			suffixesTextBox.Text = folderPar.Suffixes;
		}

		private bool ValidatePathInControl(FolderSelectControl folder)
		{
			String path = folder.folderTextBox.Text.Trim();
			if (!Network.IsPathWellFormed(path, out string message))
			{
				if (MessageBox.Show($"{Messages.WrongPath}\r\n{message}\r\n{Messages.Confirm}?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
				{
					errorProvider1.SetError(folder, Messages.WrongPath);
					folder.Focus();
					return false;
				}
				else
				{
					errorProvider1.SetError(folder, String.Empty);
					return true;
				}
			}

			return true;
		}

		private void confirmButton_Click(object sender, EventArgs e)
		{
			if (!ValidatePathInControl(sourceFolderSelectControl))
				return;

			if (!ValidatePathInControl(targetFolderSelectControl))
				return;

			if (!String.IsNullOrWhiteSpace(SubtitlesFileTextBox.Text) && !File.Exists(SubtitlesFileTextBox.Text.Trim()))
			{
				if (MessageBox.Show($"{Messages.SubtitlesFileNotFound}\r\n{Messages.Confirm}?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
				{
					errorProvider1.SetError(SubtitlesFileTextBox, Messages.FileNotFound);
					SubtitlesFileTextBox.Focus();
					return;
				}
			}

			var fi = new FolderInfo
			{
				Name = NameTextBox.Text.Trim(),
				SourceFolder = sourceFolderSelectControl.folderTextBox.Text.Trim(),
				TargetFolder = targetFolderSelectControl.folderTextBox.Text.Trim(),
				Suffixes = suffixesTextBox.Text,
				TemplateFile = SubtitlesFileTextBox.Text.Trim()
			};

			OnEditConfirm(new EditArgs(fi) { CurrentName = _currentFolderName });
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void folderSelectControl_Validating(object sender, CancelEventArgs e)
		{
			if (!Network.IsPathWellFormed(sourceFolderSelectControl.folderTextBox.Text.Trim(), out string message))
				errorProvider1.SetError(sourceFolderSelectControl, $"{Messages.WrongPath}\r\n{message}");
			else
				errorProvider1.SetError(sourceFolderSelectControl, String.Empty);

			if (String.IsNullOrWhiteSpace(NameTextBox.Text) && !String.IsNullOrWhiteSpace(sourceFolderSelectControl.folderTextBox.Text))
				try
				{
					NameTextBox.Text = Path.GetFileNameWithoutExtension(Path.GetDirectoryName(sourceFolderSelectControl.folderTextBox.Text.Trim()));
				}
				catch (Exception) { }
		}

		private void EditFolderForm_Load(object sender, EventArgs e)
		{
		}

		private void SubtitlesFileButton_Click(object sender, EventArgs e)
		{
			using (var dlg = new OpenFileDialog())
			{
				String defaultPath = PathAddBackslash(Path.GetFullPath(Path.GetDirectoryName(Application.ExecutablePath)));
				String ext = Properties.Settings.Default.ExtSubtitles;
				dlg.InitialDirectory = defaultPath;
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

		private void targetFolderSelectControl_Validating(object sender, CancelEventArgs e)
		{
			if (!Network.IsPathWellFormed(targetFolderSelectControl.folderTextBox.Text.Trim(), out string message))
				errorProvider1.SetError(targetFolderSelectControl, $"{Messages.WrongPath}\r\n{message}");
			else
				errorProvider1.SetError(targetFolderSelectControl, String.Empty);

		}

		private void EditFolderForm_HelpRequested(object sender, HelpEventArgs hlpevent)
		{
			var helpFile = Path.Combine(Application.StartupPath, Application.CurrentCulture.TwoLetterISOLanguageName, "SubtitlesChecker.chm");
			if (File.Exists(helpFile))
				Help.ShowHelp(this, @"file://" + helpFile, HelpNavigator.KeywordIndex, helpLabel.Text);
			hlpevent.Handled = true;

		}
	}
}