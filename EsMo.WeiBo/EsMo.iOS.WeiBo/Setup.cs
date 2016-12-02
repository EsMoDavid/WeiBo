using MvvmCross.iOS.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmCross.Core.ViewModels;
using UIKit;
using EsMo.Sina.SDK.Model;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform;
using EsMo.iOS.WeiBo.Entity;
using MvvmCross.iOS.Support.XamarinSidebar;

namespace EsMo.iOS.WeiBo
{
    public class Setup : MvxIosSetup
    {
        IMvxApplicationDelegate applicationDelegate;
        UIWindow window;
        public Setup(IMvxApplicationDelegate applicationDelegate, UIWindow window)
            :base(applicationDelegate,window)
        {
            this.applicationDelegate = applicationDelegate;
            this.window = window;
        }
        protected override IMvxApplication CreateApp()
        {
            this.CreatableTypes(typeof(App).Assembly)
              .EndingWith("Service")
              .AsInterfaces()
              .RegisterAsLazySingleton();
            this.CreatableTypes(typeof(Setup).Assembly)
             .EndingWith("Element")
             .AsInterfaces()
             .RegisterAsLazySingleton();
            return new App();
        }
        protected override IMvxIosViewPresenter CreatePresenter()
        {
            return new MvxSidebarPresenter((MvxApplicationDelegate)ApplicationDelegate, Window);
        }
    }
}