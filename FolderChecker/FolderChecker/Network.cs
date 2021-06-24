using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FolderChecker
{
	public class Network
	{
		public static IEnumerable<IPAddress> GetIpAddress(Uri uri)
		{
			if (uri.HostNameType==UriHostNameType.Dns)
				return Dns.GetHostAddresses(uri.Host)
					.Where(t => t.AddressFamily==AddressFamily.InterNetwork)
					.ToList();
			else
				return new IPAddress[] { IPAddress.Parse(uri.Host) };
		}
		/// <summary>
		/// Проверяет наличие в сети сервера с открытым портом 139 (предназначен для работы с файлами по сети в Windows)
		/// </summary>
		/// <param name="ip">IP адрес сервера</param>
		/// <param name="millisecondTimeout">максимальное время опроса</param>
		/// <returns></returns>
		public static Boolean IsFileSharingServerOnline(IPAddress ipAddr, Int32 millisecondTimeout)
		{
			const Int32 port=139;
			
			Boolean result=false;
			using (System.Net.Sockets.TcpClient socket=new System.Net.Sockets.TcpClient(ipAddr.AddressFamily))
			{
				var connect=socket.BeginConnect(ipAddr, port, null, null);
				var waitResult=connect.AsyncWaitHandle.WaitOne(millisecondTimeout, false);
				if (connect.IsCompleted)
				{
					if (waitResult)
					{
						socket.EndConnect(connect);
						result=true;
					}
					socket.Close();
				}
			}
			return result;
		}

		public static Boolean IsFileSharingServerOnline(String ip, Int32 millisecondTimeout)
		{
			IPAddress ipAddr;
			if (!IPAddress.TryParse(ip, out ipAddr))
				throw new InvalidOperationException("Неверный формат IP");
			return IsFileSharingServerOnline(ipAddr, millisecondTimeout);
		}

		public static Boolean IsPingReply(IPAddress ipAddr, Int32 millisecondTimeout)
		{
			Boolean result=false;
			try
			{
				PingReply pingReply;
				using (var ping = new Ping())
					pingReply = ping.Send(ipAddr, millisecondTimeout);
				result=(pingReply.Status == IPStatus.Success);
			}
			catch (PingException ex)
			{
				result=false;
			}
			return result;
		}

		public static Boolean IsPingReply(String ip, Int32 millisecondTimeout)
		{
			IPAddress ipAddr;
			if (!IPAddress.TryParse(ip, out ipAddr))
				throw new InvalidOperationException("Неверный формат IP");
			return IsPingReply(ipAddr, millisecondTimeout);
		}

		/// <summary>
		/// Проверяет возможность существования такого пути, в формате Url|Unc
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static Boolean ValidatePath(String path)
		{
			if (String.IsNullOrWhiteSpace(path))
				return false;

			// проверим, является ли url или unc
			if (Uri.IsWellFormedUriString(path, UriKind.Absolute))
				return true;

			// unc
			try
			{
				Uri uri=new Uri(Path.GetFullPath(path));
				//var chk=Uri.CheckSchemeName(uri.Scheme);
			}
			catch (Exception ex)
			{
				return false;
			}

			return true;
		}


	}
}
