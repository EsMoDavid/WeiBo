using System;

using Foundation;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using EsMo.Sina.SDK.Model;
using SDWebImage;
using System.Diagnostics;

namespace EsMo.iOS.WeiBo.Entity
{
    public partial class CommentItemView : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("CommentItemView");
        public static readonly UINib Nib;

        static CommentItemView()
        {
            Nib = UINib.FromName("CommentItemView", NSBundle.MainBundle);
        }

        protected CommentItemView(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            this.imgProfile.Layer.CornerRadius = imgProfile.Frame.Width / 2f;
            this.imgProfile.Layer.MasksToBounds = true;
            //this.imgReProfile.Layer.CornerRadius = imgProfile.Frame.Width / 2f;
            //this.imgReProfile.Layer.MasksToBounds = true;

            this.BindingContext.DataContextChanged += BindingContext_DataContextChanged;
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<CommentItemView, CommentItemViewModel>();
                set.Bind(this.txtName).To(vm => vm.Name);
                set.Bind(this.txtComment).To(vm => vm.Content);
                set.Bind(this.txtDesc).To(vm => vm.Desc);
                set.Apply();
            });
        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            Debug.WriteLine(this.txtComment);
            this.txtComment.PreferredMaxLayoutWidth = this.txtComment.Frame.Width;
            this.txtReContent.PreferredMaxLayoutWidth = this.txtReContent.Frame.Width;
        }
        private void BindingContext_DataContextChanged(object sender, EventArgs e)
        {
            CommentItemViewModel vm = this.DataContext as CommentItemViewModel;
            if(vm!=null) 
            {
                this.imgProfile.SetImage(new NSUrl(vm.ProfileUrl));
                this.txtComment.Text = vm.Content;
                if(vm.HasReplyComment)
                {
                    var replyModel = vm.ReplyComment;
                    this.txtReContent.Text = replyModel.Content;
                    this.imgReProfile.SetImage(new NSUrl(replyModel.ProfileUrl));
                    //this.imgReHeight.Constant = this.imgReWidth.Constant = 30;
                    return;
                }
            }
            //this.imgReHeight.Constant = this.imgReWidth.Constant = 0;
        }
    }
}
