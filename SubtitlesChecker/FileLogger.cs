using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmonic.Subtitles
{
	internal class FileLogger : ILogger
	{
		private readonly string LogFile;

		public FileLogger(String filePath)
		{
			LogFile = filePath;
		}

		public void Log(String text)
		{
			File.AppendAllText(LogFile,
				$">> {DateTime.Now}\r\n{text}\r\n\r\n");
		}
	}
}
