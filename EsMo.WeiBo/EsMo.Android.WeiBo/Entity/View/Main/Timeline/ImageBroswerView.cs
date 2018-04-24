using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;
using Android.Widget;
using CheeseBind;
using EsMo.Sina.SDK.Model;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;
using UniversalImageLoader.Core;

namespace EsMo.Android.WeiBo.Entity
{
    [Activity(Label = "ImageBroswerView")]


    [Register("esmo.android.weibo.entity.ImageBroswerView")]
    public class ImageBroswerView : BaseView<ImageBrowserViewModel>
    {
        const string ArgUrls = "urls";
        const string ArgIndex = "index";
        protected override int LayoutID => Resource.Layout.ImageLayout;
        [BindView(Resource.Id.viewPager)]
        ViewPager viewPager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //Cheeseknife.Bind(this, view);
            string[] urls = this.ViewModel.ImageUrls;
            int idx = this.ViewModel.CurrentIndex;

            List<ImageDisplayView> listFragments = new List<ImageDisplayView>();
            for (int i = 0; i < urls.Length; i++)
            {
                listFragments.Add(new ImageDisplayView(urls[i]));
            }
            this.viewPager.Adapter = new MainPageAdapter(this.SupportFragmentManager, listFragments);
            this.viewPager.CurrentItem = idx;
        }
    }
    public class ImageDisplayView : MvxFragment
    {
        string imgUrl;
        public ImageDisplayView(string url)
        {
            this.imgUrl = url;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ImageView img = new ImageView(this.Context);
            img.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
            ImageLoader.Instance.DisplayImage(imgUrl, img);
            return img;
        }
    }
}