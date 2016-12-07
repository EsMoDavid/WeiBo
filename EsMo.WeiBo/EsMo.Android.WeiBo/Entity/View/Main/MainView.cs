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
using Android.Support.V7.Widget;
using EsMo.Sina.SDK.Model;
using Android.Content.PM;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using CheeseBind;
using Android.Support.V4.Widget;
using Android.Views.InputMethods;

namespace EsMo.Android.WeiBo.Entity
{
    [Activity(Label = "MainView", LaunchMode = LaunchMode.SingleTop, Theme = "@style/AppTheme",
        Name = "esmo.android.weiBo.entity.MainView")]
    public class MainView : MvxCachingFragmentCompatActivity<MainViewModel>
    {
        [BindView(Resource.Id.toolbar1)]
        Toolbar toolbar;
        [BindView(Resource.Id.drawer)]
        DrawerLayout drawer;
        MvxActionBarDrawerToggle drawerToggle;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            this.SetContentView(Resource.Layout.MainLayout);
            Cheeseknife.Bind(this);

            this.toolbar = this.FindViewById<Toolbar>(Resource.Id.toolbar1);
            if (this.toolbar != null)
            {
                this.SetSupportActionBar(toolbar);
                this.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                drawerToggle = new MvxActionBarDrawerToggle(this, drawer, toolbar, Resource.String.drawerOpen, Resource.String.drawerClose);
                drawerToggle.DrawerOpened += (s,e) => this.HideSoftKeyboard();
                drawer.AddDrawerListener(drawerToggle);
            }
            if (savedInstanceState == null)
                this.ViewModel.ShowMenuCommand?.Execute(null);
        }
        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            this.drawerToggle.SyncState();
        }
        public void HideSoftKeyboard()
        {
            if (CurrentFocus == null) return;

            InputMethodManager inputMethodManager = (InputMethodManager)GetSystemService(InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(CurrentFocus.WindowToken, 0);

            CurrentFocus.ClearFocus();
        }
    }
}