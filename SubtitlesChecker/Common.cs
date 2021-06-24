using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Harmonic.Subtitles
{
	internal static class Common
	{
		/// <summary>
		/// Удаляет элемент из списка и рефрешит BindingSource
		/// </summary>
		/// <typeparam name="T">тип списка</typeparam>
		/// <param name="bs">BindingSource привязанный к списку</param>
		/// <param name="list">список</param>
		public static void DeleteCurrent(this BindingSource bs, Boolean enableRemoveLast=true)
		{
			if (bs.Current == null && (!enableRemoveLast && bs.Count <= 1))
				return;

			var pos = bs.Position;
			// если удаляется предпоследняя запись, то начинаются глюки с кастомными гридами (CellValueNeeded)
			if (pos == bs.Count - 1 && pos > 0)
				bs.MovePrevious();
			bs.RemoveAt(pos);
		}

	}
}
