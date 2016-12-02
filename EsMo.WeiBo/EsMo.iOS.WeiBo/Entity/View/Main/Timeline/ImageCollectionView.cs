using CoreGraphics;
using EsMo.Sina.SDK.Model;
using Foundation;
using System;
using System.Diagnostics;
using UIKit;

namespace EsMo.iOS.WeiBo.Entity
{
    public partial class ImageCollectionView : UICollectionView
    {
        public TimelineItemViewModel ViewModel { get; set; }
        public LeftAlignedFlowLayout FlowLayout { get; private set; }
        public NSLayoutConstraint Height { get; set; }
        public ImageCollectionView(CGRect frame, UICollectionViewLayout layout) : base(frame, layout)
        {
            this.Initial();
        }
        public ImageCollectionView(IntPtr handle) : base(handle)
        {
            this.Initial();
        }
      
        public void Initial()
        {
            this.FlowLayout = new LeftAlignedFlowLayout();
            this.ScrollEnabled = false;
            this.CollectionViewLayout = FlowLayout;
            this.FlowLayout.MinimumInteritemSpacing = 1;
            this.FlowLayout.MinimumLineSpacing = 1;
        }
        public override CGSize SystemLayoutSizeFittingSize(CGSize targetSize, float horizontalFittingPriority, float verticalFittingPriority)
        {
            if (this.ViewModel != null)
            {
                // comment the following codes out will get a wrong frame.width;
                this.SetNeedsLayout();
                this.LayoutIfNeeded();

                double itemSize = 0;
                double renderHeight = this.ViewModel.GetImageModelsHeight(this.Frame.Width, out itemSize);
                if(this.Frame.Width!=300)
                {

                }
                this.FlowLayout.ItemSize = new CGSize(itemSize, itemSize);
                return base.SystemLayoutSizeFittingSize(new CGSize(this.Frame.Width, renderHeight), horizontalFittingPriority, verticalFittingPriority);
            }
            return base.SystemLayoutSizeFittingSize(targetSize, horizontalFittingPriority, verticalFittingPriority);
        }
    }
    public class LeftAlignedFlowLayout : UICollectionViewFlowLayout
    {
        public override UICollectionViewLayoutAttributes[] LayoutAttributesForElementsInRect(CGRect rect)
        {
            var attributes = base.LayoutAttributesForElementsInRect(rect);
            var leftMargin = this.SectionInset.Left;
            double maxY = -1.0F;
            foreach (var layoutAttribute in attributes)
            {
                if (layoutAttribute.Frame.Y >= maxY)
                {
                    leftMargin = this.SectionInset.Left;
                }

                layoutAttribute.Frame = new CGRect(leftMargin, layoutAttribute.Frame.Y, layoutAttribute.Frame.Width, layoutAttribute.Frame.Height);
                leftMargin += layoutAttribute.Frame.Width+this.MinimumInteritemSpacing;
                maxY = Math.Max(layoutAttribute.Frame.GetMaxY(), maxY);
            }
            return attributes;
        }
    }
}
