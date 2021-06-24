using System;
using System.Threading;
using System.Windows.Forms;

namespace Harmonic.Subtitles
{
	internal static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Application.ThreadException += new ThreadExceptionEventHandler(ErrorHandler.Application_ThreadException);
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ErrorHandler.CurrentDomain_UnhandledException);

			try
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);

				if (Properties.Settings.Default.AppFirst)
					using (var settingForm = new SettingForm())
					{
						if (settingForm.ShowDialog() == DialogResult.Cancel)
						{
							MessageBox.Show(Messages.ConfigErr, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return;
						}
						Properties.Settings.Default.AppFirst = false;
						Properties.Settings.Default.Save();
					}
				if (!String.IsNullOrWhiteSpace(Properties.Settings.Default.Language))
					Application.CurrentCulture
						= Thread.CurrentThread.CurrentUICulture
						= Thread.CurrentThread.CurrentCulture
						= System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
				var frm = new MainForm();
				Application.Run();
			}
			catch (Exception ex)
			{
				ErrorHandler.Log(ex, @"ErrorLog.xml");
#if !DEBUG
				MessageBox.Show(Messages.AppError, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
				throw ex;
#endif
			}
		}
	}
}