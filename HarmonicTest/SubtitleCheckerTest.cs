using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Harmonic.Subtitles;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace HarmonicTest
{
	[TestClass]
	public class SubtitleCheckerTest
	{
		private String[] Suffixes => new String[] { "_ru", "_en" };

		private String Suffix => "_ru";

		private String Extension => "stl";

		#region FindAbsent_Tests

		[TestMethod]
		public void FindAbsent_Equal_ReturnsEmpty()
		{
			//arrange
			const int max = 20;
			var source = new List<FilePart>(max);
			for (int i = 0; i < max; i++)
			{
				source.Add(new FilePart($"File{i}.mxf"));
			}
			Dictionary<String, FilePart> target = new Dictionary<string, FilePart>(source.Count);
			foreach (var fp in source)
			{
				var stl = new FilePart($"{Path.GetFileNameWithoutExtension(fp.FullName)}{Suffix}.{Extension}");
				target.Add(stl.FileWithExt, stl);
			}

			// act
			var actual = source.FindAbsent(Suffix, Extension, target);

			// assert
			Assert.IsTrue(actual.Count()==0);

		}

		[TestMethod]
		public void FindAbsent_ReturnsAbsent()
		{
			//arrange
			const int max = 100000;
			var source = new List<FilePart>(max);
			for (int i = 0; i < max; i++)
			{
				source.Add(new FilePart($"File{i}.mxf"));
			}
			Dictionary<String, FilePart> target = new Dictionary<string, FilePart>(source.Count);
			List<FilePart> absent = new List<FilePart>();
			int cnt = 0;
			foreach (var fp in source)
			{
				cnt++;
				var stl = new FilePart($"{Path.GetFileNameWithoutExtension(fp.FullName)}{Suffix}.{Extension}");
				if (cnt % 4 != 0) { target.Add(stl.FileWithExt, stl); }
				else { absent.Add(fp); }
			}

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			// act
			List<FilePart> actual = source.FindAbsent(Suffix, Extension, target).ToList();
			stopwatch.Stop();
			
			// assert
			Assert.IsTrue(actual.Count() > 0);
			CollectionAssert.AreEquivalent(absent, actual);
			Assert.IsTrue(stopwatch.Elapsed.TotalMilliseconds < 1000);
			Debug.WriteLine(stopwatch.Elapsed.TotalMilliseconds);
		}

		[TestMethod]
		public void FindAbsent_DifferentSuffix_ReturnsAbsent()
		{
			//arrange
			var source = new List<FilePart>()
			{
				new FilePart("File1.mxf"),
				new FilePart("File2.mxf"),
				new FilePart("File3.mxf"),
				new FilePart("File4.mxf"),
				new FilePart("File5.mxf"),
			};

			Dictionary<String, FilePart> target = new Dictionary<string, FilePart>();
			FilePart stl;
			stl=new FilePart($"File1{Suffix}.{Extension}");
			target.Add(stl.FileWithExt, stl);
			stl = new FilePart($"File2{Suffix}.{Extension}");
			target.Add(stl.FileWithExt, stl);
			//неверный суффикс
			stl = new FilePart("File3_esp.stl");
			target.Add(stl.FileWithExt, stl);
			//неверное расширение
			stl = new FilePart($"File4{Suffix}.txt");
			target.Add(stl.FileWithExt, stl);
			stl = new FilePart($"File5{Suffix}.{Extension}");
			target.Add(stl.FileWithExt, stl);
			// лишний файл
			stl = new FilePart($"File6{Suffix}.{Extension}");
			target.Add(stl.FileWithExt, stl);

			List<FilePart> absent = new List<FilePart>()
			{
				new FilePart("File3.mxf"),
				new FilePart("File4.mxf"),
			};

			// act
			List<FilePart> actual = source.FindAbsent(Suffix, Extension, target).ToList();

			// assert
			Assert.IsTrue(actual.Count() > 0);
			CollectionAssert.AreEquivalent(absent, actual);

		}

		#endregion FindAbsent_Tests

		[TestMethod]
		public void GetUnrelated_Returns_Unrelated()
		{

			List<String> source = new List<String>();
			source.Add("File1");
			source.Add("File2");

			List<String> target = new List<String>();
			target.Add("File1_ru");
			target.Add("File2_en");
			target.Add("File2_esp");
			target.Add("File3_ru");

			String[] expected = new String[] { "File2_esp", "File3_ru" };
			var actual = SubtitleChecker.GetUnrelated(source, target, Suffixes).ToList();
			CollectionAssert.AreEquivalent(expected, actual);

		}

		[TestMethod]
		public void GetUnrelated_WithEmpty_Returns_Empty()
		{
			String[] suffixes = new String[] { "_ru", "_en" };

			List<String> source = new List<String>();
			source.Add("File1");
			source.Add("File2");

			List<String> target = new List<String>();

			var actual = SubtitleChecker.GetUnrelated(source, target, suffixes).ToList();
			Assert.AreEqual(0,actual.Count());

		}

		[TestMethod]
		public void ZipFiles_CreateZip()
		{
			var ff = @"d:\_pjt\_net\harmonic\TestFolder\mxf1\file1.mxf";
			var dir = Path.GetDirectoryName(ff);
			var arc = @"d:\_pjt\_net\harmonic\TestFolder\arc.zip";
			File.Delete(arc);
			SubtitleChecker.ZipFiles(Directory.EnumerateFiles(dir), arc);
			Assert.IsTrue(File.Exists(arc));
		}

		[TestMethod]
		public void FilePart_Construct_FromString()
		{
			var ff = new FilePart(@"d:\_pjt\_net\harmonic\TestFolder\mxf1\file1.mxf");
			Assert.AreEqual(".mxf", ff.Extension);
			Assert.AreEqual(@"d:\_pjt\_net\harmonic\TestFolder\mxf1", ff.Folder);
			Assert.AreEqual("file1", ff.Name);
			Debug.WriteLine(ff.FullName);
		}

		[TestMethod]
		public void SubtitleChecker_OneSuffix_ReturnsAbsent()
		{
			String suffix = "_ru";
			String[] sourceExt = new string[] { ".mxf" };

			List<FilePart> source = new List<FilePart>();
			source.Add(new FilePart("File1.mxf"));
			source.Add(new FilePart("File2.mxf"));

			List<FilePart> target = new List<FilePart>();
			target.Add(new FilePart("File1_ru.stl"));

			FilePart[] expected = new FilePart[] { new FilePart("File2.mxf") };

			var actual = SubtitleChecker.Compare(source, sourceExt, target, suffix).ToList();

			CollectionAssert.AreEquivalent(expected, actual);

		}
		[DataTestMethod()]
		[DataRow(@"\\ntbkfs\PROG\Piramida\Krk2a\pic\borodki")]
		public void Load_Many_Files(String path)
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			IEnumerable<string> t = Directory.GetFiles(path);
			Debug.WriteLine(sw.Elapsed.TotalSeconds);
			List<FilePart> result = new List<FilePart>();
			foreach (string item in t)
			{
				result.Add(new FilePart(item));
			}
			Debug.WriteLine(sw.Elapsed.TotalSeconds);
			Assert.IsTrue(result.Count() > 0);
			sw.Stop();
		}

		[DataTestMethod()]
		[DataRow(@"\\ntbkfs\PROG\Piramida\Krk2a\pic\borodki")]
		public void Load_Many_Files_WithProgress(String path)
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			IEnumerable<string> t = Directory.EnumerateFiles(path);
			Debug.WriteLine(sw.Elapsed.TotalSeconds);
			List<FilePart> result = new List<FilePart>();
			try
			{
				foreach (string item in t)
				{
					result.Add(new FilePart(item));
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}			
			Debug.WriteLine(sw.Elapsed.TotalSeconds);
			Assert.IsTrue(result.Count() > 0);
			sw.Stop();
		}


		[TestMethod]
		public void SubtitleChecker_OneSuffix_OnManyFiles()
		{
			String suffix = "_ru";
			String[] sourceExt = new string[] { ".mxf" };

			List<FilePart> source = new List<FilePart>();
			Dictionary<String, FilePart> target = new Dictionary<String, FilePart>();
			List<FilePart> expected = new List<FilePart>();
			for (int i = 0; i < 10000; i++)
			{
				source.Add(new FilePart($"File{i}.mxf"));
				string file = $"File{i}_ru.stl";
				if (i % 10 == 0) { expected.Add(new FilePart($"File{i}.mxf")); }
				else { target.Add(file, new FilePart(file)); }
			}
			//var ttt = target.Where(t=>t.Key=="");
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			var actual = source.FindAbsent(suffix, ".stl", target).ToList();
			stopwatch.Stop();
			Debug.WriteLine(stopwatch.Elapsed.TotalSeconds);
			CollectionAssert.AreEquivalent(expected, actual);

		}

		[TestMethod]
		public void SubtitleChecker_OneSuffix_ReturnsEmpty()
		{
			String suffix = "_ru";
			String[] sourceExt = new string[] { ".mxf" };

			List<FilePart> source = new List<FilePart>();
			source.Add(new FilePart("File1.mxf"));
			source.Add(new FilePart("File2.mxf"));

			List<FilePart> target = new List<FilePart>();
			target.Add(new FilePart("File1_ru.stl"));
			target.Add(new FilePart("File2_ru.stl"));

			var actual = SubtitleChecker.Compare(source, sourceExt, target, suffix).ToList();

			Assert.AreEqual(actual.Count(), 0); 

		}

		[TestMethod]
		public void SubtitleChecker_WithString_OneSuffix_ReturnsAbsent()
		{
			String suffix = "_ru";
			String[] sourceExt = new string[] { ".mxf" };

			String[] source = new String[] { "File1.mxf" , "File2.mxf" };

			string[] target = new string[] { "File1_ru.stl" };

			FilePart[] expected = new FilePart[] { new FilePart("File2.mxf") };
			var actual = SubtitleChecker.Compare(source, sourceExt, target, suffix).ToList();

			CollectionAssert.AreEquivalent(expected, actual);

		}

	}
}
