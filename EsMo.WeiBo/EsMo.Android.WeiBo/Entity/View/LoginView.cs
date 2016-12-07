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

namespace EsMo.Android.WeiBo.Entity
{
    [Activity(Label = "LoginView")]
    public class LoginView : MvxCachingFragmentCompatActivity<LoginViewModel>//, INavigationActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
    }
}