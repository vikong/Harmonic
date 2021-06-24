using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Harmonic;
using FolderObserver;
using System.IO;
using System.Linq;

namespace HarmonicTest
{
	[TestClass]
	public class FilePosTest
	{
		[TestMethod]
		public void FolderCompareTest()
		{
			ObservedFolder f=new ObservedFolder();
			String testFolder=@"D:\prog\Harmonic\Files\";

			String deletedFile=testFolder+@"_000.txt";
			File.AppendAllText(deletedFile, "test");

			String increasedFile=testFolder+@"_001.txt";
			File.AppendAllText(increasedFile, "test");
			
			f.Set(testFolder);
			Assert.AreEqual(9, f.Files.Count);
			
			File.Delete(deletedFile);
			File.AppendAllText(increasedFile, "test");
			String newFile=f.Files[0].File;
			f.Files.RemoveAt(0);

			f.Compare();

			Assert.AreEqual(8, f.Files.Count);
			Assert.AreEqual(0, f.Files.Count(x=>x.File==deletedFile));
			Assert.AreEqual(1, f.Files.Count(x => x.File==newFile));
			Assert.AreEqual(2, f.Files.Count(x=>x.IsChanged()));
			Assert.AreEqual(1, f.Files.Count(x => x.IsChanged() && x.File==increasedFile));
			Assert.AreEqual(1, f.Files.Count(x => x.IsChanged() && x.File==newFile));

			File.Delete(increasedFile);
		}
	}
}
