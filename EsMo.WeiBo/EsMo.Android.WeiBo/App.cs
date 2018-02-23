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
using UniversalImageLoader.Core;

namespace EsMo.Android.WeiBo
{
    [Application(Label = "EsMo.Weibo")]
    public class UIApp : Application
    {
        protected UIApp(IntPtr javaReference, JniHandleOwnership transfer)
        : base(javaReference, transfer)
        {
        }
        public override void OnCreate()
        {
            base.OnCreate();
            // Use default options
            var config = ImageLoaderConfiguration.CreateDefault(ApplicationContext);
            // Initialize ImageLoader with configuration.
            ImageLoader.Instance.Init(config);
        }
    }
}