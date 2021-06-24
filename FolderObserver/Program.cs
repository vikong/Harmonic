using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace FolderObserver
{
	static class Program
	{
		/// <summary>
		/// мьютекс для контроля единственности запущенного экземпляра приложения
		/// </summary>
		private static readonly Mutex mutex = new Mutex(true, "{59FF88CA-5981-46C8-974F-74FAAC79998D}");

		private static readonly Int32 WM_SHOWME = NativeMethods.RegisterWindowMessage("WM_SHOW_OBSERVERWIN");
		public static readonly String ErrorLog= @"_Error log.xml";
		
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// Если уже определен мьютекс, отправим сообщение приложению на показ окна
			if (!mutex.WaitOne(TimeSpan.Zero, true))
			{
				NativeMethods.PostMessage(
					(IntPtr)NativeMethods.HWND_BROADCAST,
					WM_SHOWME,
					IntPtr.Zero,
					IntPtr.Zero
				);
				return;
			}

			try
			{
				var configFile = Assembly.GetExecutingAssembly().Location + ".config";
				if (!File.Exists(configFile))
					throw new Exception("Missing config file (*.config) in the start folder.");

				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);

				if (Properties.Settings.Default.AppFirst)
					using (var settingForm=new SettingForm())
					{
						if (settingForm.ShowDialog()==DialogResult.Cancel)
						{
							MessageBox.Show("Application needs the user settings for properly work.\r\nRestart and set up again.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return;
						}
						Properties.Settings.Default.AppFirst=false;
						Properties.Settings.Default.Save();
					}

				var frm=new ObserverForm();
				var msg=new MessageFilter(WM_SHOWME, frm.ObserverForm_Message);
				Application.AddMessageFilter(msg);
				Application.Run();
			}
			catch (Exception ex)
			{
				ErrorHandler.Log(ex, ErrorLog);
				MessageBox.Show("An unexpected error occurred.\r\nError log is in the application's folder.\r\nPlease, send this file to developer.\r\nSorry for inconvenience.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				mutex.ReleaseMutex();
			}
		}
	}
}
