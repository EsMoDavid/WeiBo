using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EsMo.Android.Support.Views;
using EsMo.Sina.SDK.Model;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;
using System;
using UniversalImageLoader.Core;

namespace EsMo.Android.WeiBo.Entity
{
    public class TimelineAdapter : MvxAdapter
    {
        public TimelineAdapter(Context context) : base(context)
        {
        }

        public TimelineAdapter(Context context, IMvxAndroidBindingContext bindingContext) : base(context, bindingContext)
        {
        }
        public TimelineAdapter(Context context, IMvxAndroidBindingContext bindingContext, int templateID) : base(context, bindingContext)
        {
            this.ItemTemplateId = templateID;
        }
        protected TimelineAdapter(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
        protected override IMvxListItemView CreateBindableView(object dataContext, ViewGroup parent, int templateId)
        {
            return new TimelineListItemView(this.Context, this.BindingContext.LayoutInflaterHolder, dataContext, parent, templateId);
        }
        protected override View GetBindableView(View convertView, object dataContext, ViewGroup parent, int templateId)
        {
            var view = base.GetBindableView(convertView, dataContext, parent, templateId);
            (view.Tag as TimelineListItemView).UpdateView(dataContext);
            return view;
        }
    }
    public class TimelineListItemView : MvxListItemView
    {
        WrappedLayout wrappedLayout;
        public TimelineListItemView(Context context, IMvxLayoutInflaterHolder layoutInflaterHolder, object dataContext, ViewGroup parent, int templateId) : base(context, layoutInflaterHolder, dataContext, parent, templateId)
        {
            View content = this.Content;
            this.wrappedLayout = content.FindViewById<WrappedLayout>(Resource.Id.wrapPics);
        }
        public void UpdateView(object dataContext)
        {           
            var model = dataContext as TimelineItemViewModel;
            for (int i = 0; i < model.ImageModels.Count; i++)
            {
                var imgModel = model.ImageModels[i];
                ImageLoader.Instance.DisplayImage(imgModel.ThumbnailPic, this.wrappedLayout.GetChildAt(i) as ImageView);
            }
        }
    }
}