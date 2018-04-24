using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using FragmentManager = Android.Support.V4.App.FragmentManager;
namespace EsMo.Android.WeiBo.Entity
{
    public class MainPageAdapter : FragmentPagerAdapter 
    {
        IEnumerable<MvxFragment> fragments;
        public MainPageAdapter(FragmentManager fm, IEnumerable<MvxFragment> fragments) : base(fm)
        {
            this.fragments = fragments;
        }
        public override int Count => this.fragments.Count();

        public override global::Android.Support.V4.App.Fragment GetItem(int position)
        {
            return this.fragments.ToArray()[position];
        }
    }
}