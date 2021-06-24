using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Harmonic;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace HarmonicTest
{
	[TestClass]
	public class HarmonicTest
	{
		private static String tstStr="_123_";
		private static String controlStr="aa"+tstStr+"aa";
		public static Stream StreamFromString(String s)
		{
			MemoryStream stream = new MemoryStream();
			StreamWriter writer = new StreamWriter(stream);
			writer.Write(s);
			writer.Flush();
			stream.Position = 0;
			return stream;
		}

		[TestMethod]
		public void FileTest()
		{
			LexOr chk=new LexOr();
			chk.LexList.Add(new LexAnd(new Lex("999")));
			chk.SaveToFile(@"D:\_pjt\net\harmonic\Conditions\999.xml");
		}
		
		[TestMethod]
		public void Expession_Test()
		{
			LexOr chk=new LexOr();
			
			Assert.IsTrue(chk.Empty);
			Assert.AreEqual(String.Empty, chk.Expression);
			
			chk.LexList.Add(new Lex("1"));
			Assert.IsFalse(chk.Empty);
			Assert.AreEqual("'1'", chk.Expression);

			chk.LexList.Add(new Lex("2"));
			Assert.IsFalse(chk.Empty);
			Assert.AreEqual("('1' OR '2')", chk.Expression);

			chk.LexList.Add(new Lex("3"));
			Assert.IsFalse(chk.Empty);
			Assert.AreEqual("('1' OR '2' OR '3')", chk.Expression);

			chk=new LexOr();
			chk.Negation=true;
			
			chk.LexList.Add(new Lex("1"));
			Assert.IsFalse(chk.Empty);
			Assert.AreEqual("NOT '1'", chk.Expression);

			chk.LexList.Add(new Lex("2"));
			Assert.IsFalse(chk.Empty);
			Assert.AreEqual("NOT('1' OR '2')", chk.Expression);
		}

		[TestMethod]
		public void KeywordTest()
		{
			LexOr chk=new LexOr();

			String ts="1";
			chk.LexList.Add(new Lex(ts));
			Assert.AreEqual(1, chk.Keywords.Count());
			Assert.IsTrue(chk.Keywords.Contains(ts));

			ts="2";
			chk.LexList.Add(new Lex(ts));
			Assert.AreEqual(2, chk.Keywords.Count());
			Assert.IsTrue(chk.Keywords.Contains(ts));

			LexAnd chk1=new LexAnd();

			ts="1";
			chk1.LexList.Add(new Lex(ts));
			Assert.AreEqual(1, chk1.Keywords.Count());
			Assert.IsTrue(chk1.Keywords.Contains(ts));

			ts="2";
			chk1.LexList.Add(new Lex(ts));
			Assert.AreEqual(2, chk1.Keywords.Count());
			Assert.IsTrue(chk1.Keywords.Contains(ts));
		}

		[TestMethod]
		public void EntranceSearchTest()
		{
			Encoding enc=Encoding.UTF8;
			LexOr chk=new LexOr();
			chk.LexList.Add(new LexAnd(new Lex(tstStr)));

			List<String> matches;
			Int64 pos=0;

			StringBuilder sb=new StringBuilder();

			sb.AppendLine(controlStr);
			using (Stream stream=StreamFromString(sb.ToString()))
			{
				matches=EntranceChecker.Search(stream, ref pos, chk);
			}
			Assert.AreEqual(1, matches.Count);
			Assert.AreEqual(controlStr, matches[0]);

			matches=null;
			pos=0;
			sb.AppendLine("bbb");
			using (Stream stream=StreamFromString(sb.ToString()))
			{
				matches=EntranceChecker.Search(stream, ref pos, chk);
			}
			Assert.AreEqual(1, matches.Count);
			Assert.AreEqual(controlStr, matches[0]);

			matches=null;
			String buf=tstStr+"cc";
			sb.AppendLine(buf);
			using (Stream stream=StreamFromString(sb.ToString()))
			{
				matches=EntranceChecker.Search(stream, ref pos, chk);
			}
			Assert.AreEqual(1, matches.Count);
			Assert.AreEqual(buf, matches[0]);

			matches=null;
			buf="dd"+tstStr;
			sb.Append(buf.Substring(0,4));
			using (Stream stream=StreamFromString(sb.ToString()))
			{
				matches=EntranceChecker.Search(stream, ref pos, chk);
			}
			Assert.AreEqual(0, matches.Count);
			
			//sb.AppendLine(buf.Substring(4));
			//using (Stream stream=StreamFromString(sb.ToString()))
			//{
			//	matches=EntranceChecker.Search(stream, ref pos, chk);
			//}
			//Assert.AreEqual(1, matches.Count);
			
	
		}
	}
}
