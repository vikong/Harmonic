using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harmonic
{
	internal class Common
	{
		/// <summary>
		/// Удаляет элемент из списка и рефрешит BindingSource
		/// </summary>
		/// <typeparam name="T">тип списка</typeparam>
		/// <param name="bs">BindingSource привязанный к списку</param>
		/// <param name="list">список</param>
		public static Int32 DeleteFromList<T>(BindingSource bs, IList<T> list, Boolean removeLast=false)
		{
			if (list.Count==0)
				return -1;
			if (!removeLast && list.Count<=1)
			{
				MessageBox.Show("Can't remove last element.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return -1;
			}
			int pos=bs.Position;
			list.RemoveAt(pos);
			bs.ResetBindings(false);
			bs.Position=Math.Min(Math.Max(pos, 0), list.Count);
			return pos;
		}

	}
}
