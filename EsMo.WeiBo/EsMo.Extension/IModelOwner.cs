using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;


namespace EsMo.Core
{
    public interface IModelOwner<T>
    {
        void SetModel(T model);
    }
}