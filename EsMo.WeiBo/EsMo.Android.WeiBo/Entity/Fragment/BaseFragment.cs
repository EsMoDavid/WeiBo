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
using MvvmCross.Droid.Support.V4;
using MvvmCross.Core.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;

namespace EsMo.Android.WeiBo.Entity
{
    public abstract class BaseFragment<T> : MvxFragment<T> where T : class, IMvxViewModel
    {
        //public virtual int LayoutID { get; }
        //public override global::Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        //{
        //    //return base.OnCreateView(inflater, container, savedInstanceState);
        //    //inflater.Inflate(LayoutID, container, false);
        //    return this.BindingInflate(LayoutID, null);

        //}
    }
}