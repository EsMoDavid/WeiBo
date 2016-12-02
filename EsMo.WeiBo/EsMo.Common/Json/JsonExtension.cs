using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Common.Json
{
    public static class JsonExtension
    {
        public static string ToJson(this object o)
        {
            return JsonConvert.SerializeObject(o);
        }
        public static T ToJsonModel<T>(this string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
        public static T ToJsonModel<T>(this Stream stream)
        {
            //var serializer = new DataContractJsonSerializer(typeof(T));
            T t = ToJsonModel<T>(stream.StreamToString());
            stream.Flush();
            stream.Dispose();
            return t;
        }
        public static T ToJsonModel<T>(this byte[] bytes)
        {
            MemoryStream ms = new MemoryStream(bytes);
            return ms.ToJsonModel<T>();
        }
        public static Stream ToJsonStream(this object obj)
        {
            var serializer = new DataContractJsonSerializer(obj.GetType());
            Stream stream = new MemoryStream();
            serializer.WriteObject(stream, obj);
            if (stream.CanSeek)
                stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }
        public static byte[] ToJsonArray(this object obj)
        {
            Stream stream = ToJsonStream(obj);
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Dispose();
            return bytes;
        }
        public static object ToJsonModel(this byte[] data, Type type)
        {
            MemoryStream ms = new MemoryStream(data);
            return JsonConvert.DeserializeObject(ms.StreamToString(), type);
        }
    }
    public static class StreamExtension
    {
        public async static Task<MemoryStream> ToMemoryStream(this Stream stream)
        {
            MemoryStream ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            ms.Position = 0;
            return ms;
        }       
    }
}
