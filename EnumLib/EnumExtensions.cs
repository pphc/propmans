using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Reflection;

namespace EnumLib
{
	public class EnumItem
	{
		public string Name { get; set; }
		public int Value { get; set; }
		public override string ToString()
		{
			return Name;
		}
	}

	public static class EnumExtensions
	{
		//Return the Enum entry for the specified string
		//TryParse is case-sensitive, so use LINQ instead
		public static T Entry<T>(string dbvalue)
		{
			MemberInfo[] fis = typeof(T).GetFields();

			foreach (FieldInfo fi in fis)
			{
				Attribute attr = Attribute.GetCustomAttribute(fi, typeof(EnumDBValue));
				if ((attr != null) & attr is EnumDBValue)
				{
					if ( (attr as EnumDBValue).ToString() == dbvalue)
					{
						return (T)Enum.Parse(typeof(T), fi.Name);
					}
				}
			}

			throw new Exception("Not found");
		}

		public static string StringAttribute(Enum value, string attributeName)
		{
			dynamic Result = string.Empty;
			FieldInfo Field = value.GetType().GetField(value.ToString(), BindingFlags.GetField | BindingFlags.Public | BindingFlags.Static);
			//' Dim attribs = Field.GetCustomAttributes(True)
			dynamic dn = (from item in Field.GetCustomAttributes(true)
						  where item.GetType().Name == attributeName 
						  select item).FirstOrDefault();
			if ((dn != null))
				Result = dn.ToString;

			return Result;
		}


		public static string DisplayName(this Enum value)
		{
			dynamic Result = StringAttribute(value, "EnumDisplayName");
			return Result;
		}


		public static string DBVAlue(this Enum value)
		{
			dynamic Result = StringAttribute(value, "EnumDBValue");
			return Result;
		}

		//Move to separate function to avoid issue with late binding when Option Strict On

		//'Move to separate function to avoid issue with late binding when Option Strict On

		public static List<EnumItem> ItemList(this Enum s, bool includeUnknown = false , bool useDisplayName = false)
		{
			List<EnumItem> Result = new List<EnumItem>();
			dynamic names = Enum.GetNames(s.GetType());
			dynamic values = Enum.GetValues(s.GetType());
			for (int i = 0; i <= names.Length - 1; i++)
			{
				if ((includeUnknown || names(i).ToLower != "unknown"))
				{
					if ((useDisplayName))
					{
						dynamic itemName = DisplayName((Enum)values(i));
						Result.Add(new EnumItem
						{
							Name = itemName,
							Value = values(i)
						});
					}
					else
					{
						Result.Add(new EnumItem
						{
							Name = names(i),
							Value = values(i)
						});
					}
				}
			}
			return Result;
		}
	}
}
