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
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using EsMo.Sina.SDK.Model;
using MvvmCross.Platform.IoC;
using MvvmCross.Droid.Views;
using MvvmCross.Droid.Shared.Presenter;
using MvvmCross.Platform;

namespace EsMo.Android.WeiBo
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
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
        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var mvxFragmentsPresenter = new MvxFragmentsPresenter(AndroidViewAssemblies);
            Mvx.RegisterSingleton<IMvxAndroidViewPresenter>(mvxFragmentsPresenter);
            return mvxFragmentsPresenter;
        }
    }
}