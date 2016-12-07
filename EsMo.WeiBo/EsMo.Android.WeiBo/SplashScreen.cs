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
using MvvmCross.Droid.Views;
using Android.Content.PM;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace EsMo.Android.WeiBo
{
    [Activity(
         Label = "EsMo.Android.WeiBo"
         , MainLauncher = true
         , Icon = "@drawable/icon"
         , Theme = "@style/Theme.Splash"
         , NoHistory = true
         , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
           : base(Resource.Layout.SplashScreen)
        {

        }
        protected override void TriggerFirstNavigate()
        {
            var starter = Mvx.Resolve<IMvxAppStart>();
            starter.Start("TestUI");
        }
    }
}