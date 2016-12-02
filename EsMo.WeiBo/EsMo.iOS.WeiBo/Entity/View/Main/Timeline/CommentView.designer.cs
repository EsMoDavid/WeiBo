// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace EsMo.iOS.WeiBo.Entity
{
    [Register ("CommentView")]
    partial class CommentView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tableComment { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (tableComment != null) {
                tableComment.Dispose ();
                tableComment = null;
            }
        }
    }
}