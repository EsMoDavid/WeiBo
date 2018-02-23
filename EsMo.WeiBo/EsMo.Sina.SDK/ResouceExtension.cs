using EsMo.Sina.SDK.Resource;
using EsMo.Sina.SDK.Service;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Sina.SDK
{
    public static class ResourceExtension
    {

        public static string GetResourceString(this string key)
        {
            return AppResources.ResourceManager.GetString(key);
        }
        public static string GetResourceString(this Enum enumValue)
        {
            return GetResourceString(enumValue.ToString());
        }

        static Stream imageLoading;
        public static Stream ImageLoading
        {
            get
            {
                if (imageLoading == null)
                {
                    imageLoading = AssetsHelper.timeline_loading.ToAssetsImage().ToStream();
                }
                return imageLoading;
            }
        }
        static Stream ToStream(this string localPath)
        {
            return Mvx.Resolve<IApplicationService>().ResourceCache.Get(localPath);
        }
    }
}
