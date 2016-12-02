using CoreGraphics;
using EsMo.iOS.Support;
using EsMo.Sina.SDK.Converter;
using EsMo.Sina.SDK.Model;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Core.Views;
using ObjCRuntime;
using System;
using System.IO;
using UIKit;
using MvvmCross.Core.ViewModels;

namespace EsMo.iOS.WeiBo.Entity
{
    public partial class MenuProfileView : MvxView
    {
        #region ctor
        public MenuProfileView()
        {

        }
        public MenuProfileView (IntPtr handle) : base (handle)
        {
        }
        //[Export("initWithCoder:")]
        //public MenuProfile(NSCoder coder):base(coder)
        //{

        //}
        [Export("initWithFrame:")]
        public MenuProfileView(CGRect frame):base(frame)
        {

        }
        #endregion
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<MenuProfileView, MenuProfileViewModel>();
                set.Bind(this.imgBackground).To(vm => vm.BackgroundBanner).WithConversion(Converter.StreamToUIImage);
                set.Apply();
            });
        }
        public static MenuProfileView Create()
        {
            var cell = new MenuProfileView();
            var nib = NSBundle.MainBundle.LoadNib("MenuProfileView", cell, null);
            var nsObject = Runtime.GetNSObject(nib.ValueAt(0)) ;
            return nsObject as MenuProfileView;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            this.txtFollowersNewHint.SizeToFit();
            var imgFrame = this.imgProfile.Frame;
            this.txtFollowersNewHint.Center = new CGPoint(imgFrame.Right, imgFrame.Top);
        }
    }
   
}