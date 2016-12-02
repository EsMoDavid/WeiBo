using System;
using System.Collections.Generic;
using System.Text;
using CoreGraphics;
using UIKit;
using System.Diagnostics;
using Foundation;

namespace EsMo.iOS.Support.View
{
    public class LoadMoreCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("LoadMoreCell");

        const int Padding = 10;
        const int IndicatorSize = 20;
        public UILabel LabelCaption { get; private set; }
        UIActivityIndicatorView indicator;
        public LoadMoreCell(IntPtr handle) : base(handle)
        {
           
        }
        public LoadMoreCell(UITableViewCellStyle style, string reuseIdentifier) : base(style, reuseIdentifier)
        {
            this.Initial();
        }
      
        public LoadMoreCell(UITableViewCellStyle style, NSString reuseIdentifier):base(style,reuseIdentifier)
        {
            this.Initial();
        }

        void Initial()
        {
            indicator = new UIActivityIndicatorView();
            indicator.ActivityIndicatorViewStyle = UIActivityIndicatorViewStyle.Gray;
            this.LabelCaption = new UILabel();
            this.LabelCaption.TextAlignment = UITextAlignment.Center;
            this.LabelCaption.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            this.LabelCaption.AdjustsFontSizeToFitWidth = false;

            OwnerDrawView = new LoadMoreCellView();
            OwnerDrawView.LoadMore = true;
            this.ContentView.Add(OwnerDrawView);
            this.ContentView.AddSubview(LabelCaption);
            this.ContentView.AddSubview(indicator);
        }
        bool loading;
        public bool Loading
        {
            get
            {
                return loading;
            }

            set
            {
                loading = value;
                if (this.loading)
                    this.indicator.StartAnimating();
                else
                    this.indicator.StopAnimating();
            }
        }
        public LoadMoreCellView OwnerDrawView
        {
            get; private set;
        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            this.OwnerDrawView.Frame = this.ContentView.Frame;
            var sBounds = this.ContentView.Bounds;
            var size = GetTextSize(this.LabelCaption.Text,this.LabelCaption.Font);
            if(!indicator.Hidden)
            {
                indicator.Frame = new CGRect((sBounds.Width - size.Width) / 2 - IndicatorSize * 2, Padding, IndicatorSize, IndicatorSize);
            }
            LabelCaption.Frame = new CGRect(10, Padding, sBounds.Width - 20, size.Height);
        }
        CGSize GetTextSize(string text,UIFont font)
        {
            return new NSString(text).StringSize(font, UIScreen.MainScreen.Bounds.Width, UILineBreakMode.TailTruncation);
        }
    }

    public class LoadMoreCellView:UIView
    {
        public LoadMoreCellView()
        {
            this.AutosizesSubviews = true;
            this.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            this.BackgroundColor = UIColor.Clear;
        }
        public bool LoadMore { get; set; }
        public Action OnGetMore { get; set; }
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            //Debug.WriteLine("LoadMore drawing");
            if(this.LoadMore)
            {
                if (this.OnGetMore != null)
                    this.OnGetMore();
            }
        }
    }
}
