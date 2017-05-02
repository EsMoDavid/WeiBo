
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using CheeseBind;
using EsMo.Android.Support;
using EsMo.Sina.SDK.Model;
using MvvmCross.Binding.Droid.Views;
using System.IO;
using System.Net.Http;

namespace EsMo.Android.WeiBo.Entity
{
    [Activity(
        Label = "StartupView",
        LaunchMode = LaunchMode.SingleTop,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize,
        Name = "esmo.android.weibo.entity.StartupView",
        NoHistory =true
      )]
    public class StartupView : BaseView<StartupViewModel>
    {
        [BindView(Resource.Id.imgProfile)]
        MvxImageView imgProfile;
        [BindView(Resource.Id.textView1)]
        TextView textView1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.SetContentView(Resource.Layout.StartupView);
            this.ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            Cheeseknife.Bind(this);
            this.ViewModel.StartupCommand.Execute(null);
            if (this.ActionBar != null)
            {
                this.ActionBar.SetDisplayHomeAsUpEnabled(true);
                this.ActionBar.SetDisplayShowHomeEnabled(false);
            }
        }

     

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //if (e.PropertyName == "StatusText")
            //{
            //    count++;
            //    this.textView1.Text = this.ViewModel.StatusText;
            //}
            string str = "http://tvax4.sinaimg.cn/default/images/default_avatar_male_50.gif";
            if (e.PropertyName == "ProfileUrl")
            {

                //Picasso.With(this).Load(this.ViewModel.ProfileUrl).Into(this.imgProfile);
                //imgProfile.ImageUrl = this.ViewModel.ProfileUrl;
                imgProfile.ImageUrl= "http://tvax4.sinaimg.cn/default/images/default_avatar_female_50.gif";
               // HttpClient client = new HttpClient();
               // var response =  client.GetAsync(str).Result;
               //var stream= response.Content.ReadAsStreamAsync().Result;
               // imgProfile.SetImageSource(stream);
            }
        }
    }
}