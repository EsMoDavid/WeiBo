using MvvmCross.Platform.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EsMo.Common.Json;
using Newtonsoft.Json;

namespace EsMo.MvvmCross.Support
{
    public class MvxJsonConverter : IMvxJsonConverter
    {
        public object DeserializeObject(Type type, string inputText)
        {
            return JsonConvert.DeserializeObject(inputText, type);
        }

        public T DeserializeObject<T>(string inputText)
        {
            return inputText.ToJsonModel<T>();
        }

        public T DeserializeObject<T>(Stream stream)
        {
            return stream.ToJsonModel<T>();
        }

        public string SerializeObject(object toSerialise)
        {
            return JsonConvert.SerializeObject(toSerialise);
        }
    }
}
