using EsMo.Sina.SDK.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Sina.SDK.Service
{
    public interface IHttpNetworkService
    {
        Task<T> Get<T>(IHttpParams p);
        Task<Stream> Get(IHttpParams p);
    }
}
