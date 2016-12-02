using MvvmCross.Binding.iOS.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using UIKit;
using MvvmCross.Binding.ExtensionMethods;
using EsMo.iOS.Support.View;

namespace EsMo.MvvmCross.iOS.Support
{
    public abstract class LoadMoreTableSource : MvxTableViewSource
    {
        public string CellCaption { get; set; } = string.Empty;
        protected virtual int LoadMoreSectionIndex { get; } = 1;
        public event EventHandler OnGetMore;

        protected LoadMoreTableSource(UITableView tableView) : base(tableView)
        {

        }
        protected LoadMoreTableSource(IntPtr handle) : base(handle)
        {

        }
        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            if(indexPath.Section==this.LoadMoreSectionIndex)
            {
                var loadMoreCell= tableView.DequeueReusableCell(LoadMoreCell.Key) as LoadMoreCell;
                if(loadMoreCell==null)
                {
                    loadMoreCell = new LoadMoreCell(UITableViewCellStyle.Default, LoadMoreCell.Key);
                    loadMoreCell.LabelCaption.Text = CellCaption;
                    loadMoreCell.OwnerDrawView.OnGetMore = this.InvokeOnGetMore;
                    loadMoreCell.Loading = true;
                }
                else
                {
                    loadMoreCell.SetNeedsDisplay();
                    loadMoreCell.OwnerDrawView.SetNeedsDisplay();
                }
                return loadMoreCell;
            }
            return null;
        }
        void InvokeOnGetMore()
        {
            this.OnGetMore?.Invoke(this, EventArgs.Empty);
        }
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            if (section == this.LoadMoreSectionIndex)
            {
                return 1;
            }
            return this.ItemsSource.Count();
        }
        public override nint NumberOfSections(UITableView tableView)
        {
            return 2;
        }
    }
}