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
using MvvmCross.Droid.Support.V4;
using EsMo.Sina.SDK.Model;
using MvvmCross.Droid.Shared.Attributes;
using Android.Support.Design.Widget;
using MvvmCross.Binding.Droid.BindingContext;

namespace EsMo.Android.WeiBo.Entity
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.menu_frame)]
    [Register("esmo.android.weibo.entity.MenuFragment")]

    public class MenuFragment : MvxFragment<MenuViewModel>, NavigationView.IOnNavigationItemSelectedListener
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.MenuLayout,null);
        }

        public bool OnNavigationItemSelected(IMenuItem menuItem)
        {
            return true;
        }
    }
}