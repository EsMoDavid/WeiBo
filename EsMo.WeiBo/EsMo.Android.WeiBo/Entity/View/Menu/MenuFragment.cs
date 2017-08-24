using Android.OS;
using Android.Views;
using EsMo.Sina.SDK.Model;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
namespace EsMo.Android.WeiBo.Entity
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.menu_frame)]
    public class MainMenuFragment : BaseFragment<MenuViewModel>
    {
        public override void OnViewModelSet()
        {
            base.OnViewModelSet();
        }
        public override global::Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // must call the base.OnCreateView first.
            base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.MainMenu, null);
        }
    }
}