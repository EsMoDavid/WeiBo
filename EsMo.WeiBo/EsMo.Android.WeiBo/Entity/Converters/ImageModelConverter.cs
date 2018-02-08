using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EsMo.Sina.Model.Groups;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Support.V7.AppCompat.Widget;
using MvvmCross.Platform.Converters;

namespace EsMo.Android.WeiBo.Entity.Converters
{
    public class ModelToImageConverter : MvxValueConverter<IList<ImageModel>, string>
    {
        protected override string Convert(IList<ImageModel> value, Type targetType, object parameter, CultureInfo culture)
        {
            if(parameter==null)
            {
                throw new Exception("ImageModelConverter has no parameter");
            }
            int index = int.Parse(parameter.ToString());
            if (index >= value.Count)
            {
                return string.Empty;
            }
            //return value[index].ThumbnailPic;
            return "http://wx2.sinaimg.cn/thumbnail/8e7f1a15ly1fnstiejlbrg20dv05hnar.gif";
        }
    }
    public class ModelToVisibilityConverter : MvxValueConverter<IList<ImageModel>, ViewStates>
    {
        protected override ViewStates Convert(IList<ImageModel> value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
            {
                throw new Exception("ImageModelConverter has no parameter");
            }
            int index = int.Parse(parameter.ToString());
            System.Diagnostics.Debug.WriteLine(value.Count+"----------------------");
            if (index >= value.Count)
            {
                return ViewStates.Gone;
            }
            return ViewStates.Visible;
        }
    }
}