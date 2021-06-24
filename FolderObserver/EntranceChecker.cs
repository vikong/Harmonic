using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmonic
{
	public class EntranceChecker
	{
		private static readonly Encoding enc=Encoding.UTF8;
		public static List<String> Search(Stream stream, ref Int64 position, IChecker checker)
		{
			Int64 curPos=position,
				prevPos=position;
			String line;
			List<String> res=new List<String>();
			stream.Seek(position, SeekOrigin.Begin);
			using (StreamReader reader=new StreamReader(stream))
			{
				while ((line = reader.ReadLine()) != null)
				{
					//prevPos=curPos;
					curPos=stream.Position;
					if (checker.Check(line))
						res.Add(line);
				}
			}
			position=curPos;
			return res;
		}
	}
}
