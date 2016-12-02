using EsMo.Sina.SDK.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EsMo.Sina.SDK.Storage
{
    public class Cache
    {
        object locker = new object();
        Dictionary<string, Stream> dicCache;
        public Cache()
        {
            this.dicCache = new Dictionary<string, Stream>();
        }
        public void Clear()
        {
            this.dicCache.Clear();
        }
        public virtual Stream Get(string key, bool isCache = true,CancellationToken? token=null)
        {
            Stream stream = null;
            this.dicCache.TryGetValue(key, out stream);
            return stream;
        }
        public void Put(string key, Stream stream)
        {
            lock (locker)
            {
                if (stream != null)
                {
                    if (this.dicCache.ContainsKey(key))
                        this.dicCache[key] = stream;
                    else
                        this.dicCache.Add(key, stream);
                }
            }
        }
        public bool IsExist(string key)
        {
            return this.dicCache.ContainsKey(key);
        }
        public virtual async Task<Stream> GetAsync(string key, CancellationToken? token = null)
        {
          return  await Task<Stream>.Run(() => this.Get(key,true, token));   
        }
    }

    //public class DownloadCache : Cache
    //{
    //    DataOperator DataOperator;
    //    public DownloadCache(DataOperator dataOperator)
    //    {
    //        this.DataOperator = dataOperator;
    //    }
    //    public override Stream Get(string url, bool isCache = true, CancellationToken? token = null)
    //    {
    //        Stream stream = base.Get(url);
    //        if (stream == null)
    //        {
    //            HttpParams p = new HttpParams(url);
    //            p.Method = HttpMethod.Get;
    //            //stream =new DataOperator().Get(p, token);
    //            stream = this.DataOperator.Get(p, token);
    //            if (isCache)
    //                this.Put(url, stream);
    //        }
    //        else
    //        {
    //            stream.Seek(0, SeekOrigin.Begin);
    //        }
    //        return stream;
    //    }

    //}
    public class ResourceCache : Cache
    {
        public override Stream Get(string key, bool isCache = true,CancellationToken? token=null)
        {
            Stream stream = base.Get(key);
            if (stream == null)
            {
                stream = FileUtil.ReadEmbeddedResource(key);
                if (isCache)
                    this.Put(key, stream);
            }
            else
            {
                stream.Seek(0, SeekOrigin.Begin);
            }
            return stream;
        }
    }
    //public static class CacheExtension
    //{
    //    public static Task<Stream> DownloadToCache(this string url, CancellationToken? token = null)
    //    {
    //        return AppContext.Current.DownloadCache.GetAsync(url, token);
    //    }
    //}
}
