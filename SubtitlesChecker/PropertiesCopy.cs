using System;
using System.Linq;
using System.Reflection;

namespace Harmonic.Subtitles
{
	public static class Ext
	{
		public static Object CopyProperties(this Object destination, Object source)
		{
			PropertyInfo[] destinationProperties =
				destination.GetType()
				.GetProperties()
				.Where(p => p.CanWrite)
				.ToArray();

			Type sourceType = source.GetType();

			foreach (PropertyInfo destinationPi in destinationProperties)
			{
				PropertyInfo sourcePi = sourceType.GetProperty(destinationPi.Name);
				if (sourcePi != null)
					destinationPi.SetValue(destination, sourcePi.GetValue(source, null), null);
			}

			return destination;
		}
	}
}