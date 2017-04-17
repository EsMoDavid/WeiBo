using EsMo.Common;
using EsMo.Sina.SDK.Utils;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Sina.SDK.Service
{
    public class LoginService :SinaNetworkService,  ILoginService
    {
        const string oauthPath = "EsMo.Sina.SDK.Assets.JS.oauth.js";
        public LoginService()
        {
        }

        string oAuthJS;
        string OAuthJS
        {
            get
            {
                if (oAuthJS == null)
                    oAuthJS = FileUtil.ReadEmbeddedResource(oauthPath).StreamToString();
                return oAuthJS;
            }
        }
        public async Task<string> GetAuthPage(string accountName, string pwd)
        {
            string html = await this.GetAuthPage();
            if (!string.IsNullOrEmpty(accountName) && !(string.IsNullOrEmpty(pwd)))
            {
                string oauthJS = OAuthJS.Replace("%username%", accountName).Replace("%password%", pwd);
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                HtmlNode header = doc.DocumentNode.Descendants("header").FirstOrDefault();
                if (header != null)
                {
                    var node = HtmlNode.CreateNode(oauthJS);
                    header.ChildNodes.Add(node);
                    System.Diagnostics.Debug.WriteLine(header.InnerHtml);
                }
                return doc.DocumentNode.OuterHtml;
            }
            return html;
        }
        internal async Task<string> GetAuthPage()
        {
            return (await this.Get(this.CreateHttpParams(GlobalURI.Auth.ToSchemaHttps(), HttpMethod.Get, false))).StreamToString();
        }
    }
}
