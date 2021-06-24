using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Harmonic
{
	internal class Flog
	{
		public Flog(String file)
		{
			try
			{
				_fileInf=new FileInfo(file);
				Result=false;
				if (!FileInf.Exists)
				{
					Message="File not exists.";
					Treated=true;
				}
			}
			catch (Exception ex)
			{
				Message="File error: "+ex.Message;
				Treated=true;
			} 
		}
		private readonly FileInfo _fileInf;
		public FileInfo FileInf { get { return _fileInf; } }
		public String Message { get; set; }
		public Boolean Treated { get; set; }
		public Boolean Result { get; set; }
		public String FileName { get { return FileInf!=null? FileInf.Name : "unknown"; } }
	}
}
