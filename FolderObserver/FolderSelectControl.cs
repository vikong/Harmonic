using System;
using System.Windows.Forms;

namespace FolderObserver
{
	public partial class FolderSelectControl : UserControl
	{
		public FolderSelectControl()
		{
			InitializeComponent();
		}

		private void dialogButton_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dlg=new FolderBrowserDialog();
			if (dlg.ShowDialog()==DialogResult.OK)
				folderTextBox.Text=dlg.SelectedPath;
		}
	}
}
