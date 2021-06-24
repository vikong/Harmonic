using System;

namespace Harmonic.Subtitles
{
	[Serializable]
	public class FolderInfo
	{
		public String SourceFolder { get; set; }

		public String TargetFolder { get; set; }

		public String Name { get; set; }

		public Boolean Off { get; set; }

		public String Suffixes { get; set; }

		public String TemplateFile { get; set; }

		public String LogFileAdded { get { return LegalFileName + "_added.txt"; } }
		public String LogFileCleared { get { return LegalFileName + "_cleared.txt"; } }
		private String LegalFileName {
			get
			{
				String fileName = Name.Trim();
				foreach (char c in System.IO.Path.GetInvalidFileNameChars())
				{
					fileName = fileName.Replace(c, '_');
				}
				return fileName;
			} 
		}

		public FolderInfo Clone()
		{
			return (FolderInfo)this.MemberwiseClone();
		}
	}
}