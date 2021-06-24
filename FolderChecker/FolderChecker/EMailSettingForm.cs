using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderChecker
{
	public partial class EMailSettingForm : Form
	{
		private Boolean _sending=false;
		private SmtpClient client;
		private Boolean valid;

		private Boolean Sending { 
			get { return _sending; }
			set
			{
				_sending=value;
				EnableControl(!_sending);
				testButton.Enabled=true;
				if (_sending)
					testButton.Text="Остановить";
				else
					testButton.Text="Тест";
			}
		}
		public EMailSettingForm()
		{
			InitializeComponent();
			RestoreSettings();
		}
		
		private void RaiseError(Control control, String message)
		{
			errorProvider.SetError(control, message);
			valid=false;
		}
		
		private void DropError(Control control)
		{
			errorProvider.SetError(control, String.Empty);
		}
		private Boolean Validate()
		{
			valid=true;
			if (String.IsNullOrWhiteSpace(senderTextBox.Text))
				RaiseError(senderTextBox, "Требуется адрес");
			else
				DropError(senderTextBox);

			if (String.IsNullOrWhiteSpace(ReciverTextBox.Text))
				RaiseError(ReciverTextBox, "Требуется адрес");
			else
				DropError(ReciverTextBox);

			if (String.IsNullOrEmpty(hostTextBox.Text))
				RaiseError(hostTextBox, "Требуется адрес");
			else
				DropError(hostTextBox);

			if (String.IsNullOrEmpty(portTextBox.Text))
				RaiseError(portTextBox, "Требуется номер порта");
			else
			{
				DropError(portTextBox);
				int port;
				if (!Int32.TryParse(portTextBox.Text, out port))
					RaiseError(portTextBox, "Номер порта должен быть числом");
				else
					DropError(portTextBox);
			}
			return valid;
		}
		private void SaveSettings()
		{
			var set=Properties.Settings.Default;

			set.EmlHost=hostTextBox.Text;
			set.EmlPort=Int32.Parse(portTextBox.Text);
			set.EmlSsl=sslCheckBox.Checked;
			
			set.EmlFrom=senderTextBox.Text;
			set.EmlTo=ReciverTextBox.Text;
			
			set.EmlUseCurUser=currentUserCheckBox.Checked;
			set.EmlLogin=loginTextBox.Text;
			set.EmlPass=passTextBox.Text;

			set.Save();

		}
		private void RestoreSettings()
		{
			var set=Properties.Settings.Default;

			hostTextBox.Text=set.EmlHost;
			portTextBox.Text=set.EmlPort.ToString();
			sslCheckBox.Checked=set.EmlSsl;

			senderTextBox.Text=set.EmlFrom;
			ReciverTextBox.Text=set.EmlTo;

			currentUserCheckBox.Checked=set.EmlUseCurUser;
			loginTextBox.Text=set.EmlLogin;
			passTextBox.Text=set.EmlPass;

		}

		private void EnableControl(Boolean enable)
		{
			UseWaitCursor=!enable;
			foreach (Control ctrl in Controls)
				ctrl.Enabled=enable;

		}
		private void testButton_Click(object sender, EventArgs e)
		{
			if (Sending==false)
			{
				if (!Validate())
				{
					MessageBox.Show("Неверные данные", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				Sending=true;
				try
				{
					MailMessage mail = new MailMessage(senderTextBox.Text, ReciverTextBox.Text);
					mail.BodyEncoding=mail.SubjectEncoding=Encoding.UTF8;
					mail.Subject="PingFolder testing message.";
					mail.Body = "Тестовое сообщение.";
					client=new SmtpClient(hostTextBox.Text);
					client.Port=Int32.Parse(portTextBox.Text);
					client.EnableSsl=sslCheckBox.Checked;
					client.UseDefaultCredentials = currentUserCheckBox.Checked;
					client.Credentials = new System.Net.NetworkCredential(loginTextBox.Text, passTextBox.Text);
					client.Timeout=30000;
					client.DeliveryMethod = SmtpDeliveryMethod.Network;

					client.SendCompleted+=new SendCompletedEventHandler(SendCompletedCallback);
					client.SendAsync(mail, "testing message");
				}
				catch (Exception ex)
				{
					EnableControl(true);
					testButton.Text="Тест";
					MessageBox.Show("Не удалось отправить почту.\r\n"+ex.Message+(ex.InnerException==null?String.Empty:"\r\n"+ex.InnerException.Message));
				}
			}
			else
			{
				if (client!=null)
					client.SendAsyncCancel();
			}

		}
		private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
		{
			client=null;
			if (e.Cancelled)
				MessageBox.Show("Отменено.");
			else
				if (e.Error!=null)
					MessageBox.Show("Не удалось отправить почту.\r\n"+e.Error.Message+(e.Error.InnerException==null?String.Empty:"\r\n"+e.Error.InnerException.Message));
				else
					MessageBox.Show("Почта отправлена. Проверьте почтовый ящик.");
			Sending=false;
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			if (!Validate())
			{
				MessageBox.Show("Неверные данные", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			SaveSettings();
			Close();
		}

	}
}
