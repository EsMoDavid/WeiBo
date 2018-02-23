using Android.OS;
using Android.Runtime;
using Android.Views;
using CheeseBind;
using EsMo.Sina.SDK.Model;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;

namespace EsMo.Android.WeiBo.Entity
{
    [Register("esmo.android.weibo.entity.TimelineFragment")]
    public class TimelineFragment : BaseFragment<TimelineViewModel>
    {
        [BindView(Resource.Id.listTimeLine)]
        private MvxListView listTimeLine;
        protected override int LayoutID => Resource.Layout.TimelineView;

        public TimelineFragment()
        {
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        protected override void OnInflated(View view)
        {
            Cheeseknife.Bind(this, view);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = base.OnCreateView(inflater, container, savedInstanceState);
            this.listTimeLine.Adapter = new TimelineAdapter(this.Context, (IMvxAndroidBindingContext)this.BindingContext, Resource.Layout.TimelineItem);
            return view;
        }
    }
}