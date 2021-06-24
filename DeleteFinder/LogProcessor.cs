#define _lexChecker
using System.IO;
using System.IO.Compression;
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Harmonic
{
	class MdMatch
	{
		public String Source { get; set; }
		public Int32 StrNo { get; set; }
		public String SessionId { get; set; }
		public String Info { get; set; }
		public String Time { get; set; }
		public override string ToString()
		{
			return String.Format("({0}->{1}):\t{2}", Source, StrNo.ToString(), Info);
		}
	}

	class LogProcessor
	{
		/// <summary>
		/// требование остановки обработки
		/// </summary>
		public Boolean Cancellation { get; set; }
		
		/// <summary>
		/// признак наличия активного процесса обработки
		/// </summary>
		public Boolean Busy { get; private set; }

		/// <summary>
		/// обрабатываемый файл
		/// </summary>
		public FileInfo TreatingFile { get; private set; }
		
		/// <summary>
		/// количество найденных вхождений
		/// </summary>
		public Int32 MatchCount { get; private set; }
		
		/// <summary>
		/// текущее положение в обрабатываемом файле
		/// </summary>
		public Int64 Position
		{
			get { return _position; }
			private set 
			{ 
				if (_position!=value) 
				{ 
					onProgressUp(this, new ProgressEventArgs { Length=this.Length, Position=this.Position }); _position=value; 
				} 
			}
		}
		private Int64 _position;

		/// <summary>
		/// длина обрабатываемого файла в байтах
		/// </summary>
		public Int64 Length { get; private set; }
		
		/// <summary>
		/// Представляет метод для проверки строки на выполнение условий
		/// </summary>
		public ILex Checker
		{
			get { return _cheker; }
			set { if (!Busy) _cheker=value; }
		}
		private ILex _cheker;

		/// <summary>
		/// длина подстроки для сортировки
		/// </summary>
		private readonly Int32 TimeLength;

		/// <summary>
		/// размер буфера для декомпрессии
		/// </summary>
		public const int BuffSize = 1024;
		public Dictionary<String, MdMatch> Sessions { get; private set; }
		public List<MdMatch> MatchLines { get; private set; }

		private readonly String NewSessionMark;
		private readonly String SessionAddressMark;
		private readonly String SessionIdMark;
		private readonly String PathMark;
		/// <summary>
		/// разархивация сжатого gzip файла
		/// </summary>
		/// <param name="fi"></param>
		public static void Decompress(FileInfo fi)
		{
			using (FileStream inFile = fi.OpenRead())
			{
				string curFile = fi.FullName;
				string origName = curFile.Remove(curFile.Length - 
                		fi.Extension.Length);

				using (FileStream outFile = File.Create(origName))
				{
					using (GZipStream Decompress = new GZipStream(inFile, CompressionMode.Decompress))
					{
						Decompress.CopyTo(outFile);
					}
				}
			}
		}

		public LogProcessor(ILex checker=null)
		{
			Sessions=new Dictionary<String, MdMatch>();
			MatchLines=new  List<MdMatch>();
			Checker=checker;

			NewSessionMark="new session ";
			SessionAddressMark="from ";
			SessionIdMark="sesid=";
			PathMark="path=";
			TimeLength=23;
		}
		public void Drop()
		{
			Sessions.Clear(); 
			MatchLines.Clear();
		}
		public class ProgressEventArgs : EventArgs
		{
			public Int64 Length;
			public Int64 Position;
		}
		public event EventHandler<ProgressEventArgs> ProgressUp;
		private void onProgressUp(object sender, ProgressEventArgs e)
		{
			if (ProgressUp != null) ProgressUp(sender, e);
		}


		public class ResultEventArgs : EventArgs
		{
			public Boolean Result { get; set; }
			public String Message { get; set; }
			public FileInfo File { get; set; }
		}
		public event EventHandler<ResultEventArgs> Comleted;
		private void onCompleted(object sender, ResultEventArgs result)
		{
			Busy=false;
			if (Comleted!=null) Comleted(this, result);
		}

		private void CheckMatches(String str, Int32 strNo)
		{
			MdMatch match = GetSession(str);
			if (match!=null)
			{
				if (!Sessions.ContainsKey(match.SessionId))
					Sessions.Add(match.SessionId, match);
				return;
			}

			match=GetMatch(str);
			if (match!=null)
			{
				match.StrNo=strNo;
				match.Source=TreatingFile.Name;
				MatchLines.Add(match);
				MatchCount++;
			}
			return;
		}
		public MdMatch GetSession(String str)
		{
			int sessionPos=str.IndexOf(NewSessionMark);
			if (sessionPos<0)
				return null;
			sessionPos+=NewSessionMark.Length;
			if (str.Substring(sessionPos, 2)=="0x")
				sessionPos+=2;
			int sessionEnd=str.IndexOf(SessionAddressMark, sessionPos+1);
			return new MdMatch
			{
				SessionId=str.Substring(sessionPos, sessionEnd-sessionPos).Trim(),
				Info=str,
				Time=GetTime(str)
			};
		}

		public MdMatch GetMatch(String str)
		{
			MdMatch result=null;
#if _lexChecker
			if (Checker.Check(str))
				result=new MdMatch { SessionId=GetSessionId(str), Info=str, Time=GetTime(str) };
#else
			foreach (ILex lex in Conditions)
			{
				if (lex.Check(str))
					result=new MdMatch { SessionId=GetSessionId(str), Info=str, Time=GetTime(str) };
			}
#endif
			return result;
		}
		public String GetTime(String str)
		{
			return str.Substring(0, Math.Min(TimeLength,str.Length));
			//DateTime sessionTime;
			//DateTime.TryParseExact(str.Substring(0, dtFormatString.Length), dtFormatString, dtFormatInfo, DateTimeStyles.None, out sessionTime);
			//sessionTime=new DateTime();
			//return sessionTime;
		}

		public String GetSessionId(String str)
		{
			int begPos=str.IndexOf(SessionIdMark);
			if (begPos<0)
				return null;
			begPos+=SessionIdMark.Length;
			int endPos=str.IndexOf(',', begPos+1);
			if (endPos>0)
			{
				String sessId=str.Substring(begPos, endPos-begPos);
				return sessId;
			}
			else return "unknown";
		}
		//private Boolean CheckForKeywords(String str)
		//{
		//	String sessionId=GetNewSessionId(str);
		//	if (sessionId!=null)
		//	{
		//		SessionsLines.Add(sessionId, str);
		//		return false;
		//	}
		//	MdMatch match=GetMatch(str);
		//	if(match!=null)
		//	{
		//		MatchLines.Add(match);
		//		LastMatch=match;
		//		return true;
		//	}

		//	return false;
		//}

		//public String GetNewSessionId(String str)
		//{
		//	int sessionPos=str.IndexOf(NewSessionMark);
		//	if (sessionPos<0)
		//		return null;
		//	sessionPos+=NewSessionMark.Length;
		//	int sessionEnd=str.IndexOf(SessionAddressMark,sessionPos+1);
		//	return str.Substring(sessionPos, sessionEnd-sessionPos).Trim();
		//}

		//public MdMatch GetMatch(String str)
		//{
		//	if (!str.Contains(Keyword1))
		//		return null;

		//	if (!prevAdded)
		//	{
		//		if (Keyword2==null || (Keyword2!=null && str.Contains(Keyword2)))
		//		{
		//			MdMatch result=new MdMatch();
		//			result.Info=str;
		//			result.SessionId=GetSessionString(str);
		//			return result;
		//		}
		//		else
		//			return null;

		//	}
		//	else
		//	{
		//		LastMatch.Result=str;
		//		return null;
		//	}

		//}
		//public MdMatch ParseForSession(String str)
		//{
		//	int sessionPos=str.IndexOf(NewSessionMark);
		//	if (sessionPos<0)
		//		return null;
			
		//	DateTime sessionTime;
		//	DateTime.TryParseExact(str.Substring(0,dtFormatString.Length), dtFormatString, dtFormatInfo, DateTimeStyles.None, out sessionTime);
		//	sessionPos+=NewSessionMark.Length;
		//	int addrPos=str.IndexOf(SessionAddressMark);
		//	int addrEnd=str.IndexOf(' ', addrPos+SessionAddressMark.Length+1);
		//	if (addrEnd<0)
		//		addrEnd=str.Length;
		//	MdMatch result = new MdMatch 
		//	{
		//		Id=str.Substring(sessionPos, addrPos-sessionPos).Trim(), 
		//		Creation=sessionTime,
		//		Info=str.Substring(addrPos+SessionAddressMark.Length, addrEnd-addrPos-SessionAddressMark.Length)
		//	};
			
		//	return result;
		//}

		public void ParseFile(FileInfo source)
		{
			Busy=true;
			
			Cancellation=false;
			Length=Position=0;
			MatchCount=0;

			TreatingFile=source;
#if _lexChecker
			if (Checker==null || Checker.Empty)
			{
				//Message="No conditions";
				onCompleted(this, new ResultEventArgs { Result=false, Message="No conditions", File=TreatingFile });
				return;
			}
#else
			if (Conditions.Count==0)
			{
				Message="No conditions";
				onCompleted(this, new ResultEventArgs { Result=false, Message=this.Message });
			}
#endif
			try
			{
				Boolean archived=false;
				using (FileStream inFile = source.OpenRead())
				{
					Length=inFile.Length;
					using (GZipStream decompress = new GZipStream(inFile, CompressionMode.Decompress))
					{
						try
						{
							ParseLines(decompress, inFile);
							archived=true;
						}
						catch (InvalidDataException ex)
						{
							archived=false;
						}
					}
				}

				if (!archived)
				{
					using (FileStream inFile = source.OpenRead())
					{
						ParseLines(inFile, inFile);
					}
				}

			}
			catch (Exception ex)
			{
				onCompleted(this, new ResultEventArgs { Result=false, Message=String.Format("Error: {0}", ex.Message), File=TreatingFile });
				return;
			} 

			if (Cancellation)
			{
				onCompleted(this, new ResultEventArgs { Result=false, Message=String.Format("Has been cancelled by user at {0}. {1} matches is found.", DateTime.Now.ToShortTimeString(), MatchCount.ToString() ), File=TreatingFile });
				return;
			}
			
			Position=Length;
			onCompleted(this, new ResultEventArgs { Result=true, Message=String.Format("Has been treated at {0}. {1} matches is found.", DateTime.Now.ToShortTimeString(), MatchCount.ToString() ), File=TreatingFile });
		}
		private void ParseLines(Stream readStream, Stream sourceStream)
		{
			StreamReader reader=new StreamReader(readStream);
			int strNo=0;
			String line;
			while ((line = reader.ReadLine()) != null)
			{
				Position=sourceStream.Position;
				CheckMatches(line, strNo++);
				if(Cancellation)
				{
					break;
				}
			}
		}
		public void ParseFile1(FileInfo source)
		{
			Encoding enc = Encoding.UTF8;
			String str;
			StringBuilder sb=new StringBuilder();
			Boolean longString;
			Byte[] buffer=new Byte[BuffSize];
			Stream srcStream;
			int readed, start, end, endBuff, i, strNo;
			
			using (FileStream inFile = source.OpenRead())
			{
				using (GZipStream Decompress = new GZipStream(inFile, CompressionMode.Decompress))
				{
					try
					{
						readed=Decompress.Read(buffer, 0, BuffSize);
						srcStream=Decompress;
					}
					catch (InvalidDataException ex)
					{
						inFile.Seek(0, SeekOrigin.Begin);
						readed=inFile.Read(buffer, 0, BuffSize);
						srcStream=inFile;
					}
					endBuff=readed-1;
					end=0; start=0; 
					longString=false;
					strNo=1;
					while (readed>0)
					{
						// ищем перенос строки
						while(end<=endBuff)
						{
							if (buffer[end]!=10)
								end++;
							else
							{
								str=enc.GetString(buffer,start,end-start);
								if (!longString)
									CheckMatches(str, strNo++);
								else
								{
									sb.Append(str);
									CheckMatches(sb.ToString(), strNo++);
									sb.Clear();
									longString=false;
								}
								start = ++end;
							}
						}// while(end<=endBuff)

						// копируем остаток в начало буфера
						i=0;
						if (start>0)
							while (start<end)
								buffer[i++]=buffer[start++];
						else
						{
							longString=true;
							str=enc.GetString(buffer);
							sb.Append(str);
						}

						//debug
						//for (int j=i; j<BuffSize; j++) buffer[j]=0;
						
						// закачиваем новую порцию
						readed=srcStream.Read(buffer, i, BuffSize-i);
						endBuff=i+readed-1;
						start=0; end=i;

					}// while (readed>0)
					// обработаем остаток
					str=enc.GetString(buffer, start, endBuff+1);
					if (!longString)
						CheckMatches(str, strNo++);
					else
					{
						sb.Append(str);
						CheckMatches(sb.ToString(), strNo++);
						sb.Clear();
					}
					
				}
			}
		}

	}
}
