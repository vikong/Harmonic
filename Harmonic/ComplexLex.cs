using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace Harmonic
{
	public class LexType
	{
		public const String And="AND";
		public const String Or="OR";
	}
	
	[Serializable]
	[XmlRoot(ComplexLex.SerializationName)]
	public class ComplexLex: 
		ILex, IChecker 
	{
		public const String SerializationName="Condition";
		private String _type;

		public String Tag { get; set; }
		[XmlIgnore]

		public String Type 
		{ 
			get { return _type; }
			set
			{
				IChecker chk;
				switch (value)
				{
					case LexType.And:
						chk=new AndChecker { LexList=this.LexList };
						break;
					
					case LexType.Or:
						chk=new OrChecker { LexList=this.LexList };
						break;
					
					default:
						throw new ArgumentException("Unknown type of concatenation");
				}
				Cheker=chk;
				_type=value;
			}
		}//Type

		public Boolean Negation { get; set; }

		[XmlIgnore]
		public List<ILex> LexList { get; private set; }
		
		private IChecker Cheker { get; set; }

		[XmlIgnore]
		public String Expression { get { return this.ToString(); } }

		[XmlIgnore]
		public Boolean Empty { get { return LexList.Count(item=>!item.Empty)==0; } }

		#region Конструкторы
		public ComplexLex()
		{
			LexList=new List<ILex>();
			Type=LexType.Or;
		}
		public ComplexLex(String lexType)
			: this()
		{
			Type=lexType;
		}
		public ComplexLex(String lexType, Int32 count)
			: this(lexType)
		{
			for (int i=1; i<=count; i++)
				LexList.Add(new Lex("substring"+i.ToString()));
		}

		public ComplexLex(params ILex[] args)
			: this(LexType.And)
		{
			LexList.AddRange(args);
		}
		public ComplexLex(String lexType, params ILex[] args)
			: this(lexType)
		{
			LexList.AddRange(args);
		}
		#endregion Конструкторы

		/// <summary>
		/// Проверяет соответствие строки условию
		/// </summary>
		/// <param name="str">проверяемая строка</param>
		/// <returns>соответствие условию</returns>
		public virtual Boolean Check(String str)
		{
			return !Negation? 
				Cheker.Check(str)
				:
				!Cheker.Check(str);
		}

		/// <summary>
		/// Удаляет пустые условия
		/// </summary>
		public virtual void RemoveEmpty()
		{
			for (int i=LexList.Count-1; i>=0; i--)
			{
				if (LexList[i].Empty)
					LexList.RemoveAt(i);
			}

		}

		public override String ToString()
		{
			var lexList=LexList.Where(l => !l.Empty);
			var cnt=lexList.Count();
			
			if (cnt==0)
				return "";
			
			if (cnt==1)
				return String.Format("{0}{1}", (Negation? "NOT " : ""), lexList.FirstOrDefault().Expression);

			int i=1;
			StringBuilder sb = new StringBuilder(String.Format("{0}(", Negation? "NOT" : ""));
			foreach (var lex in lexList)
			{
				sb.Append(lex.Expression);
				if (i<cnt)
					sb.AppendFormat(" {0} ", this.Type);
				i++;
			}
			sb.Append(")");
	
			return sb.ToString();
		}
		
		[XmlIgnore]
		public IEnumerable<String> Keywords
		{
			get
			{
				List<String> result=new List<String>();
				LexList.ForEach(
					lex=>result.AddRange(lex.Keywords)
				);
				return result;
			}
		}

		#region load
		public static ComplexLex LoadFromFile(String fileName)
		{
			FileInfo fi=new FileInfo(fileName);
			using (FileStream fs=fi.OpenRead())
			{
				return ComplexLex.Load(fs); 
			}
		}

		public static ComplexLex Load(Stream stream)
		{
			XmlSerializer ser = new XmlSerializer(typeof(ComplexLex));
			ComplexLex res=ser.Deserialize(stream) as ComplexLex;
			return res;
		}

		public void SaveToFile(String file)
		{
			String tmp=Path.GetTempFileName();
			try
			{
				using (FileStream fs=File.OpenWrite(tmp))
				{
					Save(fs);
				}
				String bakFile=Path.ChangeExtension(file, "bak");
				if (File.Exists(file))
				{
					File.Delete(bakFile);
					File.Move(file, bakFile);
				}
				File.Move(tmp,file);
			}
			catch (Exception ex)
			{
				throw new Exception("Не удалось сохранить условия.\r\n"+ex.Message);
			}
			finally
			{
				File.Delete(tmp);
			}
		}

		public void Save(Stream stream)
		{
			XmlSerializer ser = new XmlSerializer(typeof(ComplexLex));
			ser.Serialize(stream, this);
		}
		
		#endregion load

		#region Члены IXmlSerializable
		//-----------------------------
		public System.Xml.Schema.XmlSchema GetSchema()
		{
			return null;
		}

		public void ReadXml(XmlReader reader)
		{
			Type=reader.GetAttribute("type");
			Tag=reader.GetAttribute("tag");
			Boolean neg;
			if (Boolean.TryParse(reader.GetAttribute("negation"), out neg)) Negation=neg;
			// читаем вложенные условия
			reader.Read();
			int depth=reader.Depth;
			while (reader.Depth==depth)
			{
				Type lexType;
				String name=reader.Name;
				String type=reader.GetAttribute("type");
				if (name==ComplexLex.SerializationName)
				{
					lexType=typeof(ComplexLex);
					XmlSerializer ser=new XmlSerializer(lexType);
					ILex obj=ser.Deserialize(reader) as ILex;
					LexList.Add(obj);
					reader.Read();

				}
				else if (name==Lex.SerializationName)
				{
					lexType=typeof(Lex);
					XmlSerializer ser=new XmlSerializer(lexType);
					ILex obj=ser.Deserialize(reader) as ILex;
					LexList.Add(obj);
				}

				else
					throw new FormatException("Unknown type of condition.");

			}
		}

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteAttributeString("type", this.Type);
			if (Negation)
				writer.WriteAttributeString("negation", this.Negation.ToString());
			if (!String.IsNullOrWhiteSpace(this.Tag))
				writer.WriteAttributeString("tag", this.Tag);
			foreach (ILex l in LexList)
			{
				XmlSerializer ser=new XmlSerializer(l.GetType());
				ser.Serialize(writer, l);
			}
		}

		#endregion

	}
}
