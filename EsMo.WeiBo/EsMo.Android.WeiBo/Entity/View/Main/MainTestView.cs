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
using MvvmCross.Droid.Support.V7.AppCompat.Widget;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace EsMo.Android.WeiBo.Entity
{
    [Activity(
        Label = "EsMo.Android.WeiBo.Entity.MainTestView"
        , MainLauncher = false
        , Icon = "@drawable/icon"
       
        , NoHistory = true
       )]
    public class MainTestView : MvxAppCompatActivity
    {
        ViewGroup panel;
        string url = "http://wx2.sinaimg.cn/thumbnail/59183920gy1foabi6429vj20ht04rwf5.jpg";
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.layout1);
            this.panel = this.FindViewById<LinearLayout>(Resource.Id.linear1);
            for (int i = 0; i < 9; i++)
            {
                MvxAppCompatImageView img = new MvxAppCompatImageView(this);
                //LinearLayout
                img.ImageUrl = url;
                img.LayoutParameters = new LinearLayout.LayoutParams(50, 50);
                this.panel.AddView(img);
            }
        }
    }
}