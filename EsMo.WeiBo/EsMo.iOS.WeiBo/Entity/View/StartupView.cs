using EsMo.MvvmCross.iOS.Support.Converter;
using EsMo.Sina.SDK.Model;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Support.SidePanels;
using SDWebImage;

using UIKit;

namespace EsMo.iOS.WeiBo.Entity
{
    [MvxPanelPresentation(MvxPanelEnum.Center, MvxPanelHintType.ActivePanel, true)]
    public partial class StartupView : BaseView<StartupViewModel>
    {
        public StartupView() : base("StartupView", null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            this.ViewModel.StartupCommand.Execute(null);
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.imgProfile.Layer.CornerRadius = imgProfile.Frame.Width / 2f;
            this.imgProfile.Layer.MasksToBounds = true;
            var set = this.CreateBindingSet<StartupView, StartupViewModel>();
            set.Bind(this.txtStatus).To(vm => vm.StatusText);
            set.Bind(this.imgProfile).To(vm => vm.UnknownProfile).WithConversion(Converter.StreamToUIImage);

            //TODO: looks mvvm has not offer any support on binding notification action to callback;
            set.Bind(this).For(s=>s.IsLoggingIn).To(vm => vm.IsLoggingIn);
            set.Bind(this).For(s => s.ProfileUrl).To(vm => vm.ProfileUrl);
            set.Apply();
        }
        bool isLoggingIn;

        public bool IsLoggingIn
        {
            get
            {
                return isLoggingIn;
            }

            set
            {
                isLoggingIn = value;
                if (isLoggingIn)
                    this.activityView.StartAnimating();
                else
                    this.activityView.StopAnimating();
            }
        }
        string profileUrl;

        public string ProfileUrl
        {
            get
            {
                return profileUrl;
            }

            set
            {
                profileUrl = value;
                if (!string.IsNullOrEmpty(value))
                {
                    this.imgProfile.SetImage(new Foundation.NSUrl(value), (img, err, cacheType, url) =>
                     {
                         UIView.Transition(this.imgProfile, 0.25f, UIViewAnimationOptions.TransitionCrossDissolve,
                             () => this.imgProfile.Image = img,null);
                     });
                }
            }
        }
    }
}