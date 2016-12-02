using EsMo.Sina.SDK.Model;
using EsMo.Sina.SDK.Service;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Sina.SDK
{
    internal static class ViewModelExtension
    {
        public static IApplicationService GetApplication(this MvxNotifyPropertyChanged that)
        {
            return Mvx.Resolve<IApplicationService>();
        }
    }
}
