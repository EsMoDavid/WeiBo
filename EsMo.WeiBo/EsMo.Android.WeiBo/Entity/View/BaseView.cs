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
    public class BaseCachingFragmentActivity<T>  : MvxCachingFragmentCompatActivity<T> where T : BaseViewModel
    {
        protected global::Android.Support.V7.Widget.Toolbar toolbar { get; private set; }

        protected virtual int LayoutID { get; }

        public override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
            this.ViewModel.Appearing();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.SetContentView(LayoutID);
            if (this.SupportActionBar == null)
            {
                toolbar = this.FindViewById<global::Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar1);
                if (toolbar != null)
                    this.SetSupportActionBar(toolbar);
            }
            if (this.SupportActionBar != null)
            {
                this.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                this.SupportActionBar.SetDisplayShowHomeEnabled(false);
            }
        }
    }
}