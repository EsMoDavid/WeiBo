using EsMo.Sina.SDK.Model;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.Binders;
using System;

using UIKit;
using MvvmCross.Binding.BindingContext;
using WebKit;
using Foundation;
using MvvmCross.Platform;
using EsMo.Sina.SDK.Service;
using MvvmCross.iOS.Support.SidePanels;

namespace EsMo.iOS.WeiBo.Entity
{
    [MvxPanelPresentation(MvxPanelEnum.Center, MvxPanelHintType.ActivePanel, true)]
    public partial class LoginView : BaseView<LoginViewModel>
    {
        WebViewImp webView;
        public LoginView() : base("LoginView", null)
        {
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.InitWebView();
            this.ViewModel.WebView = this.webView;
        }
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            this.webView.Frame = this.View.Frame;
        }

        void InitWebView()
        {
            WKWebViewConfiguration config = new WKWebViewConfiguration();
            config.Preferences.JavaScriptCanOpenWindowsAutomatically = true;
            this.webView = new WebViewImp(this.View.Frame, config);
            this.webView.TranslatesAutoresizingMaskIntoConstraints = false;
            this.webView.AutoresizingMask = UIViewAutoresizing.None;
            this.Add(this.webView);
        }
    }
}