using EsMo.MvvmCross.Support;
using EsMo.Sina.SDK.Storage;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EsMo.Sina.SDK.Model
{
    public class App: MvxApplication
    {
        public const string ClientID = "2362431378";
        public override void Initialize()
        {
            base.Initialize();
            Mvx.ConstructAndRegisterSingleton<IMvxAppStart, AppStart>();
            Mvx.RegisterSingleton<IMvxJsonConverter>(() => new MvxJsonConverter());
        }
        private void Init()
        {
            //this.DataOperator = new DataOperator();
            //this.DownloadCache = new DownloadCache(this.DataOperator);
        }
    }
}