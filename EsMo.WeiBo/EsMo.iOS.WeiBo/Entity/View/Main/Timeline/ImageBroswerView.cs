using CoreGraphics;
using EsMo.Sina.SDK.Model;
using MvvmCross.Dialog.iOS;
using MvvmCross.iOS.Support.SidePanels;
using SDWebImage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UIKit;

namespace EsMo.iOS.WeiBo.Entity
{
    [MvxPanelPresentation(MvxPanelEnum.Center, MvxPanelHintType.ActivePanel, true, MvxSplitViewBehaviour.Detail)]
    public partial class ImageBroswerView : BaseView<ImageBrowserViewModel>
    {
        int imageCount { get { return this.ViewModel.ImageUrls.Length; } }
        List<ImageContainer> Images = new List<ImageContainer>();
        public ImageBroswerView() : base("ImageBroswerView", null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.NavigationController.NavigationBar.Translucent = false;
            pgrMain.Pages = this.imageCount;
            pgrMain.ValueChanged += HandlePgrMainValueChanged;
            scrlMain.Scrolled += HandleScrlMainScrolled;
            InitImageViews();
            this.SetupImages();
            this.pgrMain.CurrentPage = this.ViewModel.CurrentIndex;
        }
       
        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            this.UpdateItemsFrame();
            this.SyncCurrentPage(false);
        }
        void SetupImages()
        {
            for (int i = 0; i < this.imageCount; i++)
            {
                string url = this.ViewModel.ImageUrls[i];
                var imgContainer = this.Images[i];
                imgContainer.ZoomView.SetImage(new Foundation.NSUrl(url), (image, error, cacheType, imageUrl) =>
                {
                    imgContainer.UpdateSize(image);
                });
            }
        }

        void HandlePgrMainValueChanged(object sender, EventArgs e)
        {
            // it moves page by page. we scroll right to the next controller
            this.SyncCurrentPage(true);
        }
        void HandleScrlMainScrolled(object sender, EventArgs e)
        {
            // calculate the page number
            int pageNumber = (int)(Math.Floor((scrlMain.ContentOffset.X - scrlMain.Frame.Width / 2) / scrlMain.Frame.Width) + 1);

            // if it's a valid page
            if (pageNumber >= 0 && pageNumber < Images.Count)
                pgrMain.CurrentPage = pageNumber;
        }
        void SyncCurrentPage(bool animated)
        {
            scrlMain.ScrollRectToVisible(Images[(int)(this.pgrMain).CurrentPage].Frame, animated);
        }

