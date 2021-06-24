using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Xml;

namespace Harmonic
{
	[Serializable]
	[XmlRoot(ComplexLex.SerializationName)]
	public class LexAnd : ComplexLex
	{
		public LexAnd() : base(LexType.And) { }
		public LexAnd(params ILex[] args) : base(LexType.And, args) { }
	}
}
