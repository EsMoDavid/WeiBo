using EsMo.iOS.WeiBo.Entity;
using EsMo.Sina.SDK.Model;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace EsMo.iOS.WeiBo.Entity
{
    public class BaseView<T> : MvxViewController<T> where T:BaseViewModel
    {
        public BaseView()
        {

        }
        public BaseView(string nibName, NSBundle bundle):base(nibName,bundle)
        {

        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.CreateBinding<MvxViewController>(this).For(x=>x.Title).To<BaseViewModel>(x => x.Title).Apply();
        }
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            this.ViewModel.Appearing();
        }
    }
}