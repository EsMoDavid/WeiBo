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
using Android.Webkit;

namespace EsMo.Android.WeiBo.Entity
{
    public class AuthWebViewClient : WebViewClient
    {
        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {
            //string url = request.Url.ToString();
            if (!string.IsNullOrEmpty(url) && !url.StartsWith("sinaweibo://"))
            {
                view.LoadUrl(url);
            }
            return base.ShouldOverrideUrlLoading(view, url);
        }
        //public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
        //{
        //    string url = request.Url.ToString();
        //    if (!string.IsNullOrEmpty(url) && !url.StartsWith("sinaweibo://"))
        //    {
        //        view.LoadUrl(url);
        //    }
        //    return base.ShouldOverrideUrlLoading(view, request);
        //}
    }
}