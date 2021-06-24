using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmonic.Subtitles
{
	public struct Result
	{
		public Boolean Success;
		public String Note;
		public Result(Boolean success, String note=null)
		{
			Success = success;
			Note = note;
		}
	}

	public struct FilePart
	{
		public String Name;
		public String Extension;
		public String Folder;

		public FilePart(FileInfo fileInfo)
		{
			Name = Path.GetFileNameWithoutExtension(fileInfo.Name);
			Extension = fileInfo.Extension;
			Folder = fileInfo.DirectoryName;
		}
		public FilePart(String file)
		{
			Name = Path.GetFileNameWithoutExtension(file);
			Extension = Path.GetExtension(file);
			Folder = Path.GetDirectoryName(file);
		}

		public String FullName => Path.Combine(Folder, FileWithExt);
		public String FileWithExt => Name + Extension;

		public override string ToString() => FullName;
	}

	public static class SubtitleChecker
	{
		public static IEnumerable<FilePart> Compare(IEnumerable<FilePart> source, IEnumerable<String> sourceExt, IEnumerable<FilePart> target, String suffix)
		{
			return source
				.Where(f => sourceExt.Contains(f.Extension))
				.Where(f => !target.Any(t => t.Name == f.Name + suffix));
		}

		public static IReadOnlyCollection<FilePart> FindAbsent(this IEnumerable<FilePart> source, String suffix, String extension, Dictionary<String, FilePart> target)
		{
			List<FilePart> result = new List<FilePart>();

			string ext = $"{suffix}.{extension}";
			foreach (var fp in source)
			{
				if (!target.ContainsKey(fp.Name + ext))
				{
					result.Add(fp);
				}
			}

			return result.AsReadOnly();
		}

		public static IEnumerable<FilePart> Compare(IEnumerable<String> source, IEnumerable<String> sourceExt, IEnumerable<String> target, String suffix)
			=> Compare(source.Select(s => new FilePart(s)), sourceExt, target.Select(t => new FilePart(t)), suffix);

		public static IEnumerable<String> GetUnrelated(IEnumerable<String> source, IEnumerable<String> target, IEnumerable<String> suffixes)
			=> target.Except(
				source.SelectMany(f => suffixes, (f, s) => f + s).ToArray() //cross join
				);

		public static void ZipFiles(IEnumerable<String> source, String target)
		{
			if (!source.Any())
				return;
			//https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-compress-and-extract-files
			using (FileStream compressedFileStream = File.Create(target))
			{
				using (ZipArchive archive = new ZipArchive(compressedFileStream, ZipArchiveMode.Create))
				{
					foreach (string fileName in source)
					{
						archive.CreateEntryFromFile(Path.GetFullPath(fileName), Path.GetFileName(fileName));
					}
				}
			}
		}
		//using (Stream zipStream = entry.Open())
		//using (FileStream fileStream = new FileStream(...))
		//{
		//    await zipStream.CopyToAsync(fileStream);
		//}

		public static void ZipFiles(String sourceDir, IEnumerable<String> source, String ext, String target)
				=> ZipFiles(source.Select(f => Path.Combine(sourceDir, f + ext)), target);

		//private static async void ZipClick()
		//{
		//	FileSavePicker picker = new FileSavePicker();
		//	picker.FileTypeChoices.Add("Zip Files (*.zip)", new List<string> { ".zip" });
		//	picker.SuggestedStartLocation = PickerLocationId.Desktop;
		//	picker.SuggestedFileName = "1";
		//	zipFile = await picker.PickSaveFileAsync();

		//	using (var zipStream = await zipFile.OpenStreamForWriteAsync())
		//	{
		//		using (ZipArchive zip = new ZipArchive(zipStream, ZipArchiveMode.Create))
		//		{
		//			foreach (var file in storeFile)
		//			{
		//				ZipArchiveEntry entry = zip.CreateEntry(file.Name);

		//				using (Stream ZipFile = entry.Open())
		//				{
		//					byte[] data = await GetByteFromFile(file);
		//					ZipFile.Write(data, 0, data.Length);
		//				}
		//			}
		//		}
		//	}
		//}
		//https://www.codeproject.com/Tips/515704/Archive-Multiple-Files-In-Zip-Extract-Zip-Archive
		// This is the method to convert the StorageFile to a Byte[]       
		//private async Task<byte[]> GetByteFromFile(StorageFile storageFile)
		//{
		//	var stream = await storageFile.OpenReadAsync();

		//	using (var dataReader = new DataReader(stream))
		//	{
		//		var bytes = new byte[stream.Size];
		//		await dataReader.LoadAsync((uint)stream.Size);
		//		dataReader.ReadBytes(bytes);

		//		return bytes;
		//	}
		//}
		//public static IEnumerable<FilePart> Compare(IEnumerable<FilePart> source, IEnumerable<FilePart> target, String[] suffixes) 
		//	=> suffixes.SelectMany(s=>Compare(source,target,s));

		//public static IEnumerable<FilePart> Compare(IEnumerable<String> source, IEnumerable<String> target, String[] suffixes)
		//	=> Compare(source.Select(s => new FilePart(s)), target.Select(t => new FilePart(t)), suffixes);
	}
}
