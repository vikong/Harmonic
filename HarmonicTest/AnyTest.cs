using System;
using Harmonic.Subtitles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HarmonicTest
{
	internal class TestClass1
	{
		public int Prop1 { get; set; }
		public string Prop2 { get; set; }
		public DateTime Prop3 { get; }

		public TestClass1():this(DateTime.Now)
		{}
		public TestClass1(DateTime dt)
		{
			Prop3 = dt;
		}
	}
	internal class TestClass2
	{
		public int Prop { get; set; }
		public string Prop2 { get; set; }
		public DateTime Prop3 { get; set; }
	}

	[TestClass]
	public class AnyTest
	{
		[TestMethod]
		public void PropCopy()
		{
			var src = new TestClass1 {Prop1=1, Prop2="Init" };
			var dest = new TestClass2();
			
			dest.CopyProperties(src);

			Assert.AreEqual(src.Prop2,dest.Prop2);
			Assert.AreEqual(src.Prop3, dest.Prop3);
		}

		[TestMethod]
		public void PropCopy1()
		{
			var src = new TestClass1(DateTime.Now) { Prop1 = 1, Prop2 = "Init" };
			var dest = new TestClass1(src.Prop3.AddDays(1));
			
			dest.CopyProperties(src);

			Assert.AreEqual(src.Prop1, dest.Prop1);
			Assert.AreEqual(src.Prop2, dest.Prop2);
			Assert.AreNotEqual(src.Prop3, dest.Prop3);
		}

		[TestMethod]
		public void StringCompare()
		{
			var str1 = "Temp";
			var str2 = "temp";
			Assert.AreEqual(0, String.Compare(str1, str2, StringComparison.InvariantCultureIgnoreCase));
		}
	}
}
