using EsMo.Sina.Model.Groups;
using EsMo.Sina.SDK.Service;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
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
        public IEnumerable<TimelineItemViewModel> TimelineItems
        {
            get
            {
                var statuses = this.GetApplication().Account.Statuses;
                foreach (var item in statuses)
                {
                    yield return new TimelineItemViewModel(item);
                }
            }
        }
        List<Status> Statuses
        {
            get
            {
                return this.GetApplication().Account.Statuses;
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
                    return nextPage.Count;
                }
            }
            return 0;
        }
    }
}
