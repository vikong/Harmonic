using System;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;

namespace Harmonic
{
	public partial class SaveButton : System.Windows.Forms.Button
	{
		public class FileArgs: EventArgs
		{
			public FileInfo FileInfo { get; set; }
			public FileArgs(String file)
			{
				FileInfo=new FileInfo(file);
			}
			public FileArgs(FileInfo fileInfo)
			{
				FileInfo=fileInfo;
			}
		}
		public class ConfirmArgs: EventArgs
		{
			public Boolean Confirm { get; set; }
		}

		public String Filter { get; set; }
		public String DefaultExt { get; set; }

		public event EventHandler<ConfirmArgs> BeforeSave;
		public event EventHandler<FileArgs> Save;
		protected void OnSave(String file)
		{
			if (Save!=null)
				Save(this, new FileArgs(file));
		}
		protected Boolean OnBeforeSave()
		{
			ConfirmArgs confirm=new ConfirmArgs {Confirm=true };
			if (BeforeSave!=null)
				BeforeSave(this, confirm);
			return confirm.Confirm;
		}
		public SaveButton()
		{
			InitializeComponent();
		}

		public SaveButton(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			if (!OnBeforeSave())
				return;
			SaveFileDialog fd=new SaveFileDialog();
			fd.OverwritePrompt=true;
			fd.RestoreDirectory=true;
			fd.Filter = Filter;
			fd.DefaultExt = DefaultExt;
			if (fd.ShowDialog()==DialogResult.Cancel)
				return;
			OnSave(fd.FileName);

		}


	}
}
