using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using EsMo.Sina.Model.Groups;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using EsMo.Common.Json;
using System.IO;

namespace EsMo.Sina.SDK.Model
{
    public class ImageBrowserViewModel:BaseViewModel
    {
        public int CurrentIndex { get; private set; }
        public string[] ImageUrls { get; private set; }
       
        protected override void InitFromBundle(IMvxBundle parameters)
        {
            base.InitFromBundle(parameters);
           var urls= parameters.Data[TimelineItemViewModel.ImageArray].ToJsonModel<string[]>();
            ImageUrls = (from url in urls select url.Replace("thumbnail", "bmiddle")).ToArray();    
            CurrentIndex = int.Parse(parameters.Data[TimelineItemViewModel.SelectedIndex]);
        }

    }
}
