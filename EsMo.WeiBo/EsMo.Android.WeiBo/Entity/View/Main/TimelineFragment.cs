using Android.OS;
using Android.Runtime;
using Android.Views;
using CheeseBind;
using EsMo.MvvmCross.Android.Support;
using EsMo.Sina.SDK.Model;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace EsMo.Android.WeiBo.Entity
{
    [Register("esmo.android.weibo.entity.TimelineFragment")]
    public class TimelineFragment : BaseFragment<TimelineViewModel>
    {
        [BindView(Resource.Id.listTimeLine)]
        private RefreshMvxRecyclerView listTimeLine;
        protected override int LayoutID => Resource.Layout.TimelineView;

        public TimelineFragment()
        {
        }
        protected override void OnInflated(View view)
        {
            base.OnInflated(view);
            this.listTimeLine.Adapter = new TimelineAdapter(this.BindingContext as IMvxAndroidBindingContext);
            this.listTimeLine.Adapter.ItemsSource = this.ViewModel.TimelineItems;
            this.listTimeLine.OnBottomRefreshing += ListTimeLine_OnBottomRefreshing;
        }
        private async void ListTimeLine_OnBottomRefreshing(object sender, System.EventArgs e)
        {
            await this.ViewModel.RequestNextPage();
            this.listTimeLine.Adapter.ItemsSource = this.ViewModel.TimelineItems;
            (this.listTimeLine.Adapter as TimelineAdapter).NotifyDataSetChanged();
        }
    }
}