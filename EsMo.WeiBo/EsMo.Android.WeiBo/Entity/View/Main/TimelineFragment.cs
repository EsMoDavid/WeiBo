using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Shared.Attributes;
using EsMo.Sina.SDK.Model;
using System.Collections.ObjectModel;
using Android.Support.V4.App;
using MvvmCross.Binding.Droid.Views;
using CheeseBind;

namespace EsMo.Android.WeiBo.Entity
{
    [Register("esmo.android.weibo.entity.TimelineFragment")]
    public class TimelineFragment : BaseFragment<TimelineViewModel>
    {
        [BindView(Resource.Id.listTimeLine)]
        MvxListView lisTimeLine;
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
    }
}