using CoreGraphics;
using Foundation;
using SDWebImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace EsMo.iOS.WeiBo.Entity
{
    public partial class ImageScrollView : UIScrollView
    {
        bool TileImagesMode = true;

        public Func<int, Task<UIImage> > GetImage { get; set; }
        CGSize _imageSize;
        // if tiling this contains a very low-res placeholder image. otherwise it contains the full image.
        UIImageView zoomView;
        //TilingView tilingView;
        CGPoint _pointToCenterAfterResize;
        nfloat _scaleToRestoreAfterResize;
        public ImageScrollView (CGRect frame):base(frame)
        {
            this.Initial();
        }
        public ImageScrollView(IntPtr handle) : base(handle)
        {
            this.Initial();
        }
        public ImageScrollView()
        {
            this.Initial();
        }
        string[] imgUrls;
        public string[] ImageUrls
        {
            get
            {
                return this.imgUrls;
            }
            set
            {
                this.imgUrls = value;
                if (this.imgUrls != null)
                    this.DisplayImage(this.ImageUrls[Index]);
            }
        }

        void Initial()
        {
            ShowsVerticalScrollIndicator = false;
            ShowsHorizontalScrollIndicator = false;
            BouncesZoom = true;
            DecelerationRate = UIScrollView.DecelerationRateFast;

            // Return the view to use when zooming
            ViewForZoomingInScrollView = (sv) => zoomView;
        }
        //public int ImageCount
        //{
        //    get
        //    {
        //        return ImageData.Count;
        //    }
        //}


        //List<UIImage> imageData;
        //public List<UIImage> ImageData
        //{
        //    get
        //    {
        //        return this.imageData;
        //    }
        //    set
        //    {
        //        this.imageData = value;
        //        if(this.imageData!=null)
        //            this.DisplayImage(ImageAtIndex(Index));
        //    }
        //}

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

        public int Index { get; set; }

      
      
        //public int Index
        //{
        //    get
        //    {
        //        return _index;
        //    }
        //    set
        //    {
        //        _index = value;

        //        //if (TileImagesMode)
        //        //    DisplayTiledImageNamed(ImageNameAtIndex(_index), ImageSizeAtIndex(_index));
        //        //else
        //        DisplayImage(ImageAtIndex(_index));
        //    }
        //}

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            if (this.zoomView == null) return;
            //center the zoom view as it becomes smaller than the size of the screen
            var boundsSize = this.Bounds.Size;
            var frameToCenter = zoomView.Frame;

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

            zoomView.Frame = frameToCenter;
            this.DisplayImage(this.ImageUrls[Index]);
        }

        // - Configure scrollView to display new image (tiled or not)
        public void DisplayTiledImageNamed(string imageName, CGSize image_Size)
        {
            //clear views for the previous image
            if (zoomView != null)
            {
                zoomView.RemoveFromSuperview();
                zoomView = null;
                //tilingView = null;
            }
            ZoomScale = 1.0f;

            //make views to display the new image
            zoomView = new UIImageView(new CGRect(CGPoint.Empty, image_Size))
            {
                //Image = PlaceholderImageNamed(imageName)
            };

            AddSubview(zoomView);
            //tilingView = new TilingView(imageName, image_Size)
            //{
            //    Frame = zoomView.Bounds
            //};

            //zoomView.AddSubview(tilingView);
            ConfigureForImageSize(image_Size);
        }

        public void DisplayImage(string url)
        {
            if (url == null)
                throw new ArgumentNullException("image");

            if (zoomView != null)
            {
                zoomView.RemoveFromSuperview();
                zoomView = null;
                ZoomScale = 1.0f;
            }
            SDWebImageManager.SharedManager.Download(new Foundation.NSUrl(url),
                      SDWebImageOptions.CacheMemoryOnly, null, (image, error, cacheType, finished, imageUrl) =>
                      {
                          zoomView = new UIImageView(image);
                          AddSubview(zoomView);
                          ConfigureForImageSize(image.Size);
                      });
        }

        public void ConfigureForImageSize(CGSize imageSize)
        {
            _imageSize = imageSize;
            ContentSize = imageSize;
            SetMaxMinZoomScalesForCurrentBounds();
            //ZoomScale = MinimumZoomScale;
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
            _pointToCenterAfterResize = ConvertPointToView(boundsCenter, zoomView);
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
            var boundsCenter = this.ConvertPointFromView(_pointToCenterAfterResize, zoomView);
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

      



        //CGSize ImageSizeAtIndex(int index)
        //{
        //    return ImageData[index].Size;
        //}

        //UIImage PlaceholderImageNamed(string name)
        //{
        //    string placeholderName = string.Format("{0}_Placeholder", name);
        //    string placeholderNameWithExt = Path.ChangeExtension(placeholderName, "png");
        //    string fullName = Path.Combine("Image", "PlaceholderImages", placeholderNameWithExt);

        //    UIImage img = UIImage.FromBundle(fullName);
        //    return img;
        //}

        //List<UIImage> FetchImageData()
        //{
        //    //List<ImageDetails> result = null;
        //    //string path = Path.Combine("Image", "ImageDetails.xml");

        //    //try
        //    //{
        //    //    using (TextReader reader = new StreamReader(path))
        //    //    {
        //    //        XmlSerializer serializer = new XmlSerializer(typeof(List<ImageDetails>));
        //    //        result = (List<ImageDetails>)serializer.Deserialize(reader);
        //    //    }
        //    //}
        //    //catch (XmlException e)
        //    //{
        //    //    Console.WriteLine(e);
        //    //}
        //    //return result;
        //}
    }
}