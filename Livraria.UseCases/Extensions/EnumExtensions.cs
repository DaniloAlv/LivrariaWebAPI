using System;
using System.ComponentModel;
using System.Reflection;

namespace Livraria.UseCases.Extensions
{
	public static class EnumExtensions
	{
		public static string GetDescription(this Enum e)
		{
			FieldInfo info = e.GetType().GetField(e.ToString());
			DescriptionAttribute[] attributes = (DescriptionAttribute[])info.GetCustomAttributes(typeof(DescriptionAttribute), false);

			return attributes[0].Description;
		}
	}
}
