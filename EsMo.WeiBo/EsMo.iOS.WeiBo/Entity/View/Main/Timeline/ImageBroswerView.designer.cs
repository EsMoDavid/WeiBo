// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using EsMo.iOS.Support.View;
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace EsMo.iOS.WeiBo.Entity
{
    [Register ("ImageBroswerView")]
    partial class ImageBroswerView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPageControl pgrMain { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView scrlMain { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (pgrMain != null) {
                pgrMain.Dispose ();
                pgrMain = null;
            }

            if (scrlMain != null) {
                scrlMain.Dispose ();
                scrlMain = null;
            }
        }
    }
}