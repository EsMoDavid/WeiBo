using Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;

namespace EsMo.iOS.Support
{
    public static class ViewExtension
    {
        public static void SetImageSource(this UIImageView imgView,Stream stream)
        {
            UIImage img = UIImage.LoadFromData(NSData.FromStream(stream), 1);
            imgView.Image = img;
        }
    }
}
