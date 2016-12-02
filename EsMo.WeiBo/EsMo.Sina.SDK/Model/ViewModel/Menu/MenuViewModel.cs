using EsMo.Sina.SDK.Service;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Sina.SDK.Model
{
    public class MenuViewModel:BaseViewModel
    {
        IApplicationService appService;
        MenuProfileViewModel menuProfileViewModel;
        const double profileViewModelHeight=316d/560d;
        public MenuProfileViewModel MenuProfileViewModel
        {
            get { return this.menuProfileViewModel; }
            private set { this.menuProfileViewModel = value; RaisePropertyChanged(() => MenuProfileViewModel); }
        }

        public List<MenuItemViewModel> MenuItems
        {
            get
            {
                return menuItems;
            }

            set
            {
                if (MenuItems != value)
                {
                    menuItems = value;
                    this.RaisePropertyChanged(() => this.MenuItems);
                }
            }
        }

        List<MenuItemViewModel> menuItems;
        

        public MenuViewModel(IApplicationService appService)
        {
            this.appService = appService;
            this.MenuItems = new List<MenuItemViewModel>()
            {
                new MenuProfileViewModel(MenuType.UserProfile),
                new MenuItemViewModel(MenuType.Home,AssetsHelper.ic_view_day_grey600_24dp),
                new MenuItemViewModel(MenuType.Mention,AssetsHelper.ic_drawer_at),
                new MenuItemViewModel(MenuType.Comment,AssetsHelper.ic_question_answer_grey600_24dp),
                new MenuItemViewModel(MenuType.SNS),
                new MenuItemViewModel(MenuType.Setting),
                new MenuItemViewModel(MenuType.Draft),
                new MenuItemViewModel(MenuType.Favorite),
                new MenuItemViewModel(MenuType.HotTopic),
            };
        }
        public int GetMenuProfileHeight(double width)
        {
            return (int)(width * profileViewModelHeight);
        }
    }
}
