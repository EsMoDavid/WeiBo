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

namespace EsMo.Android.WeiBo.Entity
{
    [Register("esmo.android.weibo.entity.TimelineFragment")]
    public class TimelineFragment : BaseFragment<TimelineViewModel>
    {
        public TimelineFragment()
        {
            this.TimelineItems = new ObservableCollection<TimelineItemViewModel>();
        }
        public ObservableCollection<TimelineItemViewModel> TimelineItems
        {
            get;
            private set;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        public override global::Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return base.OnCreateView(inflater, container, savedInstanceState);
        }
        public override void OnViewModelSet()
        {
            ////this.TimelineItems.A
            //fore
            //this.ViewModel.TimelineItems
        }
    }
}