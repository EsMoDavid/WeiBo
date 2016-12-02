using EsMo.Sina.SDK.Model;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using System;
using System.Collections.Generic;
using UIKit;
using System.Linq;
using System.Collections;
using System.Diagnostics;
using MvvmCross.Binding.ExtensionMethods;
using EsMo.iOS.Support.View;
using EsMo.MvvmCross.iOS.Support;
using System.Threading.Tasks;

namespace EsMo.iOS.WeiBo.Entity
{
    public partial class TimelineView:MvxView
    {
        UIRefreshControl refreshControl;
        UITableView tableTimeline;
        public TimelineViewModel viewModel;
        public static readonly UINib Nib;
        static TimelineView()
        {
            Nib = UINib.FromName("TimelineView", NSBundle.MainBundle);
        }
        public TimelineView()
        {

        }
        public TimelineView (IntPtr handle) : base (handle)
        {
        }

        public static TimelineView Create(TimelineViewModel viewModel)
        {
            TimelineView view = Nib.Instantiate(null, null)[0] as TimelineView ;
            view.SetViewModel(viewModel);
            return view;
        }
        private void SetViewModel(TimelineViewModel viewModel)
        {
            this.viewModel = viewModel;
            var source = new TimelineSource(this, this.tableTimeline);
            source.CellCaption = "加载中...";
            source.ItemsSource =this.viewModel.TimelineItems;
            source.OnGetMore += Source_OnGetMore;
            this.tableTimeline.Source = source;
        }
        private async void Source_OnGetMore(object sender, EventArgs e)
        {
            int count = await this.viewModel.RequestNextPage();
            await Task.Delay(2000);
            (this.tableTimeline.Source as TimelineSource).ItemsSource = this.viewModel.TimelineItems;
            this.tableTimeline.ReloadData();
        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            this.refreshControl = new UIRefreshControl();
            this.tableTimeline = new UITableView();
            this.tableTimeline.EstimatedRowHeight = 80;
            this.tableTimeline.RowHeight = UITableView.AutomaticDimension;
            this.Add(this.tableTimeline);
        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            this.tableTimeline.Frame = this.Frame;
        }
    }
    public class TimelineSource : LoadMoreTableSource
    {
        TimelineView timelineView;
        public TimelineSource(TimelineView timelineView, UITableView tableView):base(tableView)
        {
            this.timelineView = timelineView;
            tableView.RegisterNibForCellReuse(UINib.FromName("TimelineItemView", NSBundle.MainBundle), TimelineItemView.Key);
        }
        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            if (indexPath.Section == 0)
            {
                return TableView.DequeueReusableCell(TimelineItemView.Key, indexPath);
            }
            else
            {
                return base.GetOrCreateCellFor(tableView, indexPath, item);
            }
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var viewModel= this.GetItemAt(indexPath) as TimelineItemViewModel;
            this.timelineView.viewModel.SelectedCommand.Execute(viewModel);
        }
    }
}