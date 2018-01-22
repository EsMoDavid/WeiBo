using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Shared.Attributes;
using EsMo.Sina.SDK.Model;

namespace EsMo.Android.WeiBo.Entity.Fragment
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.menu_frame)]
    [Register("xplatformmenus.droid.fragments.TimelineFragment")]
    public class TimelineFragment : BaseFragment<TimelineViewModel>
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        public override global::Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}