using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace FolderChecker
{
	[Serializable]
	public class FolderInfo
	{
		public enum State { None, Ok, Warning, Error, Checking };

		private String path;
		private String name;
		private Boolean off;
		[NonSerialized]
		private DateTime? _lastCheck;
		[NonSerialized]
		private String _message;
		[NonSerialized]
		private State _status=State.None;

		public String Path { get { return path; } set { path=value; } }

		public String Name { get { return name; } set { name=value; } }

		public Boolean Off { get { return off; } set { off=value; } }

		[XmlIgnore]
		public DateTime? LastCheck { get { return _lastCheck; } set { _lastCheck=value; } }
		
		[XmlIgnore]
		public String Message { get { return _message; } }
		
		[XmlIgnore]
		public State Status { get { return _status; } set { _status=value; } }

		public FolderInfo Clone()
		{
			return (FolderInfo)this.MemberwiseClone();
		}
		public void RaiseError(String message, State level=State.Error)
		{
			_message=message+"\r\n ("+DateTime.Now+")";
			_status=level;
		}

		public void Ok(String message="")
		{
			_message=message+"\r\n ("+DateTime.Now+")";
			_status=State.Ok;
		}
	}
}
