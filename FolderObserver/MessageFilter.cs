using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FolderObserver
{
	//[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
	public class MessageFilter : IMessageFilter
	{
		private Int32 _hMsg;
		private String _message;

		public Int32 hMsg { get { return _hMsg; } }
		public String Message { get { return _message; } }

		public MessageFilter() {}
		public MessageFilter(String message) 
		{
			Register(message, null);
		}
		public MessageFilter(String message, EventHandler handler)
		{
			Register(message, handler);
		}
		public MessageFilter(Int32 wm_Message) : this(wm_Message, null) { }
		public MessageFilter(Int32 wm_Message, EventHandler handler)
		{
			_hMsg=wm_Message;
			_message=wm_Message.ToString();
			MessageEvent=handler;
		}

		//public delegate void MessageHandler(Object sender, EventArgs e);

		public event EventHandler MessageEvent;

		protected virtual void RaiseMessageEvent()
		{
			if (MessageEvent==null)
				return;
			MessageEvent(this, new EventArgs());
		}

		public void Register(String message, EventHandler handler)
		{
			_message=message;
			_hMsg=NativeMethods.RegisterWindowMessage(message);
			MessageEvent=handler;
		}

		public Boolean PreFilterMessage(ref Message m)
		{
			if (m.Msg != _hMsg)
				return false;

			RaiseMessageEvent();
			return true;
		}

	}
}
