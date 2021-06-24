using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Harmonic
{
	/// <summary>
	/// представляет метод, определяющий соответствие строки условию
	/// </summary>
	public interface ILex : IXmlSerializable
	{
		/// <summary>
		/// Проверяет соответствие строки условию
		/// </summary>
		/// <param name="str">проверяемая строка</param>
		/// <returns>соответствие условию</returns>
		Boolean Check(String str);
		
		/// <summary>
		/// Выражение, задающее условие
		/// </summary>
		String Expression { get; }

		IEnumerable<String> Keywords { get; }
		
		/// <summary>
		/// Признак, что условие пусто
		/// </summary>
		Boolean Empty { get; }
	}
}
