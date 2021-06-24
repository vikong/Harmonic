using System;
using System.Xml.Serialization;
using System.Xml;
using System.Collections.Generic;

namespace Harmonic
{
	/// <summary>
	/// Класс, проверяющий (не)вхождение подстроки в строку.
	/// </summary>
	[Serializable]
	[XmlRoot(ElementName=Lex.SerializationName, Namespace="")]
	public class Lex: ILex
	{
		public const String SerializationName="Clause";

		private String _lexem;
		
		[XmlAttribute("Substring")]
		public String Lexem
		{
			get { return _lexem; }
			set { _lexem = !String.IsNullOrEmpty(value) ? value : null; }
		}
		[XmlIgnore]
		public Boolean Negation { get; set; }

		[XmlAttribute("Contains")]
		public Boolean Contains { get { return !Negation; } set { Negation = !value; } }

		public Lex()
		{
			Negation = false;
			Lexem = null;
		}
		public Lex(String lex)
		{
			Negation = false;
			Lexem = lex;
		}
		public Lex(String lex, Boolean neg)
		{
			Negation = neg;
			Lexem = lex;
		}

		/// <summary>
		/// Проверяет выполняемость лексемы для строки.
		/// </summary>
		/// <param name="str">Проверяемая строка</param>
		/// <returns>Возвращает истину, если лексема выполнена для строки</returns>
		public Boolean Check(String str)
		{
			if (!this.Empty)
				return !Negation? 
					str.IndexOf(_lexem, StringComparison.InvariantCultureIgnoreCase)>=0
					: 
					str.IndexOf(_lexem, StringComparison.InvariantCultureIgnoreCase)<0;
			else
				return true;
		}
		public Boolean Empty
		{
			get { return String.IsNullOrEmpty(_lexem); }
		}
		
		[XmlIgnore]
		public IEnumerable<String> Keywords
		{
			get { return new String[1]{_lexem}; }
		}

		public String Expression { get { return this.ToString(); } }
		public override String ToString()
		{
			return (!this.Empty ?  String.Format("{0}'{1}'", (Negation ? "NOT ":""), Lexem) : "");
		}

		#region Члены IXmlSerializable

		public System.Xml.Schema.XmlSchema GetSchema()
		{
			return null;
		}

		public void ReadXml(XmlReader reader)
		{
			if (!reader.HasAttributes)
				throw new FormatException("Expected attributes for clause!");
			Lexem = reader.GetAttribute("Substring");
			Negation = !(Boolean.Parse(reader.GetAttribute("Contains")));
				
			reader.Read();
		}

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteAttributeString("Substring", Lexem);
			writer.WriteAttributeString("Contains", (!Negation).ToString());
		}

		#endregion
	}
	

}