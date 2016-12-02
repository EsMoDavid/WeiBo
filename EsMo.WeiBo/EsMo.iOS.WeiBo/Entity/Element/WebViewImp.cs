using CoreGraphics;
using EsMo.Common.UI;
using Foundation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using WebKit;

namespace EsMo.iOS.WeiBo.Entity
{
    public class WebViewImp:WKWebView,IWebView
    {
        public Uri Uri
        {
            get
            {
                return this.Url == null ? null : new Uri(this.Url.ToString());
            }
        }

        public event EventHandler LoadFinished;

        public WebViewImp(NSCoder coder):base(coder)
        {
            this.InitDelegate();
        }
        public WebViewImp(CGRect frame, WKWebViewConfiguration configuration)
            :base(frame,configuration)
        {
            this.InitDelegate();
        }
        void InitDelegate()
        {
            this.NavigationDelegate = new DefaultNavDelegate(this);
        }
        
        public void LoadHtmlString(string html, string schema)
        {
            this.LoadHtmlString(html, new NSUrl(schema));
        }

        public void EvalJavaScript(string js)
        {
            this.EvaluateJavaScript(js, null);
        }
        private void InvokeLoadFinished()
        {
            if(this.LoadFinished!=null)
            {
                this.LoadFinished(this, EventArgs.Empty);
            }
        }

        public void LoadUrl(string url)
        {
            Debug.WriteLine("LoadUrl="+url);
            this.LoadRequest(new NSUrlRequest(new NSUrl(url)));
        }

        class DefaultNavDelegate : WKNavigationDelegate
        {
            WebViewImp webView;
            public DefaultNavDelegate(WebViewImp webView)
            {
                this.webView = webView; 
            }
            public override void DidFinishNavigation(WKWebView webView, WKNavigation navigation)
            {
                Debug.WriteLine(webView.Url.ToString());
                this.webView.InvokeLoadFinished();
            }
            
            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
                this.webView = null;
            }
        }
    }
}