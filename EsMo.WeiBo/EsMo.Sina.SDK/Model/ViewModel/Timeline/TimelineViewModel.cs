using EsMo.Sina.Model.Groups;
using EsMo.Sina.SDK.Service;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EsMo.Sina.SDK.Model
{
    public class TimelineViewModel : BaseViewModel
    {
        IAccountService accountService;
        public MvxCommand<TimelineItemViewModel> SelectedCommand { get; private set; }
        ObservableCollection<TimelineItemViewModel> timelineItems;
        public TimelineViewModel(IAccountService accountService)
        {
            this.accountService = accountService;
            this.SelectedCommand = new MvxCommand<TimelineItemViewModel>((vm) =>
              {
                  MvxBundle bundle = new MvxBundle();
                  bundle.Write(vm.Model);
                  this.ShowViewModel<CommentViewModel>(bundle);
              });
          
        }
        public ObservableCollection<TimelineItemViewModel> TimelineItems
        {
            get
            {
                if(this.timelineItems==null)
                {
                    this.timelineItems = new ObservableCollection<TimelineItemViewModel>();
                    var statuses = this.GetApplication().Account.Statuses;
                    this.SyncTimelineItems(statuses);
                }
                return this.timelineItems;
            }
        }
        List<Status> Statuses
        {
            get
            {
                return this.GetApplication().Account.Statuses;
            }
        }
        void SyncTimelineItems(List<Status> statuses)
        {
            foreach (var status in statuses)
            {
                this.TimelineItems.Add(new TimelineItemViewModel(status));
            }
        }
        public async Task<int> RequestNextPage()
        {
            if(this.Statuses!=null)
            {
                if (this.Statuses.Count > 0)
                {
                    var status = Statuses;
                    long firstID = status[0].ID;
                    long nextID = status.Last().ID - 1;
                    List<Status> nextPage =  await this.accountService.GetNextPageTimeline(firstID, nextID);
                    foreach (var item in nextPage)
                    {
                        status.Add(item);
                    }
                    this.SyncTimelineItems(nextPage);
                    return nextPage.Count;
                }
            }
            return 0;
        }
    }
}
