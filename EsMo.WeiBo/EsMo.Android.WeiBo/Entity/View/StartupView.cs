
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using CheeseBind;
using EsMo.Android.Support;
using EsMo.Sina.SDK.Model;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Support.V7.AppCompat.Widget;
using System.IO;
using System.Net.Http;
using UniversalImageLoader.Core;

namespace EsMo.Android.WeiBo.Entity
{
    [Activity(
        Label = "StartupView",
        LaunchMode = LaunchMode.SingleTop,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize,
        Name = "esmo.android.weibo.entity.StartupView",
        NoHistory = true
      )]
    public class StartupView : BaseView<StartupViewModel>
    {
        [BindView(Resource.Id.imgProfile)]
        MvxAppCompatImageView imgProfile;
        [BindView(Resource.Id.textView1)]
        TextView textView1;
        protected override int LayoutID => Resource.Layout.StartupView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //this.SetContentView(Resource.Layout.StartupView);
            //Cheeseknife.Bind(this);
            this.ViewModel.StartupCommand.Execute(null);
            this.ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            if (this.ActionBar != null)
            {
                this.ActionBar.SetDisplayHomeAsUpEnabled(true);
                this.ActionBar.SetDisplayShowHomeEnabled(false);
            }
            this.imgProfile.SetImageSource(this.ViewModel.UnknownProfile);
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.ViewModel.ProfileUrl):
                    ImageLoader.Instance.DisplayImage(this.ViewModel.ProfileUrl, this.imgProfile);
                    break;
                default:
                    break;
            }
        }
    }
}