        void InitImageViews()
        {
            for (int i = 0; i < this.imageCount; i++)
            {
                ImageContainer image = new ImageContainer();
                image.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
                this.Images.Add(image);
                scrlMain.AddSubview(image);
            }
        }
        void UpdateItemsFrame()
        {
            for (int i = 0; i < this.imageCount; i++)
            {
                CGRect viewFrame = new CGRect(
                                       scrlMain.Frame.Width * i,
                                       scrlMain.Frame.Y,
                                       scrlMain.Frame.Width,
                                       scrlMain.Frame.Height);
                this.Images[i].Frame = viewFrame;
                this.Images[i].SetNeedsLayout();
                this.Images[i].LayoutIfNeeded();
            }
            scrlMain.ContentSize = new CGSize(
              scrlMain.Frame.Width * this.Images.Count, scrlMain.Frame.Height);
        }
    }
    public class ImageContainer:UIScrollView
    {
        CGSize _imageSize;
        CGPoint _pointToCenterAfterResize;
        nfloat _scaleToRestoreAfterResize;
        public override CGRect Frame
        {
            get
            {
                return base.Frame;
            }
            set
            {
                bool sizeChanging = Frame.Size != value.Size;
                if (sizeChanging)
                    PrepareToResize();

                base.Frame = value;

                if (sizeChanging)
                    RecoverFromResizing();
            }
        }
       
        public ImageContainer()
        {
            this.ScrollEnabled = false;
            ShowsVerticalScrollIndicator = false;
            ShowsHorizontalScrollIndicator = false;
            BouncesZoom = true;
            DecelerationRate = UIScrollView.DecelerationRateFast;

            ViewForZoomingInScrollView = (sv) => ZoomView;
            this.BackgroundColor = UIColor.Black;
            ZoomView = new UIImageView();
            AddSubview(ZoomView);
        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            
            var image = this.ZoomView.Image;
            if (image == null) return;
            ConfigureForImageSize(image.Size);
            //center the zoom view as it becomes smaller than the size of the screen
            var boundsSize = this.Bounds.Size;
            var frameToCenter = new CGRect(this.ZoomView.Frame.Location,this.ZoomView.Image.Size);

            //center horizontally
            if (frameToCenter.Size.Width < boundsSize.Width)
                frameToCenter.X = (boundsSize.Width - frameToCenter.Size.Width) / 2;
            else
                frameToCenter.X = 0;

            //center vertically
            if (frameToCenter.Size.Height < boundsSize.Height)
                frameToCenter.Y = (boundsSize.Height - frameToCenter.Size.Height) / 2;
            else
                frameToCenter.Y = 0;

            ZoomView.Frame = frameToCenter;
        }
        public UIImageView ZoomView { get; private set; }
        public void UpdateSize(UIImage image)
        {
            this.ZoomView.Frame = new CGRect(CGPoint.Empty, image.Size);
            this.ZoomView.SetNeedsLayout();
            this.ZoomView.LayoutIfNeeded();
        }
        public void ConfigureForImageSize(CGSize imageSize)
        {
            _imageSize = imageSize;
            ContentSize = imageSize;
            SetMaxMinZoomScalesForCurrentBounds();
            ZoomScale = MinimumZoomScale;
        }
        public void SetMaxMinZoomScalesForCurrentBounds()
        {
            CGSize boundsSize = Bounds.Size;

            //calculate min/max zoomscale
            nfloat xScale = boundsSize.Width / _imageSize.Width; //scale needed to perfectly fit the image width-wise
            nfloat yScale = boundsSize.Height / _imageSize.Height; //scale needed to perfectly fit the image height-wise

            //fill width if the image and phone are both portrait or both landscape; otherwise take smaller scale
            bool imagePortrait = _imageSize.Height > _imageSize.Width;
            bool phonePortrait = boundsSize.Height > boundsSize.Width;
            var minScale = (nfloat)(imagePortrait == phonePortrait ? xScale : NMath.Min(xScale, yScale));

            //on high resolution screens we have double the pixel density, so we will be seeing every pixel if we limit the maximum zoom scale to 0.5
            nfloat maxScale = 1 / UIScreen.MainScreen.Scale;

            if (minScale > maxScale)
                minScale = maxScale;

            // don't let minScale exceed maxScale. (If the image is smaller than the screen, we don't want to force it to be zoomed.)
            MaximumZoomScale = maxScale;
            MinimumZoomScale = minScale;
        }

        // Methods called during rotation to preserve the zoomScale and the visible portion of the image

        // Rotation support
        public void PrepareToResize()
        {
            var boundsCenter = new CGPoint(Bounds.GetMidX(), Bounds.GetMidY());
            _pointToCenterAfterResize = ConvertPointToView(boundsCenter, ZoomView);
            _scaleToRestoreAfterResize = ZoomScale;
            // If we're at the minimum zoom scale, preserve that by returning 0, which will be converted to the minimum
            // allowable scale when the scale is restored.
            if (_scaleToRestoreAfterResize <= this.MinimumZoomScale + float.Epsilon)
                _scaleToRestoreAfterResize = 0;
        }

        public void RecoverFromResizing()
        {
            SetMaxMinZoomScalesForCurrentBounds();

            //Step 1: restore zoom scale, first making sure it is within the allowable range;
            ZoomScale = NMath.Min(MaximumZoomScale, NMath.Max(MinimumZoomScale, _scaleToRestoreAfterResize));

            // Step 2: restore center point, first making sure it is within the allowable range.
            // 2a: convert our desired center point back to our own coordinate space
            var boundsCenter = this.ConvertPointFromView(_pointToCenterAfterResize, ZoomView);
            // 2b: calculate the content offset that would yield that center point
            CGPoint offset = new CGPoint(boundsCenter.X - Bounds.Size.Width / 2.0f, boundsCenter.Y - Bounds.Size.Height / 2.0f);
            // 2c: restore offset, adjusted to be within the allowable range
            CGPoint maxOffset = MaximumContentOffset();
            CGPoint minOffset = MinimumContentOffset();
            offset.X = NMath.Max(minOffset.X, NMath.Min(maxOffset.X, offset.X));
            offset.Y = NMath.Max(minOffset.Y, NMath.Min(maxOffset.Y, offset.Y));
            ContentOffset = offset;
        }
        public CGPoint MaximumContentOffset()
        {
            CGSize contentSize = ContentSize;
            CGSize boundsSize = Bounds.Size;
            return new CGPoint(contentSize.Width - boundsSize.Width, contentSize.Height - boundsSize.Height);
        }

        public CGPoint MinimumContentOffset()
        {
            return CGPoint.Empty;
        }

    }
}