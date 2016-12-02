using CoreGraphics;
using EsMo.Sina.Model.Groups;
using EsMo.Sina.SDK.Converter;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

namespace EsMo.iOS.WeiBo.Entity
{
    [Register("ImageCell")]
    public class ImageCell : MvxCollectionViewCell
    {
        public UIImageView ImageView { get; private set; }
        public ImageCell(CGRect frame): base(frame)
        {
            this.Initial(frame);   
        }
        public ImageCell(string bindingText, CGRect frame)
            :base(bindingText,frame)
        {
            this.Initial(frame);
        }
        void Initial(CGRect frame)
        {
            this.ImageView = new UIImageView(frame) { ContentMode = UIViewContentMode.ScaleAspectFit };
            this.ContentView.Add(this.ImageView);
            this.BindingContext.DataContextChanged += BindingContext_DataContextChanged;
            this.CreateBinding(this.ImageView).To<ImageModel>(x => x.ThumbnailPic).WithConversion(Converter.StreamToUIImage,null).Apply();
        }

        private void BindingContext_DataContextChanged(object sender, EventArgs e)
        {
            this.SetNeedsLayout();   
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            this.ImageView.Frame = this.ContentView.Frame;
        }
    }
}