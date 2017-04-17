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
using Refractored.Controls;
using CheeseBind;
using Square.Picasso;

namespace EsMo.Android.WeiBo.Entity
{
    [Activity(
          Label = "StartupView",
          LaunchMode = LaunchMode.SingleTop,
          ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize,
          Name = "esmo.android.weibo.entity.StartupView"
      )]
    public class StartupView : BaseView<StartupViewModel>
    {
        [BindView(Resource.Id.imgProfile)]
        CircleImageView imgProfile;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            this.ViewModel.StartupCommand.Execute(null);
            this.SetContentView(Resource.Layout.StartupView);
            Cheeseknife.Bind(this);
            if(this.ActionBar!=null)
            {
                this.ActionBar.SetDisplayHomeAsUpEnabled(true);
                this.ActionBar.SetDisplayShowHomeEnabled(false);
            }

        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName== "ProfileUrl")
            {
                Picasso.With(this).Load(this.ViewModel.ProfileUrl).Into(this.imgProfile);
            }
        }
    }
}