using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmonic
{
	public class EntranceChecker
	{
		public IChecker Checker { get; private set; }
		public Encoding EncStream { get; set; }
		public Int32 MaxMatches { get; set; }
		public EntranceChecker(IChecker checker, Encoding encoding)
		{
			Checker=checker;
			EncStream=encoding;
			MaxMatches=100;
		}
		public EntranceChecker(IChecker checker)
			:this(checker, Encoding.UTF8)
		{ }

		public List<String> SearchBackground(Stream stream, ref Int64 position, BackgroundWorker worker=null)
		{
			Int64 curPos=position,
				prevPos=position;
			String line;
			List<String> res=new List<String>();
			stream.Seek(position, SeekOrigin.Begin);
			using (StreamReader reader=new StreamReader(stream, EncStream))
			{
				while ((line = reader.ReadLine()) != null)
				{
					curPos=stream.Position;
					if (Checker.Check(line))
					{
						res.Add(line);
						if (MaxMatches>0 && res.Count==MaxMatches-1)
						{
							res.Add("There are too many matches. Next matches skipped.");
							curPos=stream.Length;
							break;
						}
					}
					if (worker!=null && worker.CancellationPending)
					{
						res.Add("Cancelled.");
						break;
					}
				}
			}
			position=curPos;
			return res;
		}

		/// <summary>
		/// Ищет в потоке последовательность, начиная с указанной позиции
		/// </summary>
		/// <param name="stream">Поток для поиска</param>
		/// <param name="position">Позиция начала</param>
		/// <param name="checker">Объект, обеспечивающий поиск</param>
		/// <returns>Список строк с вхожениями</returns>
		public static List<String> Search(Stream stream, ref Int64 position, IChecker checker, Encoding enc)
		{
			Int64 curPos=position,
				prevPos=position;
			String line;
			List<String> res=new List<String>();
			stream.Seek(position, SeekOrigin.Begin);
			using (StreamReader reader=new StreamReader(stream, enc))
			{
				while ((line = reader.ReadLine()) != null)
				{
					curPos=stream.Position;
					if (checker.Check(line))
						res.Add(line);
				}
			}
			position=curPos;
			return res;
		}

		public static List<String> Search(Stream stream, ref Int64 position, IChecker checker)
		{
			return Search(stream, ref position, checker, Encoding.UTF8);
		}

	}
}
