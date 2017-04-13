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
using EsMo.Common.UI;
using Android.Util;

namespace EsMo.Android.WeiBo.Entity.Element
{
    public class WebViewImp : WebView, IWebView
    {
        public WebViewImp(Context context):base(context)
        {

        }
        public WebViewImp(Context context, IAttributeSet attrs):base(context,attrs)
        {
            this.LoadFinished += WebViewImp_LoadFinished;
        }

        private void WebViewImp_LoadFinished(object sender, EventArgs e)
        {
            
        }

        public WebViewImp(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr) { }
        public WebViewImp(Context context, IAttributeSet attrs, int defStyleAttr, bool privateBrowsing)
            : base(context, attrs, defStyleAttr, privateBrowsing) { }
        public WebViewImp(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
            : base(context, attrs, defStyleAttr, defStyleRes) { }
        protected WebViewImp(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer) { }
        public Uri Uri
        {
            get
            {
                return this.Url == null ? null : new Uri(this.Url.ToString());
            }
        }

        public event EventHandler LoadFinished;

        public void EvalJavaScript(string js)
        {
            this.LoadUrl(string.Format("javascript:{0}", js));
        }

        public void LoadHtmlString(string html, string schema)
        {
            this.LoadDataWithBaseURL(schema, html, "text/html", "UTF-8", string.Empty);
        }
    }
}