using System;
using System.Drawing;
using System.Windows.Forms;

namespace FolderObserver
{
	public partial class PopUpForm : Form
	{
		public PopUpForm()
		{
			InitializeComponent();
		}

		public PopUpForm(String file):this()
		{
			fileTextBox.Text=file;
		}

		public void AppendText(String text, Color color)
		{
			var box=messageTextBox;
			box.SelectionStart = box.TextLength;
			box.SelectionLength = 0;

			box.SelectionColor = color;
			box.AppendText(text);
			box.SelectionColor = box.ForeColor;
			
		}
		public void AppendText(String text)
		{
			AppendText(text, Color.Black);
		}
		//public void ShowMessage(String message)
		//{
		//	messageTextBox.AppendText(message);
		//	//messageTextBox.SelectionStart=0;
		//	//messageTextBox.SelectionLength=0;

		//	TopMost = true;
		//	if (!Visible)
		//	{
		//		Visible = true;
		//	}
		//}

		private void PopUpForm_FormClosing(object sender, FormClosingEventArgs e)
		{

		}

		private void openExternalButton_Click(object sender, EventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start(fileTextBox.Text);

			}
			catch (Exception ex)
			{
				MessageBox.Show("Can't start this file.\r\n"+ex.Message);
			}
		}
	}
}
