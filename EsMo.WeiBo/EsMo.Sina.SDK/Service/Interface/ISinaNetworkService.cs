using EsMo.Sina.SDK.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Sina.SDK.Service
{
    public interface ISinaNetworkService:IHttpNetworkService,IBaseService
    {
        IHttpParams CreateHttpParams(string url, HttpMethod method, bool auth = true);
          Task<T> InvokeAction<T>(string actionKey, params object[] p);

    }
}
