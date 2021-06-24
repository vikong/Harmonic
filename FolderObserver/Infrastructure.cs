using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderObserver
{
	public class WordEntrance: IComparable<WordEntrance>
	{
		public Int32 Start { get; set; }
		public Int32 End { get; set; }
		public Boolean Keyword {get; set;}
		public String Word { get; set; }

		public Int32 CompareTo(WordEntrance other)
		{
			if(Start<other.Start) return -1;
			if (Start>other.Start) return 1;
			if (End<other.End) return -1;
			if (End>other.End) return 1;
			return 0;
		}

	}

	public class Infrastructure
	{
		/// <summary>
		/// Находит все вхождения ключевых слов в строку
		/// </summary>
		/// <param name="msg">Строка</param>
		/// <param name="keywords">Набор ключевых слов</param>
		/// <returns>Набор вхождений</returns>
		public static IEnumerable<WordEntrance> GetEntrance(String msg, IEnumerable<String> keywords)
		{
			List<WordEntrance> result=new List<WordEntrance>();
			Int32 startIndex;
			foreach (String word in keywords)
			{
				startIndex=0;
				do
				{
					startIndex=msg.IndexOf(word, startIndex, StringComparison.InvariantCultureIgnoreCase);
					if (startIndex>=0)
					{
						result.Add(new WordEntrance { Start=startIndex, End=startIndex+word.Length-1 });
						startIndex+=word.Length;
					}
				} while (startIndex>=0);
			}
			result.Sort();
			return result;
		}
		
		/// <summary>
		/// Разбивает строку на набор подстрок, разделенных по ключевым словам
		/// </summary>
		/// <param name="msg">Исходная строка</param>
		/// <param name="keywords">Ключевые слова</param>
		/// <returns>Строка, разделенная на подстроки</returns>
		public static IEnumerable<WordEntrance> Split(String msg, IEnumerable<String> keywords)
		{
			List<WordEntrance> result=new List<WordEntrance>();
			var entrance=GetEntrance(msg, keywords);

			if (entrance.Count()>0)
			{
				var enu=entrance.GetEnumerator();
				enu.Reset(); enu.MoveNext();
				int start=0, end, last=msg.Length-1;
				do
				{
					end=enu.Current.Start-1;
					if (start<=end)
						result.Add(new WordEntrance { Start=start, End=end, Keyword=false, Word=msg.Substring(start,end-start+1) });
					start=enu.Current.Start;
					end=FindEndOfEntrance(msg, enu);
					result.Add(new WordEntrance { Start=start, End=end, Keyword=true, Word=msg.Substring(start, end-start+1) });
					start=end+1;
				} while (enu.Current!=null);
				if (start<=last)
					result.Add(new WordEntrance { Start=start, End=last, Keyword=false, Word=msg.Substring(start, last-start+1) });
			}
			else
				result.Add(new WordEntrance { Start=0, End=msg.Length-1, Keyword=false, Word=msg });
	
			return result;
		}

		public static Int32 FindEndOfEntrance(String msg, IEnumerator<WordEntrance> enu)
		{
			int start=enu.Current.Start;
			int end;
			do
			{
				end=enu.Current.End;
				if (!enu.MoveNext())
					break;

			} while (end>=enu.Current.Start);
			
			return end;
		}

		public static Stream OpenRead(String filePath, out Encoding enc)
		{
			enc = null;
			FileStream file = new FileStream(
				filePath,
				FileMode.Open, FileAccess.Read, FileShare.Read);
			if (file.CanSeek)
			{
				byte[] bom = new byte[4]; // Get the byte-order mark, if there is one 
				file.Read(bom, 0, 4);
				file.Seek(0, System.IO.SeekOrigin.Begin);

				// Analyze the BOM
				if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) enc = Encoding.UTF7;
				else if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) enc = Encoding.UTF8;
				else if (bom[0] == 0xff && bom[1] == 0xfe) enc = Encoding.Unicode; //UTF-16LE
				else if (bom[0] == 0xfe && bom[1] == 0xff) enc =  Encoding.BigEndianUnicode; //UTF-16BE
				else if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) enc = Encoding.UTF32;
				else enc = Encoding.Default;


			}
			else
				enc = Encoding.Default; //System.Text.Encoding.ASCII;
			return file;
		}

		public static Encoding DetermineEncoding(String filePath)
		{
			using (StreamReader reader = new StreamReader(filePath, true))
			{
				reader.Peek(); 
				return reader.CurrentEncoding;
			}
		}
	}
}
