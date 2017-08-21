using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platform.Converters;
using System.IO;
using Android.Graphics;
using MvvmCross.Binding.Droid.Views;

namespace EsMo.MvvmCross.Android.Support.Converter
{
    public abstract class Converter : MvxValueConverter
    {
        public static readonly StreamBitmapConverter StreamToBitmap = new StreamBitmapConverter();
    }
    public class StreamBitmapConverter : MvxValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Stream stream = value as Stream;
            if (stream != null)
            {
                return BitmapFactory.DecodeStream(stream);
            }
            return null;
        }
    }
    //public class BoolViewStatesConverter : MvxValueConverter
    //{
    //    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        bool val = (bool)value;
    //        return val ? ViewStates.Visible : ViewStates.Gone;
    //    }
    //}
}