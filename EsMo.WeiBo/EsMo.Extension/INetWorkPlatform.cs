using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Core
{
    public interface INetWorkPlatform
    {
        NetworkType NetworkType { get; }
    }
    public enum NetworkType
    {
        None,
        Mobile,
        Wifi,
    }
}
