using CoreGraphics;
using EsMo.Sina.SDK.Model;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Support.SidePanels;
using MvvmCross.iOS.Support.XamarinSidebar;
using System;
using System.Diagnostics;
using UIKit;

namespace EsMo.iOS.WeiBo.Entity
{
    [MvxPanelPresentation(MvxPanelEnum.Left, MvxPanelHintType.ActivePanel, false)]
    public partial class MenuView : BaseView<MenuViewModel>, IMvxSidebarMenu
    {
        MenuProfileView menuProfile;
        public bool HasShadowing => false;
        public UIImage MenuButtonImage => UIImage.FromBundle("threelines");
        public int MenuWidth => 200;

        public MenuView() : base("MenuView", null)
        {

        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            menuProfile = MenuProfileView.Create();
            var set = this.CreateBindingSet<MenuView, MenuViewModel>();
            set.Bind(menuProfile).For(x => x.DataContext).To(v => v.MenuProfileViewModel);
            set.Apply();
            this.Add(menuProfile);
        }
    }
}