using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace FolderChecker
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			try
			{
				var configFile = Assembly.GetExecutingAssembly().Location + ".config";
				if (!File.Exists(configFile))
					throw new Exception("Отсутствует файл настроек *.config");
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				
				if (Properties.Settings.Default.AppFirst)
					using (var settingForm=new SettingForm())
					{
						if (settingForm.ShowDialog()==DialogResult.Cancel)
						{
							MessageBox.Show("Для запуска приложения необходимо выполнить настройки.\r\nОтменено пользователем.", Application.ProductName, MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
							return;
						}
						Properties.Settings.Default.AppFirst=false;
						Properties.Settings.Default.Save();
					}
				var frm=new MainForm();
				Application.Run();
			}
			catch (Exception ex)
			{
				ErrorHandler.Log(ex, @"CheckFolder error.xml");
				MessageBox.Show("Произошла ошибка в приложении.\r\n"+ex.Message+"\r\n\r\nПриложение будет закрыто.", Application.ProductName, MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
	}
}
