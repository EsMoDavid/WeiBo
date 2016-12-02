using EsMo.Sina.SDK.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Sina.SDK
{
    public class HttpParams : IHttpParams
    {
        public HttpParams(string url)
        {
            this.Url = url;
        }
        public HttpMethod Method
        {
            get; set;
        }

        public HttpContent HttpContent
        {
            get; set;
        }

        public IDictionary<string, string> Headers
        {
            get; set;
        }

        public string Url
        {
            get;
            set;
        }

        public byte[] Content
        {
            get;
            set;
        }

        public string ContentType
        {
            get;set;
        }
    }
}
