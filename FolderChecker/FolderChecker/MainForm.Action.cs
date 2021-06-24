using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using FolderChecker.Properties;
using System.Text;
using System.Net.Mail;
using System.Windows.Forms;

namespace FolderChecker
{
	partial class MainForm
	{
		private Boolean _folderListChanged=false;
		private SmtpClient _client;
		private SmtpClient smtpClient { get { if (_client==null) _client=new SmtpClient(); return _client; } }
		
		private readonly Object _lock=new Object();

		private readonly Dictionary<String, String> _log=new Dictionary<String, String>();
		private Dictionary<String, String> Log { get { return _log; } }
		private Boolean _error=false;
		private Boolean Error { get { return _error; } set { _error=value; } }
		private Boolean _auto;
		private Boolean Auto { 
			get { return _auto; }
			set {
				if (_auto==value)
					return;
				if (value==true)
				{
					checkTimer.Interval=Settings.Default.CheckInterval*60*1000;
					checkTimer.Enabled=true;
					autoPictureBox.Image=Resources.play_green_24;
				}
				else
				{
					checkTimer.Enabled=false;
					autoPictureBox.Image=Resources.pause_24;
				}
				_auto=value;
				Settings.Default.AutoCheck=value;
				Settings.Default.Save();
			} 
		}
		private Boolean Manual { get; set; }

		/// <summary>
		/// признак, что пользователь изменил список
		/// </summary>
		private Boolean _FolderListChanged
		{ 
			get { return _folderListChanged; }
			set { SaveTimer.Enabled=value; _folderListChanged=value; } 
		}

		private void FolderListChanged()
		{
			if (!SaveTimer.Enabled) 
				SaveTimer.Enabled=true; 
			_folderListChanged=true;
		}
		private void InitializeMy()
		{
			if (Settings.Default.ShowWindow)
				this.Show();
			ShowInTaskbar=Visible=Settings.Default.ShowWindow;
			if (Settings.Default.FrmLocation.X>0 && Settings.Default.FrmLocation.Y>0)
			{
				this.StartPosition=FormStartPosition.Manual;
				Left=Settings.Default.FrmLocation.X;
				Top=Settings.Default.FrmLocation.Y;
			}
			if (Settings.Default.TestFileSize<=0)
			{
				Settings.Default.TestFileSize=100;
				Settings.Default.Save();
			}

			smtpClient.Timeout=30000;
			smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtpClient.SendCompleted+=SendCompletedCallback;

			autoToolStripMenuItem.Checked=
				Auto=
				Settings.Default.AutoCheck;
			if (Auto)
				autoToolStripMenuItem.Image=Resources.check_green_16;
			else
				autoToolStripMenuItem.Image=null;

		}
		private void ItemAdded(object sender, EditFolderForm.EditArgs e)
		{
			if (FolderList.Where(t=>t.Name==e.Name).Count()>0)
			{
				e.Confirm=false;
				e.Message="Путь с таким именем уже есть";
				return;
			}
			var newItem=new FolderInfo { Name=e.Name, Path=e.Path };
			FolderList.Add(newItem);
			FolderBindingSource.ResetBindings(false);
			//FolderBindingSource.Position
			FolderListChanged();
			e.Confirm=true;
		}
		private void AddItems()
		{
			using (var frm=new EditFolderForm())
			{
				frm.EditConfirm+=ItemAdded;
				frm.ShowDialog();
			}
		}

		private void Edited(object sender, EditFolderForm.EditArgs e)
		{
			var currentItem=FolderBindingSource.Current as FolderInfo;
			currentItem.Name=e.Name;
			currentItem.Path=e.Path;
			FolderListChanged();
			FolderBindingSource.ResetCurrentItem();
			e.Confirm=true;
		}

		private void EditItem(FolderInfo folder)
		{
			using (var editForm=new EditFolderForm(folder))
			{
				editForm.EditConfirm+=Edited;
				editForm.ShowDialog();
			}
		}

		private void EditCurrent()
		{
			var currentItem=FolderBindingSource.Current as FolderInfo;
			if (currentItem==null)
				return;
			EditItem(currentItem);
		}

		
		private void RemoveItem(FolderInfo folder)
		{
			FolderList.Remove(folder);
			FolderListChanged();
		}
		private void RemoveCurrent()
		{
			var currentItem=FolderBindingSource.Current as FolderInfo;
			if (currentItem==null)
				return;
			FolderBindingSource.RemoveCurrent();
			RemoveItem(currentItem);
		}

		private void SwitchCurrent(Boolean value)
		{
			var currentItem=FolderBindingSource.Current as FolderInfo;
			if (currentItem==null)
				return;
			currentItem.Off=value;
			FolderListChanged();
			FolderBindingSource.ResetCurrentItem();
		}

		private void SaveFolders()
		{
			if (!_folderListChanged)
				return;
			_folderListChanged=false;

			try
			{
				Serializer.Save<List<FolderInfo>>(Settings.Default.FoldersListFile, FolderList);
			}
			catch (Exception ex)
			{ }
		}

		void save_DoWork(object sender, DoWorkEventArgs e)
		{
			SaveFolders();
		}

