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
using MvvmCross.Binding.Droid.Views;
using Android.Util;
using EsMo.Sina.SDK.Model;
using MvvmCross.Binding.Droid.BindingContext;

namespace EsMo.Android.WeiBo.Entity
{
    public class MenuAdapter:MvxAdapter<MenuItemViewModel>
    {
        public MenuAdapter(Context context)
            :base(context)
        {

        }
        public MenuAdapter(Context context, IMvxAndroidBindingContext bindingContext)
            :base(context,bindingContext)
        {
          
        }
        protected override global::Android.Views.View GetBindableView(global::Android.Views.View convertView, object dataContext, ViewGroup parent, int templateId)
        {
            var menuItem = dataContext as MenuItemViewModel;
            if (menuItem.MenuType == MenuType.UserProfile)
            {
                return base.GetBindableView(convertView, dataContext, parent, Resource.Layout.MenuProfile);
            }
            return base.GetBindableView(convertView, dataContext, parent, templateId);
        }
    }
}