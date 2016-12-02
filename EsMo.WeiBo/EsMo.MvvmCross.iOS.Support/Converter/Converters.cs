using MvvmCross.Platform.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using UIKit;
using Foundation;
using EsMo.Common.UI;

namespace EsMo.MvvmCross.iOS.Support.Converter
{
    public abstract class Converter : MvxValueConverter
    {
        public static readonly StreamUIImageConverter StreamToUIImage = new StreamUIImageConverter();
        public static readonly UIColorConverter ColorToUIColor = new UIColorConverter();
    }

    public class StreamUIImageConverter : MvxValueConverter
    {
        public override object Convert(object value, Type targetType=null, object parameter = null, CultureInfo culture = null)
        {
            Stream stream = value as Stream;
            if (stream != null)
            {
                UIImage image = UIImage.LoadFromData(NSData.FromStream(stream), 1);
                return image;
            }
            return null;
        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return base.ConvertBack(value, targetType, parameter, culture);
        }
    }
    public class UIColorConverter : MvxValueConverter
    {
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            Color color = value as Color;
            if (color != null)
            {
                return UIColor.FromRGBA(color.R, color.G, color.B, color.A);
            }
            return null;
        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return base.ConvertBack(value, targetType, parameter, culture);
        }
    }
}
