using CoreGraphics;
using EsMo.MvvmCross.iOS.Support.Converter;
using EsMo.Sina.SDK.Model;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using SDWebImage;
using System;

namespace EsMo.iOS.WeiBo.Entity
{
    public partial class MenuProfileView : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("MenuProfileView");
        
        public MenuProfileView(IntPtr handle):base(handle)
        {

        }
        public MenuProfileView():base()
        {

        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            this.imgProfile.Layer.CornerRadius = imgProfile.Frame.Width / 2f;
            this.imgProfile.Layer.MasksToBounds = true;
            this.txtFollowersNewHint.Hidden = true; // hidden temporarily
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<MenuProfileView, MenuProfileViewModel>();
                set.Bind(this.imgBackground).To(vm => vm.BackgroundBanner).WithConversion(Converter.StreamToUIImage);
                set.Bind(this.txtName).To(vm => vm.Text);
                set.Apply();
                this.imgProfile.SetImage(new NSUrl((this.DataContext as MenuProfileViewModel).AvatarUrl));
            });
        }
        
        //public static MenuProfileView Create(UITableViewCellStyle style, NSString reuseIdentifier,MenuProfileViewModel model)
        //{
        //    var cell = new MenuProfileView( );
        //    var nib = NSBundle.MainBundle.LoadNib("MenuProfileView", cell, null);
        //    var item = Runtime.GetNSObject(nib.ValueAt(0)) as MenuProfileView;
        //    return item;
        //}
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            this.txtFollowersNewHint.SizeToFit();
            var imgFrame = this.imgProfile.Frame;
            this.txtFollowersNewHint.Center = new CGPoint(imgFrame.Right, imgFrame.Top);
        }
    }
}