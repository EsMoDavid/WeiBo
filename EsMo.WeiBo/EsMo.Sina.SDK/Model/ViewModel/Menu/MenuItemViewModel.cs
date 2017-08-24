using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Sina.SDK.Model
{
    public class MenuItemViewModel : MvxNotifyPropertyChanged
    {
        string text;
        public string Text
        {
            get
            {
                return text;
            }
            protected set
            {
                this.RaiseAndSetIfChanged(ref text, value, () => this.Text);
            }
        }
        public MenuType MenuType { get; private set; }
        Stream icon;
        public Stream Icon
        {
            get
            {
                return icon;
            }
            protected set
            {
                 this.RaiseAndSetIfChanged(ref icon, value, () => this.Icon);
            }
        }

        public MenuItemViewModel(MenuType menuType, string iconPath = "")
        {
            if (!string.IsNullOrEmpty(iconPath))
            {
                string path = iconPath.ToAssetsImage();
                this.Icon = this.GetApplication().ResourceCache.Get(path);
            }
            this.MenuType = menuType;
            this.Text = this.MenuType.GetResourceString();
        }
    }
    public enum MenuType
    {
        UserProfile,
        Home,
        Mention,
        Comment,
        SNS,
        Setting,
        Draft,
        Favorite,
        HotTopic,
    }
}
