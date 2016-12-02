using EsMo.Sina.SDK.Resource;
using EsMo.Sina.SDK.Service;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EsMo.Sina.SDK.Model
{
    public class MainViewModel:BaseViewModel
    {
        public TimelineViewModel TimelineViewModel { get; set; }
        public MainViewModel()
        {
            this.Title = AppResources.Home;
            this.TimelineViewModel = new TimelineViewModel(Mvx.Resolve<IAccountService>());
        }
        
        public ICommand ShowMenuCommand
        {
            get
            {
                return new MvxCommand<string>(x => this.ShowViewModel<MenuViewModel>());
            }
        }
    }
}
