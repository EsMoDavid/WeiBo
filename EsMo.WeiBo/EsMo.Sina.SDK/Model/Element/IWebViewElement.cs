using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Sina.SDK.Model
{
    public interface IWebViewElement
    {
        void LoadHtmlString(string html, string schema);
    }
}
