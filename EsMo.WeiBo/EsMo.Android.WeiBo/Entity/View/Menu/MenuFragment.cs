using Android.OS;
using Android.Support.Design.Widget;
using Android.Views;
using CheeseBind;
using EsMo.Sina.SDK.Model;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Shared.Attributes;
namespace EsMo.Android.WeiBo.Entity
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.menu_frame)]
    public class MainMenuFragment : BaseFragment<MenuViewModel>
    {
        [BindView(Resource.Id.listmenu)]
        MvxListView listMenu;
        public override void OnViewModelSet()
        {
            base.OnViewModelSet();
        }
        public override global::Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // must call the base.OnCreateView first.
            base.OnCreateView(inflater, container, savedInstanceState);
            var view= this.BindingInflate(Resource.Layout.MainMenu, null);
           
            Cheeseknife.Bind(this, view);
            MenuAdapter adapter = new MenuAdapter(this.Activity,  this.BindingContext as IMvxAndroidBindingContext);
            adapter.ItemsSource= this.ViewModel.MenuItems;
            this.listMenu.Adapter = adapter;
            return view;
        }
    }
}