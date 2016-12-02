using Foundation;
using System;
using UIKit;
using CoreGraphics;

namespace EsMo.iOS.WeiBo.Entity
{
    public partial class TopAlignLabel : UILabel
    {
        public TopAlignLabel(IntPtr handle) : base(handle)
        {

        }
        public override void DrawText(CGRect rect)
        {
            if (this.Text != null)
            {
                NSString text = new NSString(this.Text);
                CGSize size = text.GetSizeUsingAttributes(new UIStringAttributes() { Font = this.Font });
                base.DrawText(new CGRect(0, 0, this.Frame.Width, size.Width));
            }
            else
                base.Draw(rect);
        }
        public override void PrepareForInterfaceBuilder()
        {
            base.PrepareForInterfaceBuilder();
            this.Layer.BorderWidth = 1;
            this.Layer.BorderColor = UIColor.Black.CGColor;
        }
    }
}