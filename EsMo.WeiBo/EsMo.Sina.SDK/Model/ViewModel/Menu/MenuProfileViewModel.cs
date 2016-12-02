using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Sina.SDK.Model
{
    public class MenuProfileViewModel : MenuItemViewModel //MvxNotifyPropertyChanged
    {
        Stream backgroundBanner;
        public Stream BackgroundBanner
        {
            get { return backgroundBanner; }
            set
            {
                if (backgroundBanner != value)
                {
                    backgroundBanner = value;
                    RaisePropertyChanged(() => BackgroundBanner);
                }
            }
        }
        string avatarUrl;
        public string AvatarUrl
        {
            get
            {
                return avatarUrl;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref this.avatarUrl, value, () => this.AvatarUrl);
            }
        }

     
        public MenuProfileViewModel(MenuType menuType) : base(menuType)
        {
            this.BackgroundBanner = this.GetApplication().ResourceCache.Get(AssetsHelper.bg_banner_dialog.ToAssetsImage());
            this.AvatarUrl = this.GetApplication().Account.Show.AvatarLarge;
            this.Text = this.GetApplication().Account.Show.ActualGeneralName;
            //this.Icon = this.GetApplication().Account.Show.AvatarLarge;
            //this.Icon = this.userShow;
        }
    }
}
