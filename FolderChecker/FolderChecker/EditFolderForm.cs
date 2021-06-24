using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderChecker
{
	public partial class EditFolderForm : Form
	{
		public EditFolderForm()
		{
			AppendMode=true;
			InitializeComponent();
		}
		public EditFolderForm(FolderInfo folderPar):this()
		{
			AppendMode=false;
			folderSelectControl.folderTextBox.Text=folderPar.Path;
			NameTextBox.Text=folderPar.Name;
		}

		private void confirmButton_Click(object sender, EventArgs e)
		{
			String path=folderSelectControl.folderTextBox.Text.Trim();
			if (!Network.ValidatePath(path))
			{
				if (MessageBox.Show("Возможно, неправильно задан путь. Принять?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.Cancel)
				{
					errorProvider1.SetError(folderSelectControl, "Неверный формат пути");
					folderSelectControl.Focus();
					return;
				}
				else
				{
					errorProvider1.SetError(folderSelectControl, String.Empty);
				}
			}

			this.onLoginConfirm(new EditArgs
			{
				Path=path,
				Name=NameTextBox.Text.Trim()
			});

		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void folderSelectControl_Validating(object sender, CancelEventArgs e)
		{
			if (!Network.ValidatePath(folderSelectControl.folderTextBox.Text.Trim()))
				errorProvider1.SetError(folderSelectControl,"Неверный формат пути");
			else
				errorProvider1.SetError(folderSelectControl,String.Empty);
		}
	}
}
