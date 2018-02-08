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
using EsMo.Sina.SDK.Model;
using Android.Content.PM;
using CheeseBind;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using MvvmCross.Binding.Droid.Views;
using Android.Support.V4.View;
using Android.Support.V4.App;
using MvvmCross.Core.ViewModels;
using ActionBarDrawerToggle = Android.Support.V7.App.ActionBarDrawerToggle;
using MvvmCross.Droid.Support.V4;

namespace EsMo.Android.WeiBo.Entity
{
    [Activity(
        Label = "MainView",
        NoHistory = true,
        LaunchMode = LaunchMode.SingleInstance
        )]
    public class MainView : BaseCachingFragmentActivity<MainViewModel>
    {
        [BindView(Resource.Id.drawer)]
        DrawerLayout drawerLayout;
        [BindView(Resource.Id.mainViewPage)]
        ViewPager mainViewPage;
        ActionBarDrawerToggle drawerToggle;
        List<MvxCachingFragmentStatePagerAdapter.FragmentInfo> framgments;

        protected override int LayoutID
        {
            get
            {
                return Resource.Layout.Main;
            }
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Cheeseknife.Bind(this);
            this.framgments = new List<MvxCachingFragmentStatePagerAdapter.FragmentInfo>();
            
            this.framgments.Add(new MvxCachingFragmentStatePagerAdapter.FragmentInfo("Home", typeof(TimelineFragment), typeof(TimelineViewModel)));
            MvxCachingFragmentStatePagerAdapter adapter = new MvxCachingFragmentStatePagerAdapter(this,this.SupportFragmentManager, framgments);
            this.mainViewPage.Adapter = adapter;

            this.drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, this.toolbar,
            Resource.String.drawerOpen, Resource.String.drawerClose);
            this.drawerLayout.AddDrawerListener(this.drawerToggle);
            
        }
        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            this.drawerToggle.SyncState();
        }
    }
}