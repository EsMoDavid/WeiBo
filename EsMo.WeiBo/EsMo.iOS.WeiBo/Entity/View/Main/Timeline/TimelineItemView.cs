using System;
using System.Linq;
using Foundation;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using EsMo.Sina.SDK.Model;
using System.Diagnostics;
using SDWebImage;
using System.Collections.Generic;
using CoreGraphics;
using EsMo.MvvmCross.iOS.Support.Converter;
using CoreText;

namespace EsMo.iOS.WeiBo.Entity
{
    public partial class TimelineItemView : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("TimelineItemView");
        public static readonly UINib Nib;

        ImageCollectionSource imgSource;
        UIStringAttributes strAttr;
        static TimelineItemView()
        {
            Nib = UINib.FromName("TimelineItemView", NSBundle.MainBundle);
        }

        protected TimelineItemView(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            strAttr = new UIStringAttributes();
            //this.imgBackground.Image = UIImage.FromBundle("timeline_publish_single_normal.9");
            this.viewReplyHeight.Constant = 0;
            this.viewReplyHeight.Active = false;
            this.imgSource = new ImageCollectionSource(this.listImage,this);

            this.BindingContext.DataContextChanged += BindingContext_DataContextChanged;
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<TimelineItemView, TimelineItemViewModel>();
                set.Bind(this.txtName).To(v => v.Name);
                set.Bind(this.txtContent).To(v => v.Text);
                set.Bind(this.txtDesc).To(v => v.Description);
                set.Bind(this.txtReContent).To(v => v.RetweetContent);
                set.Bind(this.txtComment).To(v => v.CommentCount);
                set.Bind(this.txtLike).To(v => v.LikeCount);
                set.Bind(this.txtRepost).To(v => v.RepostCount);
                set.Bind(this.imgComment).To(v => v.ImageComment).WithConversion(Converter.StreamToUIImage);
                set.Bind(this.imgRepost).To(v => v.ImageRepost).WithConversion(Converter.StreamToUIImage);
                set.Bind(this.imgLike).To(v => v.ImageLike).WithConversion(Converter.StreamToUIImage);
                set.Bind(this.imgVerified).To(v => v.ImageVerified).WithConversion(Converter.StreamToUIImage);
                set.Bind(this.viewReply).For(x => x.Hidden).To("HasRetweetedStatus==false");
                set.Apply();
            });
            this.AddBindings(new Dictionary<object, string>
                            {
                                {imgSource, "ItemsSource ImageModels"}
                            });
            this.listImage.Source = this.imgSource;
            this.listImage.ReloadData();
        }

        private void BindingContext_DataContextChanged(object sender, EventArgs e)
        {
            var vm = this.DataContext as TimelineItemViewModel;
            if (vm != null)
            {
                this.imgPhoto.SetImage(new NSUrl(vm.ProfileUrl));
                //this.viewReplyHeight.Active = !vm.HasRetweetedStatus;
                this.listImage.ViewModel = vm;
                this.listImage.ReloadData();
                if (!string.IsNullOrEmpty(vm.RetweetedHeader))
                {
                    strAttr.ForegroundColor = Converter.ColorToUIColor.Convert(TimelineItemViewModel.RetweetColor) as UIColor;
                    this.UpdateRetweetColor(vm.RetweetedHeader, vm.RetweetContent);
                }
            }
            this.SetNeedsLayout();
        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            this.ContentView.SetNeedsLayout();
            this.ContentView.LayoutIfNeeded();

            this.txtContent.PreferredMaxLayoutWidth = this.txtContent.Frame.Width;
            this.txtReContent.PreferredMaxLayoutWidth = this.txtReContent.Frame.Width;
        }
        public override CGSize SystemLayoutSizeFittingSize(CGSize targetSize, float horizontalFittingPriority, float verticalFittingPriority)
        {
            CGSize size = base.SystemLayoutSizeFittingSize(targetSize, horizontalFittingPriority, verticalFittingPriority);
            var imgsSize = this.listImage.SystemLayoutSizeFittingSize(targetSize);
            return new CGSize(size.Width, size.Height + imgsSize.Height + 1);
        }
        void UpdateRetweetColor(string header, string txt)
        {
            NSMutableAttributedString attr = new NSMutableAttributedString();
            attr.BeginEditing();
            NSRange range = new NSRange(0, header.Length);
            attr.MutableString.SetString(new NSString(txt));
            attr.SetAttributes(this.strAttr, range);
            attr.EndEditing();
            this.txtReContent.AttributedText = attr;
        }
    }
    public class ImageCollectionSource: MvxCollectionViewSource
    {
        TimelineItemView itemView;
        public ImageCollectionSource(UICollectionView collectionView,TimelineItemView itemView)
            : base(collectionView, ImageViewCell.Key)
        {
            collectionView.RegisterNibForCell(ImageViewCell.Nib, ImageViewCell.Key);
            this.itemView = itemView;
        }
        protected override UICollectionViewCell GetOrCreateCellFor(UICollectionView collectionView, NSIndexPath indexPath, object item)
        {
            return collectionView.DequeueReusableCell(ImageViewCell.Key, indexPath) as UICollectionViewCell;
        }
        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            (this.itemView.DataContext as TimelineItemViewModel).ImageSelected?.Execute(indexPath.Row);
        }
    }
}
