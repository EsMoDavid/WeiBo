using System;

using Foundation;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using EsMo.Sina.Model.Groups;
using SDWebImage;

namespace EsMo.iOS.WeiBo.Entity
{
    public partial class ImageViewCell : MvxCollectionViewCell
    {
        public static readonly NSString Key = new NSString("ImageViewCell");
        public static readonly UINib Nib;
        public UIImageView ImageView { get; private set; }

        static ImageViewCell()
        {
            Nib = UINib.FromName("ImageViewCell", NSBundle.MainBundle);
        }

        protected ImageViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            this.ImageView = new UIImageView() { ContentMode = UIViewContentMode.ScaleAspectFill };
            this.ContentView.Add(this.ImageView);
            this.BindingContext.DataContextChanged += BindingContext_DataContextChanged;
        }
      
        private void BindingContext_DataContextChanged(object sender, EventArgs e)
        {
            if (this.DataContext != null)
            {
                this.ImageView.SetImage(new NSUrl((this.DataContext as ImageModel).ThumbnailPic), (img, err, cacheType, url) =>
                {
                    UIView.Transition(this.ImageView, 0.25f, UIViewAnimationOptions.TransitionCrossDissolve,
                        () => this.ImageView.Image = img, null);
                });
            }
            this.SetNeedsLayout();
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            this.ImageView.Frame = this.ContentView.Frame;
        }
    }
}