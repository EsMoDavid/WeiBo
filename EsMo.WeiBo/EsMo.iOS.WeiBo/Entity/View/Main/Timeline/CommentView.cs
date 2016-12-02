using EsMo.MvvmCross.iOS.Support;
using EsMo.Sina.SDK.Model;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Support.SidePanels;
using System;
using System.Collections.Generic;
using UIKit;
using System.Collections;

namespace EsMo.iOS.WeiBo.Entity
{
    [MvxPanelPresentation(MvxPanelEnum.Center, MvxPanelHintType.ActivePanel, true,MvxSplitViewBehaviour.Detail)]
    public partial class CommentView : BaseView<CommentViewModel>
    {
        MvxTableViewSource source;
        public CommentView() : base("CommentView", null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.tableComment.RowHeight = UITableView.AutomaticDimension;
            this.tableComment.EstimatedRowHeight = 44;

            source = new MvxStandardTableViewSource(this.tableComment, CommentItemView.Key);
            tableComment.RegisterNibForCellReuse(UINib.FromName("CommentItemView", NSBundle.MainBundle), CommentItemView.Key);
            //source = new CommentSource(this.tableComment);

            this.AddBindings(new Dictionary<object, string>
                {
                    {source, "ItemsSource CommentItemViews"}
                });
            this.tableComment.Source = source;
            this.tableComment.ReloadData();
        }
        public class CommentSource:MvxTableViewSource
        {
            public CommentSource(UITableView table):base(table)
            {
                table.RegisterNibForCellReuse(UINib.FromName("CommentItemView", NSBundle.MainBundle), CommentItemView.Key);
            }

            protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
            {
                return tableView.DequeueReusableCell(CommentItemView.Key);
            }
        }
    }
}