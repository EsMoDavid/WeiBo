using EsMo.Sina.Model.Person;
using EsMo.Sina.SDK.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Sina.SDK.Service
{
    public interface IApplicationService:IBaseService
    {
        Account Account { get; set; }
        ResourceCache ResourceCache { get; }
    }
}
