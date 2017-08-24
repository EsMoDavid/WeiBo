using MvvmCross.Platform.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using Android.Graphics;

namespace EsMo.MvvmCross.Support
{
   public class StreamImageConverter : MvxValueConverter<Stream,Bitmap>
    {
        //protected override object Convert(Stream value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    if (value != null)
        //        return BitmapFactory.DecodeStream(value);
        //    return null;
        //}
        protected override Bitmap Convert(Stream value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return BitmapFactory.DecodeStream(value);
            return null;
        }
    }
}
