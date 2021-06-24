using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Harmonic.Subtitles
{
	public static class Network
	{

		public static IEnumerable<IPAddress> GetIpAddress(Uri uri)
		{
			if (uri.HostNameType == UriHostNameType.Dns)
				return Dns.GetHostAddresses(uri.Host)
					.Where(t => t.AddressFamily == AddressFamily.InterNetwork)
					.ToArray();
			else
				return new IPAddress[] { IPAddress.Parse(uri.Host) };
		}

		/// <summary>
		/// Проверяет наличие в сети сервера с открытым портом.
		/// </summary>
		/// <param name="ip">IP адрес сервера</param>
		/// <param name="millisecondTimeout">максимальное время опроса</param>
		/// <param name="port">Порт, по умолчанию = 139 (предназначен для работы с файлами по сети в Windows)</param> 
		/// <returns></returns>
		public static Boolean IsServerPortOpen(IPAddress ipAddr, Int32 port, Int32 millisecondTimeout = 1000)
		{
			Boolean result = false;
			using (TcpClient socket = new TcpClient(ipAddr.AddressFamily))
			{
				var connect = socket.BeginConnect(ipAddr, port, null, null);
				var waitResult = connect.AsyncWaitHandle.WaitOne(millisecondTimeout, false);
				if (connect.IsCompleted)
				{
					if (waitResult)
					{
						socket.EndConnect(connect);
						result = true;
					}
					socket.Close();
				}
			}
			return result;
		}

		public static Boolean IsServerPortOpen(String ip, Int32 port, Int32 millisecondTimeout = 1000)
		{
			if (!IPAddress.TryParse(ip, out IPAddress ipAddr))
				throw new InvalidOperationException(NetworkMessages.WrongIpFormat);
			return IsServerPortOpen(ipAddr, port, millisecondTimeout);
		}

		public static Boolean IsPingReply(IPAddress ipAddr, Int32 millisecondTimeout = 1000)
		{
			Boolean result;
			try
			{
				PingReply pingReply;
				using (var ping = new Ping())
					pingReply = ping.Send(ipAddr, millisecondTimeout);
				result = (pingReply.Status == IPStatus.Success);
			}
			catch (PingException)
			{
				result = false;
			}

			return result;
		}

		public static Boolean IsPingReply(String ip, Int32 millisecondTimeout = 1000)
		{
			if (!IPAddress.TryParse(ip, out IPAddress ipAddr))
				throw new InvalidOperationException(NetworkMessages.WrongIpFormat);

			return IsPingReply(ipAddr, millisecondTimeout);
		}

		/// <summary>
		/// Проверяет возможность существования такого пути, в формате Url|Unc
		/// </summary>
		/// <param name="path"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public static Boolean IsPathWellFormed(String path, out String message)
		{
			if (String.IsNullOrWhiteSpace(path))
			{
				message = NetworkMessages.EmptyPath;
				return false;
			}

			// проверим, является ли url или unc
			if (!Uri.IsWellFormedUriString(path, UriKind.Absolute))
				// unc
				try
				{
					Uri uri = new Uri(Path.GetFullPath(path));
				}
				catch (UriFormatException ex)
				{
					message = $"{NetworkMessages.UnknownPath} {ex.Message}";
					return false;
				}
				catch (Exception ex)
				{
					message = $"{NetworkMessages.UnknownPath} {ex.Message}";
					return false;
				}

			message = null;
			return true;
		}

		public static Boolean IsLocalHost(String input)
		{
			try { return IsLocalHost(new Uri(input)); }
			catch (Exception) { throw; }
		}

		public static Boolean IsLocalHost(Uri uri)
		{
			IPAddress[] host;
			//get host addresses
			try { host = Dns.GetHostAddresses(uri.Host); }
			catch (Exception) { return false; }

			//get local adresses
			IPAddress[] local = Dns.GetHostAddresses(Dns.GetHostName());

			//check if local
			return host.Any(hostAddress => IPAddress.IsLoopback(hostAddress) || local.Contains(hostAddress));
		}


		/// <summary>
		/// Проверяет подключение сервера к сети. 
		/// </summary>
		/// <param name="uri">Пукть</param>
		/// <param name="message">Причины недоступности сервера</param>
		/// <param name="checkFileEnabled">Разрешены ли операции с файлами</param>
		/// <param name="millisecondTimeOutIn">Время ожидания ответа сервера</param>
		/// <returns></returns>
		public static Boolean IsHostOnline(Uri uri, out String message, Boolean checkFileEnabled = false, Int32 millisecondTimeOutIn = 1000)
		{
			try
			{
				IEnumerable<IPAddress> ipList = Network.GetIpAddress(uri);
				if (ipList == null || ipList.Count() == 0)
				{
					message = $"{NetworkMessages.FailedIp} {NetworkMessages.Host}:[{uri.Host}]";
					return false;
				}

				if (!ipList.Any(a => Network.IsPingReply(a, millisecondTimeOutIn)))
				{
					message = $"{NetworkMessages.NotRespond} {NetworkMessages.Host}:[{uri.Host}]";
					return false;
				}

				const int filePort = 139;
				if (checkFileEnabled && !ipList.Any(a => Network.IsServerPortOpen(a, filePort, millisecondTimeOutIn)))
				{
					message = NetworkMessages.FilesOperationDisabled;
					return false;
				}

				message = null;
				return true;

			}

			catch (SocketException ex)
			{
				message = $"{NetworkMessages.FailedIp} {ex.Message}";
				return false;
			}

			catch (Exception ex)
			{
				message = $"{NetworkMessages.FailedIp} {ex.Message}";
				return false;
			}

		}

		public static String IsPathAvailable(String path, Boolean checkFileEnabled = false, Int32 millisecondTimeOutIn = 1000)
		{

			if (Directory.Exists(path))
			{
				return null;
			}

			// Определим причину недоступности

			// Парсим путь
			Uri uri;
			try
			{
				uri = new Uri(path);
			}
			catch (Exception ex)
			{
				return $"{NetworkMessages.WrongPath} {ex.Message}";
			}

			if (!uri.IsUnc)
			{
				try
				{
					DriveInfo driveInfo = new DriveInfo(path);
					switch (driveInfo.DriveType)
					{
						case DriveType.Network:
							if (!NetworkInterface.GetIsNetworkAvailable())
								return NetworkMessages.NoConnection; 
							else
								return driveInfo.IsReady ? NetworkMessages.UnknownPath : NetworkMessages.DriveNotReady; 

						case DriveType.Removable:
							return NetworkMessages.DriveAbsent;

						case DriveType.NoRootDirectory:
							if (!DriveInfo.GetDrives().Any(di => di.Name == driveInfo.Name))
								return NetworkMessages.DriveWrong;
							else
								return NetworkMessages.UnknownPath;

						default:
							return NetworkMessages.UnknownPath;
					}
				}
				catch (ArgumentException ex)
				{
					return $"{NetworkMessages.WrongPath} {ex.Message}";
				}
			}

			if (String.IsNullOrEmpty(uri.Host)) // сервер
			{
				return NetworkMessages.WrongPath;
			}

			if (!IsLocalHost(uri))
			{

				if (!NetworkInterface.GetIsNetworkAvailable())
				{
					return NetworkMessages.NoConnection;
				}

				if (!IsHostOnline(uri, out string msg, checkFileEnabled, millisecondTimeOutIn))
				{
					return msg;
				}

				return $"{NetworkMessages.UnknownPath} {NetworkMessages.Host}:[{uri.Host}] {NetworkMessages.Path}:[{uri.AbsolutePath}]";
			}

			return NetworkMessages.UnknownPath;
		}

		public static Boolean IsPathAvailable(String path, out String message, Boolean checkFileEnabled = false, Int32 millisecondTimeOutIn = 1000)
		{

			if (Directory.Exists(path))
			{
				message = null;
				return true;
			}

			// Определим причину недоступности

			// Парсим путь
			Uri uri;
			try
			{
				uri = new Uri(path);
			}
			catch (Exception ex)
			{
				message = $"{NetworkMessages.WrongPath} {ex.Message}";
				return false;
			}

			if (!uri.IsUnc)
			{
				try
				{
					DriveInfo driveInfo = new DriveInfo(path);
					switch (driveInfo.DriveType)
					{
						case DriveType.Network:
							if (!NetworkInterface.GetIsNetworkAvailable())
								message = NetworkMessages.NoConnection;
							else
								message = driveInfo.IsReady? NetworkMessages.UnknownPath : NetworkMessages.DriveNotReady;

							return false;

						case DriveType.Removable:
							message = NetworkMessages.DriveAbsent;
							return false;
						
						case DriveType.NoRootDirectory:
							if (!DriveInfo.GetDrives().Any(di => di.Name == driveInfo.Name))
								message = NetworkMessages.DriveWrong;
							else
								message = NetworkMessages.UnknownPath;
							return false;

						default: 
							message = NetworkMessages.UnknownPath;
							return false;
					}
				}
				catch (ArgumentException ex)
				{
					message = $"{NetworkMessages.WrongPath} {ex.Message}";
					return false;
				}
			}

			if (String.IsNullOrEmpty(uri.Host)) // сервер
			{
				message = NetworkMessages.WrongPath;
				return false;
			}

			if (!IsLocalHost(uri))
			{

				if (!NetworkInterface.GetIsNetworkAvailable())
				{
					message = NetworkMessages.NoConnection;
					return false;
				}

				if (!IsHostOnline(uri, out string msg, checkFileEnabled, millisecondTimeOutIn))
				{
					message = msg;
					return false;
				}

				message = $"{NetworkMessages.UnknownPath} {NetworkMessages.Host}:[{uri.Host}] {NetworkMessages.Path}:[{uri.AbsolutePath}]";
				return false;
			}

			message = NetworkMessages.UnknownPath;
			return false;
		}

		/// <summary>
		/// Возвращает список файлов по пути, с прогрессом и возможностью прерывания.
		/// </summary>
		/// <param name="path">Путь для сканирования</param>
		/// <param name="progress">коллбэк прогресса - к-во найденных файлов</param>
		/// <param name="cancellation">токен отмены</param>
		/// <returns></returns>
		public static Task<List<String>> GetFiles(String path, String searchPattern, IProgress<Int32> progress, CancellationToken cancellation)
		{
			return Task.Run(() => {
				IEnumerable<String> t =
					!String.IsNullOrEmpty(searchPattern) ? Directory.EnumerateFiles(path, searchPattern) : Directory.EnumerateFiles(path);
				List<String> result = new List<String>();
				var progressWatch = new System.Diagnostics.Stopwatch();
				int i = 0;
				progress?.Report(i);
				progressWatch.Start();
				foreach (string item in t)
				{
					result.Add(item);
					++i;
					if (cancellation.IsCancellationRequested)
						break;
					if (progressWatch.Elapsed.TotalMilliseconds >= 500)
					{
						progress?.Report(i);
						progressWatch.Restart();
					}
				}
				progressWatch.Stop();
				progress?.Report(i);
				return result;
			});

		}

		public static Task<List<String>> GetFiles(String path, IProgress<Int32> progress, CancellationToken cancellation)
		=> GetFiles(path, null, progress, cancellation);

	}
}
