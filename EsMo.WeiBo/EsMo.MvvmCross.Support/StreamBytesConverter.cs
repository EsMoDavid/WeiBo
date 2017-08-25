using MvvmCross.Platform.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace EsMo.MvvmCross.Support
{
   public class StreamBytesConverter : MvxValueConverter<Stream>
    {
        protected override object Convert(Stream value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                byte[] bytes = new byte[value.Length];
                value.Read(bytes, 0, bytes.Length);
                value.Flush();
                return bytes;
            }
            return null;
        }
    }
}
