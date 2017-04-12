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
using MvvmCross.Droid.Support.V7.AppCompat;
using EsMo.Sina.SDK.Model;
using Android.Content.PM;

namespace EsMo.Android.WeiBo.Entity
{
    [Activity(
       Label = "LoginView",
       LaunchMode = LaunchMode.SingleTop,
       ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize,
       Name = "esmo.android.weibo.entity.LoginView"
   )]
    public class LoginView : MvxAppCompatActivity<LoginViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.SetContentView(Resource.Layout.LoginView);
        }
    }
}