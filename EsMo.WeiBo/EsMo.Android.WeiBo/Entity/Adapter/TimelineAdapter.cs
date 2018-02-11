using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;

namespace EsMo.Android.WeiBo.Entity
{
    public class TimelineAdapter:MvxAdapter
    {
        public TimelineAdapter(Context context) : base(context)
        {
        }

        public TimelineAdapter(Context context, IMvxAndroidBindingContext bindingContext) : base(context, bindingContext)
        {
        }

        protected TimelineAdapter(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
        protected override View GetView(int position, View convertView, ViewGroup parent, int templateId)
        {
            var view = base.GetView(position, convertView, parent, templateId);
            return view;
        }
    }
}