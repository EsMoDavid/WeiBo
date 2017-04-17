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
    public class AuthWebChromeClient : WebChromeClient
    {
        public override void OnProgressChanged(WebView view, int newProgress)
        {
            base.OnProgressChanged(view, newProgress);
            if (newProgress == 100)
                (view as WebViewImp).InvokeLoadFinished();
        }
    }
}