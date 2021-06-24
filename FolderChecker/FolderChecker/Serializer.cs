using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace FolderChecker
{
	public static class Serializer
	{
		public static void Save<T>(String file, T item)
		{
			FileInfo fi=new FileInfo(@"Folders.tmp");
			fi.Delete();
			XmlSerializer serializer = new XmlSerializer(typeof(T));

			using (FileStream fs=fi.OpenWrite())
				serializer.Serialize(fs, item);

			if (File.Exists(file))
				File.Delete(file);
			File.Move(fi.FullName, file);
		}

		public static T Restore<T>(String file) where T: class, new()
		{
			var result=new T();
			FileInfo fi=new FileInfo(file);
			if (!fi.Exists)
				return result;
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			using (FileStream fs=fi.OpenRead())
				result=serializer.Deserialize(fs) as T;
			return result;
		}
	}
}
