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
    [Register ("TimelineItemView")]
    partial class TimelineItemView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgBackground { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgComment { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgLike { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgPhoto { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgRepost { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgVerified { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        EsMo.iOS.WeiBo.Entity.ImageCollectionView listImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView rootContainer { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel txtComment { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel txtContent { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel txtDesc { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel txtLike { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel txtName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel txtReContent { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel txtRepost { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewReply { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint viewReplyHeight { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgBackground != null) {
                imgBackground.Dispose ();
                imgBackground = null;
            }

            if (imgComment != null) {
                imgComment.Dispose ();
                imgComment = null;
            }

            if (imgLike != null) {
                imgLike.Dispose ();
                imgLike = null;
            }

            if (imgPhoto != null) {
                imgPhoto.Dispose ();
                imgPhoto = null;
            }

            if (imgRepost != null) {
                imgRepost.Dispose ();
                imgRepost = null;
            }

            if (imgVerified != null) {
                imgVerified.Dispose ();
                imgVerified = null;
            }

            if (listImage != null) {
                listImage.Dispose ();
                listImage = null;
            }

            if (rootContainer != null) {
                rootContainer.Dispose ();
                rootContainer = null;
            }

            if (txtComment != null) {
                txtComment.Dispose ();
                txtComment = null;
            }

            if (txtContent != null) {
                txtContent.Dispose ();
                txtContent = null;
            }

            if (txtDesc != null) {
                txtDesc.Dispose ();
                txtDesc = null;
            }

            if (txtLike != null) {
                txtLike.Dispose ();
                txtLike = null;
            }

            if (txtName != null) {
                txtName.Dispose ();
                txtName = null;
            }

            if (txtReContent != null) {
                txtReContent.Dispose ();
                txtReContent = null;
            }

            if (txtRepost != null) {
                txtRepost.Dispose ();
                txtRepost = null;
            }

            if (viewReply != null) {
                viewReply.Dispose ();
                viewReply = null;
            }

            if (viewReplyHeight != null) {
                viewReplyHeight.Dispose ();
                viewReplyHeight = null;
            }
        }
    }
}