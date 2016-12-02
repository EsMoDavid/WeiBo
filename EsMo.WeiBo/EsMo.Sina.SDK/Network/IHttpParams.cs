using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;

namespace EsMo.Sina.SDK.Network
{

    public interface IHttpParams
    {
        HttpMethod Method { get; set; }
        HttpContent HttpContent { get; set; }
        IDictionary<string, string> Headers { get; set; }
        string Url { get; set; }
        byte[] Content { get; set; }
        string ContentType { get; set; }
    }
}
