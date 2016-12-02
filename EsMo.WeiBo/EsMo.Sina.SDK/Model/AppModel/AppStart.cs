using MvvmCross.Core.ViewModels;

namespace EsMo.Sina.SDK.Model
{
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        public void Start(object hint = null)
        {
            if (hint?.ToString() == "TestUI")
            {
                // Note: must show menu view first,
                // if not, menu view info (menu image, menu width) will be loaded incorrectly
                this.ShowViewModel<MenuViewModel>();
                this.ShowViewModel<MainViewModel>();
            }
            else
                this.ShowViewModel<LoginViewModel>();
        }
    }
}
