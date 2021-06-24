using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Xml;

namespace Harmonic
{
	[Serializable]
	[XmlRoot(ComplexLex.SerializationName)]
	public class LexOr : ComplexLex, 
		ILex
	{
		public LexOr():base(LexType.Or)	{ }
		public LexOr(params ILex[] args) : base(LexType.Or, args) { }
	}
}
