using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;
using System.IO;
using Android.Graphics.Drawables;

namespace EsMo.Android.Support
{
   public static class Extension
    {
        public static Java.Lang.String ToJava(this string str)
        {
            return new Java.Lang.String(str);
        }
    }
    public static class ViewExtension
    {
        public static void SetTextPixelSize(this TextView textView, double pixelSize)
        {
            textView.SetTextSize(ComplexUnitType.Px, (float)pixelSize);
        }
        public static void SetImageSource(this ImageView imgView, Stream stream)
        {
            if (stream == null)
                imgView.SetImageDrawable(null);
            else
            {
                stream.Seek(0, SeekOrigin.Begin);
                var bmp = new BitmapDrawable(stream);
                imgView.SetImageDrawable(bmp);
            }
        }
    }
    internal static class AppSetting
    {
        public const double ContentFontSize = 48;
    }
}