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
using Android.Util;

namespace EsMo.Android.WeiBo.Entity
{
    public class BaseView<T>: MvxAppCompatActivity<T> where T : BaseViewModel
    {
        public override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
            this.ViewModel.Appearing();
        }
    }
    
}