using Android.Views;
using CheeseBind;
using EsMo.Sina.SDK.Model;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Views.Attributes;

namespace EsMo.Android.WeiBo.Entity
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.menu_frame)]
    public class MainMenuFragment : BaseFragment<MenuViewModel>
    {
        [BindView(Resource.Id.listmenu)]
        MvxListView listMenu;

        protected override int LayoutID => Resource.Layout.MainMenu;
        public override void OnViewModelSet()
        {
            base.OnViewModelSet();
        }

        protected override void OnInflated(View view)
        {
            Cheeseknife.Bind(this, view);
            MenuAdapter adapter = new MenuAdapter(this.Activity, this.BindingContext as IMvxAndroidBindingContext);
            adapter.ItemsSource = this.ViewModel.MenuItems;
            this.listMenu.Adapter = adapter;
        }
    }
}