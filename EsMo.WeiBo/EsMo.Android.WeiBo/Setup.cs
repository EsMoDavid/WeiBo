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
using MvvmCross.Platform;
using System.Reflection;
using MvvmCross.Plugins.Visibility;
using System.Collections;
using MvvmCross.Platform.Droid.Platform;
using EsMo.Android.WeiBo.Entity;
using EsMo.MvvmCross.Android.Support.Converter;
using MvvmCross.Droid.Support.V7.AppCompat;

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
            var mvxFragmentsPresenter = new MvxAppCompatViewPresenter(AndroidViewAssemblies);
            Mvx.RegisterSingleton<IMvxAndroidViewPresenter>(mvxFragmentsPresenter);
            
            mvxFragmentsPresenter.AddPresentationHintHandler<MvxPanelPopToRootPresentationHint>(hint =>
            {
                var activity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
                var fragmentActivity = activity as global::Android.Support.V4.App.FragmentActivity;

                for (int i = 0; i < fragmentActivity.SupportFragmentManager.BackStackEntryCount; i++)
                {
                    fragmentActivity.SupportFragmentManager.PopBackStack();
                }
                return true;
            });
            Mvx.RegisterSingleton<MvxPresentationHint>(() => new MvxPanelPopToRootPresentationHint());
            return mvxFragmentsPresenter;
        }
        protected override IEnumerable<Assembly> ValueConverterAssemblies
        {
            get
            {
                var toReturn = base.ValueConverterAssemblies as IList;
                toReturn.Add(typeof(MvxVisibilityValueConverter).Assembly);
                toReturn.Add(typeof(StreamBitmapConverter).Assembly);
                toReturn.Add(typeof(NullGoneConverter).Assembly);
                return (IEnumerable<Assembly>)toReturn;
            }
        }
        //protected override IDictionary<string, string> ViewNamespaceAbbreviations
        //=> new Dictionary<string, string>
        //{
        //    {
        //        "Mvx", "MvvmCross.Binding.Droid.Views"
        //    }
        //};
        protected override IEnumerable<Assembly> AndroidViewAssemblies
        => new List<Assembly>(base.AndroidViewAssemblies)
        {
            typeof(global::MvvmCross.Binding.Droid.Views.MvxImageView).Assembly,
            //typeof(global::MvvmCross.Binding.Droid.Views.MvxListItemView).Assembly
        };
    }
}