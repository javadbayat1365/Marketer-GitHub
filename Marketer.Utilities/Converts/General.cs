using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Marketer.Utilities.Converts
{
   public static class General
    {
        public static string ToRialFormat(this decimal value)
        {
            return string.Format("{0:n0}", value);
        }
        public static string RandomNOChar(short Lenght)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            string ch;
            string code = "";
            for (int i = 0; i < Lenght; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65))).ToString().ToLower();
                builder.Append(ch);
            }
            return builder.ToString();
        }
        public static string EnumDescription<T>(this T value) where T : IConvertible
        {
            string result = "";
            if (value is Enum)
            {
                Type type = value.GetType();
                Array values = System.Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == value.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .FirstOrDefault() as DescriptionAttribute;

                        if (descriptionAttribute != null)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }
            }
            return result;
        }
    }
}