		void CheckFolder(FolderInfo folder, Int32 numOfBytes=1024)
		{
			const Int32 timeOut=5*1000;

			folder.Status=FolderInfo.State.Checking;
			if (numOfBytes<=0)
			{
				folder.RaiseError("Указана отрицательная длина файла.");
				throw new InvalidOperationException("Длина файла должна быть неотрицательным числом.");
			}

			if(Directory.Exists(folder.Path))
				try
				{
					String fileName=Path.Combine(folder.Path,"_test_"+folder.Name+".tmp");
					Byte[] dataArray = new Byte[numOfBytes];
					new Random().NextBytes(dataArray);
					TimeSpan ts;
					using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
					{
						DateTime start=DateTime.Now;
						for (int i = 0; i < dataArray.Length; i++)
						{
							fileStream.WriteByte(dataArray[i]);
						}

						fileStream.Flush();
						ts=DateTime.Now-start;
						
						fileStream.Seek(0, SeekOrigin.Begin);

						for (int i = 0; i < fileStream.Length; i++)
						{
							if (dataArray[i] != fileStream.ReadByte())
							{
								folder.RaiseError("Ошибка верификации данных.");
								break;
							}
						}
					}
					File.Delete(fileName);
					Double speed = (ts.TotalSeconds>0? Math.Truncate(numOfBytes/ts.TotalSeconds) : 0);
					String spd = speed>0? Math.Truncate(speed/1024).ToString()+"кБ/сек":"слишком велика для определения" ;

					folder.Ok("Скорость: "+spd);
					
				}
				catch(Exception ex)
				{
					folder.RaiseError(String.Format("Произошла ошибка при попытке записать данные {0}", ex.Message));
				}
			
			else
			{
				Uri uri;
				try
				{
					 uri = new Uri(folder.Path);
				}
				catch (Exception ex)
				{
					folder.RaiseError("Неверный формат пути.");
					return; 
				}

				if (!String.IsNullOrEmpty(uri.Host)) // сервер
				{
					if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
					{
						try
						{
							var ipList=Network.GetIpAddress(uri);
							if (ipList!=null && ipList.Count()>0)
							{
								foreach (IPAddress ipAddr in ipList)
									if (Network.IsFileSharingServerOnline(ipAddr, timeOut) || Network.IsPingReply(ipAddr, timeOut))
									{
										folder.RaiseError(String.Format("Связь с сервером {0} есть, но не удается записать данные в {1}.", uri.Host, uri.OriginalString));
										break;
									}
								if (folder.Status==FolderInfo.State.Checking)
									folder.RaiseError(String.Format("Сервер {0} не отвечает.", uri.Host));
							}
							else
								folder.RaiseError(String.Format("Не удалось определить IP сервера {0}.", uri.Host));

						}
						catch (SocketException ex)
						{
							folder.RaiseError("Не удалось разрешить адрес. Неверно указан путь или проблемы с DNS-сервером. "+ex.Message);
						}

						catch (Exception ex)
						{
							folder.RaiseError(String.Format("Произошла ошибка при попытке соединиться с сервером. {0}", ex.Message));
						}
					}
					else
						folder.RaiseError("Недоступно сетевое подключение.");
				}
				else 
					folder.RaiseError("Неверно указан путь.");
			}
		}//CheckFolder

		private void LogFolder(FolderInfo folder)
		{
			if (folder.Status!=FolderInfo.State.Ok)
			{
				lock (_lock)
				{
					Log.Add(folder.Name+" ("+folder.Path+")", folder.Message);
				}
				Error=true;
			}
		}
		private void LogClear()
		{
			lock (_lock)
			{
				Error=false;
				Log.Clear();
			}
		}

		private String LogText 
		{ 
			get 
			{
				StringBuilder sb=new StringBuilder();
				foreach (KeyValuePair<String, String> kvp in Log)
					sb.AppendFormat("-{0}:\r\n{1}\r\n\r\n", kvp.Key, kvp.Value);
				return sb.ToString();
			} 
		}
		private void LogSave()
		{
			LogSave(LogText);
		}
		private void LogSave(String message)
		{
			const String line="---------------------------------------------------------------------------------------------------------------------\r\n";
			File.AppendAllText(Settings.Default.LogFile, line+DateTime.Now.ToString()+"\r\n"+line + message+"\r\n\r\n", Encoding.Default);
		}

		private void SendWarn(String messageBody)
		{
			var set=Properties.Settings.Default;

			MailMessage mail = new MailMessage(set.EmlFrom, set.EmlTo);
			mail.BodyEncoding=mail.SubjectEncoding=Encoding.UTF8;
			mail.Subject=set.EmlSubject;
			mail.IsBodyHtml=false;
			mail.Body = messageBody;

			smtpClient.Host=set.EmlHost;
			smtpClient.Port=set.EmlPort;
			smtpClient.EnableSsl=set.EmlSsl;
			smtpClient.UseDefaultCredentials = set.EmlUseCurUser;
			if (!String.IsNullOrWhiteSpace(set.EmlLogin))
				smtpClient.Credentials = new System.Net.NetworkCredential(set.EmlLogin, set.EmlPass);
					
			smtpClient.SendAsync(mail, "warning message");

		}

		private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
		{
			if (e.Error==null)
				LogSave("Отправлено сообщение "+Settings.Default.EmlTo);
			else
				LogSave("Не удалось отправить сообщение по электронной почте.\r\n"+e.Error.Message+(e.Error.InnerException==null?String.Empty:"\r\n"+e.Error.InnerException.Message));

		}

	}
	
}
