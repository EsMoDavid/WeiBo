using EsMo.Sina.SDK.Model;
using EsMo.Sina.SDK.Resource;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Support.SidePanels;
using System;
using System.Diagnostics;
using UIKit;

namespace EsMo.iOS.WeiBo.Entity
{
    [MvxPanelPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot,true)]
    public partial class MainView : BaseView<MainViewModel>
    {
        TimelineView timelineView;
        public MainView() : base("MainView", null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // currently only a page here, so hide the indicator.
            this.viewPager.PageIndicatorTintColor = UIColor.Clear;
            this.viewPager.CurrentPageIndicatorTintColor = UIColor.Clear;

            this.NavigationController.NavigationBar.Items[0].SetRightBarButtonItem(null, false);
            this.timelineView = TimelineView.Create(this.ViewModel.TimelineViewModel);
            this.viewPager.Add(timelineView);
        }
        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            this.timelineView.Frame = this.viewPager.Frame;
        }
    }
}