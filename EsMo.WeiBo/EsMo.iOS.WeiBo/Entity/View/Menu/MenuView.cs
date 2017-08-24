using CoreGraphics;
using EsMo.iOS.Support;
using EsMo.Sina.SDK.Model;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Support.SidePanels;
using MvvmCross.iOS.Support.XamarinSidebar;
using MvvmCross.iOS.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UIKit;
using MvvmCross.Binding.iOS.Views;

namespace EsMo.iOS.WeiBo.Entity
{
    [MvxPanelPresentation(MvxPanelEnum.Left, MvxPanelHintType.ActivePanel, false)]
    public partial class MenuView : MvxViewController<MenuViewModel>, IMvxSidebarMenu
    {
        public MenuView() : base("MenuView", null)
        {
        }

        public bool HasShadowing => false;
        public UIImage MenuButtonImage => UIImage.FromBundle("threelines");
        public int MenuWidth => 220;
        

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var source = new MenuViewSource(this, this.tableMenu);
            this.AddBindings(new Dictionary<object, string>
                {
                    {source, "ItemsSource MenuItems"}
                });
            this.tableMenu.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            this.tableMenu.Source = source;
            this.tableMenu.ReloadData();
        }
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }
        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            this.tableMenu.Frame = new CGRect(0, 0, MenuWidth, this.View.Frame.Height);
        }
    }
    public class MenuViewSource : MvxTableViewSource
    {
        MenuView menuView;
        public MenuViewSource(MenuView menuView,UITableView tableView):base(tableView)
        {
            this.menuView = menuView;
            tableView.RegisterNibForCellReuse(UINib.FromName("MenuProfileView", NSBundle.MainBundle), MenuProfileView.Key);
            tableView.RegisterNibForCellReuse(UINib.FromName("MenuItemCell", NSBundle.MainBundle), MenuItemCell.Key);
        }
        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            if (indexPath.Row == 0)
            {
                return this.menuView.ViewModel.GetMenuProfileHeight(this.menuView.MenuWidth);
            }
            return 40;
        }
        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            NSString cellIdentifier=null;
            if (item is MenuProfileViewModel)
            {
                cellIdentifier = MenuProfileView.Key;
            }
            else if(item is MenuItemViewModel)
            {
                cellIdentifier = MenuItemCell.Key;
            }
            return TableView.DequeueReusableCell(cellIdentifier, indexPath);
        }
    }
}