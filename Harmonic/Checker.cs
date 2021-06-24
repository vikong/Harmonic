using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harmonic
{
	/// <summary>
	/// Шаблон класса, содержащего список условий
	/// </summary>
	public abstract class Checker
	{
		public ICollection<ILex> LexList { get; set; }

	}

	/// <summary>
	/// Обеспечивает проверку по списку условий, с конкатенацией "AND"
	/// </summary>
	public class AndChecker : Checker,
		IChecker
	{
		public Boolean Check(String str)
		{
			foreach (ILex l in LexList)
				if (!l.Check(str)) return false;

			return true;
		}
	}

	/// <summary>
	/// Обеспечивает проверку по списку условий, с конкатенацией "OR"
	/// </summary>
	public class OrChecker : Checker,
		IChecker
	{
		public Boolean Check(String str)
		{
			foreach (ILex lex in LexList)
				if (lex.Check(str)) return true;

			return false;
		}
	}
}
