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
/// <summary>
/// Converters can not be put in a independent project file. 
/// I have to put it in the main project.
/// </summary>
namespace EsMo.MvvmCross.Android.Support.Converter
{
    public class StreamBitmapConverter : MvxValueConverter<Stream, Bitmap>
    {
        protected override Bitmap Convert(Stream value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return BitmapFactory.DecodeStream(value);
            return null;
        }
    }
    public class NullGoneConverter : IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? ViewStates.Gone : ViewStates.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}