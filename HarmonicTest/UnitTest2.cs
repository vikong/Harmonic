using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FolderObserver;
using System.Linq;
using System.Collections.Generic;

namespace HarmonicTest
{
	[TestClass]
	public class UnitTest2
	{
		[TestMethod]
		public void EntranceTest()
		{
			String msg="*123*567*";
			var res = Infrastructure.GetEntrance(msg, new String[] { "567" });
			Assert.AreEqual(1,res.Count());
			var num=res.GetEnumerator();
			num.Reset();
			num.MoveNext();
			Assert.AreEqual(5, num.Current.Start);
			Assert.AreEqual(7, num.Current.End);

			res = Infrastructure.GetEntrance(msg, new String[] { "567", "123" });
			Assert.AreEqual(2, res.Count());
			Assert.AreEqual(1, res.Count(e=>e.Start==5 && e.End==7 ));
			Assert.AreEqual(1, res.Count(e=>e.Start==1 && e.End==3 ));

			msg="_123_123_";
			res = Infrastructure.GetEntrance(msg, new String[] { "567", "123" });
			Assert.AreEqual(2, res.Count());
			Assert.AreEqual(1, res.Count(e => e.Start==5 && e.End==7));
			Assert.AreEqual(1, res.Count(e => e.Start==1 && e.End==3));

		}
		[TestMethod]
		public void FindEndOfEntrance_Test()
		{
			String msg="0123456789abcd";
			
			var res = Infrastructure.GetEntrance(msg, new String[] { "123" });
			var num=res.GetEnumerator();
			num.Reset(); num.MoveNext();
			Assert.AreEqual(3, Infrastructure.FindEndOfEntrance(msg,num));

			res = Infrastructure.GetEntrance(msg, new String[] { "12", "23" });
			num=res.GetEnumerator();
			num.Reset(); num.MoveNext();
			Assert.AreEqual(3, Infrastructure.FindEndOfEntrance(msg, num));

			res = Infrastructure.GetEntrance(msg, new String[] { "123", "234" });
			num=res.GetEnumerator();
			num.Reset(); num.MoveNext();
			Assert.AreEqual(4, Infrastructure.FindEndOfEntrance(msg, num));
			Assert.IsNull(num.Current);

			res = Infrastructure.GetEntrance(msg, new String[] { "123", "234", "45" });
			num=res.GetEnumerator();
			num.Reset(); num.MoveNext();
			Assert.AreEqual(5, Infrastructure.FindEndOfEntrance(msg, num));

			res = Infrastructure.GetEntrance(msg, new String[] { "123", "234", "67" });
			num=res.GetEnumerator();
			num.Reset(); num.MoveNext();
			Assert.AreEqual(4, Infrastructure.FindEndOfEntrance(msg, num));
			Assert.AreEqual(6, num.Current.Start);
			Assert.AreEqual(7, num.Current.End);
		}

		[TestMethod]
		public void Split_Test()
		{
			String msg="0123456789abc";

			IEnumerable<WordEntrance> res;
			IEnumerator<WordEntrance> num;

			res=Infrastructure.Split(msg, new String[] { "***" });
			Assert.AreEqual(1, res.Count());
	
			res=Infrastructure.Split(msg, new String[]{"345"});
			Assert.AreEqual(3, res.Count());
			
			num=res.GetEnumerator();
			num.Reset(); 
			num.MoveNext();
			Assert.AreEqual("012", num.Current.Word);
			Assert.IsFalse(num.Current.Keyword);
			
			num.MoveNext();
			Assert.AreEqual("345", num.Current.Word);
			Assert.IsTrue(num.Current.Keyword);

			num.MoveNext();
			Assert.AreEqual("6789abc", num.Current.Word);
			Assert.IsFalse(num.Current.Keyword);

			num=null;
			//--------------
			res=Infrastructure.Split(msg, new String[] { "345","456","67", "ab" });
			Assert.AreEqual(5, res.Count());

			num=res.GetEnumerator();
			num.Reset();
			num.MoveNext();
			Assert.AreEqual("012", num.Current.Word);
			Assert.IsFalse(num.Current.Keyword);
			
			num.MoveNext();
			Assert.AreEqual("34567", num.Current.Word);
			Assert.IsTrue(num.Current.Keyword);

			num.MoveNext();
			Assert.AreEqual("89", num.Current.Word);
			Assert.IsFalse(num.Current.Keyword);

			num.MoveNext();
			Assert.AreEqual("ab", num.Current.Word);
			Assert.IsTrue(num.Current.Keyword);
			
			num.MoveNext();
			Assert.AreEqual("c", num.Current.Word);
			Assert.IsFalse(num.Current.Keyword);

			num=null;

			//--------------
			res=Infrastructure.Split(msg, new String[] { "012", "567", "bc" });
			Assert.AreEqual(5, res.Count());

			num=res.GetEnumerator();
			num.Reset();
			num.MoveNext();
			Assert.AreEqual("012", num.Current.Word);
			Assert.IsTrue(num.Current.Keyword);

			num.MoveNext();
			Assert.AreEqual("34", num.Current.Word);
			Assert.IsFalse(num.Current.Keyword);

			num.MoveNext();
			Assert.AreEqual("567", num.Current.Word);
			Assert.IsTrue(num.Current.Keyword);

			num.MoveNext();
			Assert.AreEqual("89a", num.Current.Word);
			Assert.IsFalse(num.Current.Keyword);

			num.MoveNext();
			Assert.AreEqual("bc", num.Current.Word);
			Assert.IsTrue(num.Current.Keyword);

			num=null;
		}
		[TestMethod]
		public void Enc_Test()
		{
			var enc=Infrastructure.DetermineEncoding(@"D:\prog\Harmonic\Files\log orig.log");
		}
	}
}
