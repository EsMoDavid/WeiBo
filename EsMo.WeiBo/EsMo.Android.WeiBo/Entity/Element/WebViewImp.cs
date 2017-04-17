using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Webkit;
using EsMo.Common.UI;
using System;

namespace EsMo.Android.WeiBo.Entity
{
    public class WebViewImp : WebView, IWebView
    {
        public WebViewImp(Context context):base(context)
        {
            this.Init();   
        }
        public WebViewImp(Context context, IAttributeSet attrs):base(context,attrs)
        {
            this.Init();
        }
        

        public WebViewImp(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr) { this.Init(); }
        public WebViewImp(Context context, IAttributeSet attrs, int defStyleAttr, bool privateBrowsing)
            : base(context, attrs, defStyleAttr, privateBrowsing) { this.Init(); }
        public WebViewImp(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
            : base(context, attrs, defStyleAttr, defStyleRes) { this.Init(); }
        protected WebViewImp(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer) { this.Init(); }
        void Init()
        {
            this.Settings.JavaScriptEnabled = true;
            this.SetWebChromeClient(new AuthWebChromeClient());
            this.SetWebViewClient(new AuthWebViewClient());
        }
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
        public void InvokeLoadFinished()
        {
            if (this.LoadFinished != null)
                this.LoadFinished(this, EventArgs.Empty);
        }
    }
}