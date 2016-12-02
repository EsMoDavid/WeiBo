using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Sina.SDK.Parsing
{
    internal static class DateExtension
    {
        public static DateTime ParseDateString(string str)
        {
            string format = "ddd MMM d HH:mm:ss yyyy";

            DateTime result;
            DateTime.TryParseExact(str, format, CultureInfo.InvariantCulture
                , DateTimeStyles.AllowWhiteSpaces, out result);
            return result;
        }
    }
}
