using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;
using EsMo.Common.Json;
namespace EsMo.Sina.SDK.Network.Operators
{
    public class DataOperator : INotifyPropertyChanged
    {
        //internal SQLiteConnection Conn { get; set; }
        public DataOperator()
        {
           
        }

        public T Get<T>(IHttpParams p, CancellationToken? token = null)
        {
            var stream = this.Get(p, token);
            T obj = stream.ToJsonModel<T>();
            return obj;
        }
        public Stream Get(IHttpParams p,CancellationToken? token=null)
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
                    Stream stream = response.Content.ReadAsStreamAsync().Result;
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

        //internal void AttachSqlite(SQLiteConnection connection)
        //{
        //    this.Conn = connection;
        //}

        Stream Post(string url, HttpContent content)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            HttpClientHandler handler = new HttpClientHandler();
            
            HttpClient client = new HttpClient(handler);
        
            if (content != null)
            {
                request.Content = content;
            }
            
            HttpResponseMessage response = client.SendAsync(request).Result;
            Stream stream = response.Content.ReadAsStreamAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                client.Dispose();
                return stream;
            }
            return null;
        }
       

        bool isDownloading;
        internal bool IsDownloading
        {
            get { return isDownloading; }
            set
            {
                if (isDownloading != value)
                {
                    isDownloading = value;
                    this.InvokePropertyChanged("IsDownloading");
                }
            }
        }
        void InvokePropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        
    }
}
