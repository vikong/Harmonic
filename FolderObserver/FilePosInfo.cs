using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FolderObserver
{
	[Serializable()]
	public class FilePosInfo
	{
		private Int64 _pos;
		/// <summary>
		/// Смещение, на котором завершили проверку
		/// </summary>
		public Int64 Pos { get { return _pos; } set { _pos=value; } }

		private Int64 _flen;
		/// <summary>
		/// Детектированный размер
		/// </summary>
		[XmlIgnore]
		public Int64 FLen { get { return _flen; } internal set { _flen=value; } }

		public Boolean IsChanged() { return (_pos!=_flen); }
		
		private String _file;
		public String File 
		{ 
			get { return _file; }
			set { _file=value; } 
		}

		[Obsolete("Для сериализации",true)]
		public FilePosInfo() { _pos=_flen=0; }
		public FilePosInfo(FileInfo fi, Boolean checkAnew=true)
		{
			_pos=checkAnew? 0 : fi.Length;
			_flen=fi.Length;
			_file=fi.FullName;
		}

		public override string ToString()
		{
			return _file;
		}

	}

	[Serializable()]
	[XmlRoot(ObservedFolder.SerializationName)]
	public class ObservedFolder
	{
		public const String SerializationName="Folder";

		[NonSerialized]
		[XmlIgnore]
		private readonly List<FilePosInfo> _files=new List<FilePosInfo>();

		public List<FilePosInfo> Files { get { return _files; } }
		
		[NonSerialized]
		[XmlIgnore]
		private String _path;
		public String Path { get { return _path; } set { _path=value; } }

		public ObservedFolder() { }
		public ObservedFolder(String path)
		{
			_path=path;
		}

		public void LoadCheckInfo(String file)
		{
			try
			{
				if (File.Exists(file))
				{
					var checkedList=Serializer.Restore<List<FilePosInfo>>(file);
					Files.AddRange(checkedList);
				}
			}
			catch (Exception)
			{ ;} 
		}
		public void SaveCheckInfo(String file)
		{
			String bufFile=System.IO.Path.ChangeExtension(file,"tmp");
			Serializer.Save<List<FilePosInfo>>(bufFile, Files);
			System.IO.File.Delete(file);
			System.IO.File.Move(bufFile, file);
		}

		public void Set()
		{
			Set(Path, true);
		}
		public void Set(String path, Boolean checkAnew=true)
		{
			DirectoryInfo dir=new DirectoryInfo(path);
			var filesInDir=dir.GetFiles();
			Files.Clear();
			foreach(FileInfo fi in filesInDir)
			{
				Files.Add(new FilePosInfo(fi, checkAnew));
			}
			_path=path;
		}

		/// <summary>
		/// Сбрасывает начало проверки на начало файла
		/// </summary>
		public void Reset()
		{
			_files.ForEach(f => f.Pos=0);
		}
		/// <summary>
		/// Сравнивает текущее состояние папки с сохраненными.
		/// Новые файлы добавляет. Те, которые есть в списке, но нет в папке, удаляет. 
		/// Для существующих сравнивает размеры.
		/// </summary>
		public void Compare()
		{
			DirectoryInfo dir=new DirectoryInfo(Path);
			var fList=dir.GetFiles();
			
			// удалим старые
			Files.RemoveAll(f => fList.Count(x => x.FullName==f.File)==0);

			// сверим размер и добавим новые
			foreach (FileInfo fi in fList)
			{
				var last=Files.FirstOrDefault(f => f.File==fi.FullName);
				if (last!=null)
					last.FLen=fi.Length;
				else
					Files.Add(new FilePosInfo(fi));
			}
		}

		public IEnumerable<FilePosInfo> GetChanged()
		{
			return Files.Where(f => f.IsChanged());
		}
	}
}
