using EsMo.Sina.SDK.Resource;
using System;
using System.Collections.Generic;
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
    }
}
