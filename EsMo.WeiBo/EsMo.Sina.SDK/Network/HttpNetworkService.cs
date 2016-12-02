using EsMo.Common.Json;
using EsMo.Sina.SDK.Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EsMo.Common;
namespace EsMo.Sina.SDK.Service
{
    public class HttpNetworkService:IHttpNetworkService
    {
        public async Task<T> Get<T>(IHttpParams p)
        {
            var stream = await this.Get(p);
            T obj = stream.ToJsonModel<T>();
            return obj;
        }
        public async Task<Stream> Get(IHttpParams p)
        {
#if false
            try
            {
                HttpWebRequest request2 = HttpWebRequest.Create(p.Url) as HttpWebRequest;
                request2.Method = p.Method.ToString();

                if (p.HttpContent != null)
                {
                    request2.ContentType = p.ContentType;
                    var reqStream = request2.GetRequestStreamAsync().Result;
                    reqStream.Write(p.Content, 0, p.Content.Length);
                    reqStream.Flush();
                }

                WebResponse response2 = request2.GetResponseAsync().GetAwaiter().GetResult() ;
                Stream stream = response2.GetResponseStream();
                System.Diagnostics.Debug.WriteLine("Download finished");
                return stream;
            }
            catch (Exception)
            {
                return null;
            }
#else
            //NativeMessageHandler handler = new NativeMessageHandler();
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            HttpRequestMessage request = new HttpRequestMessage(p.Method, p.Url);
            if (p.HttpContent != null)
                request.Content = p.HttpContent;
            if (p.Headers != null)
            {
                foreach (var item in p.Headers)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }
            try
            {
                HttpResponseMessage response = null;
                response = client.SendAsync(request).Result;
                if (response.IsSuccessStatusCode)
                {
                    Stream stream =await response.Content.ReadAsStreamAsync();
                    //Debug.WriteLine(stream.StreamToString(false));
                    return stream;
                }
            }

            catch (Exception e)
            {
                if (e.InnerException is TaskCanceledException)
                {

                }
                else
                {

                }
            }
            finally
            {
                client.Dispose();
            }
            return null;
#endif
        }
    }
}
