using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Harmonic.Subtitles;
using System.IO;

namespace HarmonicTest
{
	[TestClass]
	public class NetworkTest
	{
		//[DataRow(@"a:\temp\")]
		//[DataRow(@"d:\temp\")]
		//[DataRow(@"z:\temp")]
		//[DataTestMethod]
		[TestMethod]
		public void Any()//String path)
		{
			//DriveInfo driveInfo = new DriveInfo(path);
			//Debug.WriteLine(driveInfo.DriveType);
			DriveInfo di = new DriveInfo(@"z:\temp");
			Uri uri = new Uri(@"z:\temp");
			Debug.WriteLine(di.DriveType);
			Debug.WriteLine(Network.IsLocalHost(@"\\10.2.0.93\Temp\"));
			Debug.WriteLine(Network.IsLocalHost(@"ntb00382"));
			Debug.WriteLine(Network.IsLocalHost(@"\\127.0.0.1\"));
		}

		[DataRow(@"\\kmessanger\Prog")]
		[DataRow(@"\\kmessanger\c$\Prog")]
		[DataRow(@"\\10.2.0.93\Prog")]
		[DataRow(@"//kmessanger/Prog")]
		[DataTestMethod]
		public void IsHostOnline_ReturnsTrue_ForOnlineFileServer(string path)
		{
			Uri uri = new Uri(path);
			Assert.IsTrue(Network.IsHostOnline(uri, out string msg, true));
		}



		[DataRow(@"//google.com/")]
		[DataRow(@"//10.70.0.5")]
		[DataRow(@"//ntbroker.ru/")]
		[DataTestMethod]
		public void IsHostOnline_ReturnsTrue_ForOnlineHost(string path)
		{
			Uri uri = new Uri(path);
			Assert.IsTrue(Network.IsHostOnline(uri, out string msg, false));
		}

		[DataRow(@"d:\temp\")]
		[DataRow(@"\\kmessanger\Prog")]
		[DataRow(@"\\kmessanger\c$\Prog")]
		[DataRow(@"\\10.2.0.93\Prog")]
		[DataRow(@"//kmessanger/Prog")]
		[DataRow(@"//kmessanger/Prog")]
		[DataTestMethod]
		public void IsPathAvailable_ReturnsTrue_For_AvailablePath(String path)
		{
			Assert.IsTrue(Network.IsPathAvailable(path,out string message, true, 300));

		}

		[DataRow(@"d+unknown:", "")]
		[DataRow(@"d:\unknown\", "")]
		[DataRow(@"a:\temp\", "")]
		[DataRow(@"z:\unknown\", "")]
		[DataRow(@"\\ntbroker.ru\i", "")]
		[DataRow(@"//kmessanger/unknown", "")]
		[DataRow(@"\\127.0.0.1\c$\unknown\", "")]
		[DataRow(@"\\google.ru\", "")]
		[DataTestMethod]
		public void IsPathAvailable_ReturnsFalse_For_WrongPath(String path, string msg)
		{
			Assert.IsFalse(Network.IsPathAvailable(path, out string message, true, 300));
			Debug.WriteLine(message);
		}

		[DataRow(@"C:\Windows\")]
		[DataRow(@"C:\Windows")]
		[DataRow(@".\Windows")]
		[DataRow(@"\\sever\path")]
		[DataRow(@"\\sever\path\")]
		[DataRow(@"//sever/path")]
		[DataRow(@"\\LOCALHOST\c$\")]
		[DataRow(@"\\10.20.0.1\path\")]
		[DataRow(@"\\127.0.0.1\c$\temp\")]
		[DataRow(@"http://www.google.com/")]
		[DataRow(@"http://128.128.128.128/")]
		[DataRow(@"http://128.128.128.128/c$/")]
		[DataTestMethod]
		public void IsPathWellFormed_ReturnsTrue_ForUri(String path)
		{
			Assert.IsTrue(Network.IsPathWellFormed(path, out string msg));
		}

		[DataRow("")]
		[DataRow(@"C:\Wi:ndows\")]
		[DataRow(@"DC:\Temp\")]
		[DataTestMethod]
		public void IsPathWellFormed_ReturnsFalse_ForLocal(String path)
		{
			Assert.IsFalse(Network.IsPathWellFormed(path, out string msg));
			Debug.WriteLine(msg);
		}
	}
}