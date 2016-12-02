using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Common
{
    public static class Extension
    {
        public static string StreamToString(this Stream stream, bool dispose = true)
        {
            stream.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(stream);
            string str = sr.ReadToEnd();
            stream.Flush();
            if (dispose)
                stream.Dispose();
            return str;
        }
        public static string AppendRequestString(this string url, string paras)
        {
            return url + (paras == null ? string.Empty : ("?" + paras));
        }
    }
    //public static class UtilExtension
    //{
    //    public static Stream DownloadUrl(this string url)
    //    {
    //        HttpParams p = new HttpParams(url);
    //        p.Method = HttpMethod.Get;
    //        return new DataOperator().Get(p);
    //    }
    //    public static async Task<Stream> DownloadUrlAsync(this string url)
    //    {
    //        return await Task.Run<Stream>(() => DownloadUrl(url));
    //    }
    //}
}
