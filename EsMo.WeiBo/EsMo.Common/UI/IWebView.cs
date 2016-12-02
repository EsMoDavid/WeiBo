using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Common.UI
{
    public interface IWebView
    {
        void LoadUrl(string url);
        void LoadHtmlString(string html, string schema);
        void EvalJavaScript(string js);
        event EventHandler LoadFinished;
        Uri Uri { get; }
        
    }
}
