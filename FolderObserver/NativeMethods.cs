using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace FolderObserver
{
	internal class NativeMethods
	{
		public const Int32 HWND_BROADCAST = 0xffff;
		
		[DllImport("user32")]
		public static extern Int32 RegisterWindowMessage(String message);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, IntPtr lParam);
		
		[DllImport("user32")]
		public static extern Boolean PostMessage(IntPtr hwnd, Int32 msg, IntPtr wparam, IntPtr lparam);

	}
}
