using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using EsMo.Sina.SDK.Resource;
using EsMo.Sina.Model.Groups;
using EsMo.Sina.SDK.Service;

namespace EsMo.Sina.SDK.Model
{
    public class CommentViewModel : BaseViewModel
    {
        IAccountService accountService;
        IEnumerable<Comment> comments;

        public List<CommentItemViewModel> CommentItemViews
        {
            get
            {
                // ItemsSource does not support IEnumerable !! 
                //foreach (var item in comments)
                //{
                //    yield return new CommentItemViewModel(item);
                //}
                return (from item in comments select new CommentItemViewModel(item)).ToList();
            }
        }

        public CommentViewModel(IAccountService accountService)
        {
            this.Title = AppResources.Comment;
            this.accountService = accountService;
        }
        protected async override void InitFromBundle(IMvxBundle parameters)
        {
            base.InitFromBundle(parameters);
            var currentStatus = parameters.Read<Status>();
            this.comments = await this.accountService.GetComments(currentStatus);
        }
    }
}
