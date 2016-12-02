using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Sina.Model
{
    public static class SinaModelExtension
    {
        public static string DateConvertToString(this DateTime? date)
        {
            if (date.HasValue)
            {
                return date.Value.ToString("yyyy-MM-dd");
            }
            return string.Empty;
        }
    }
}
