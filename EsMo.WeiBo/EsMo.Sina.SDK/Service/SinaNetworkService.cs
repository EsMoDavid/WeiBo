using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsMo.Sina.SDK.Network;
using EsMo.Sina.SDK.Model;
using System.Net.Http;
using EsMo.Sina.Model.Person;
using EsMo.Common;
namespace EsMo.Sina.SDK.Service
{
    public class SinaNetworkService : HttpNetworkService, ISinaNetworkService
    {
        protected UrlEncoder ConfigUrlParams(UrlEncoder encoder = null)
        {
            if (encoder == null)
                encoder = new UrlEncoder();
            string source = "source";
            if (!encoder.ContainKey(source))
            {
                encoder.Add(source, App.ClientID);
            }
            Account account = this.GetApplication().Account;
            if (account != null && account.Token != null)
            {
                encoder.Add(SettingModel.act_access_token, account.Token.AccessToken);
            }
            return encoder;
        }
      

        public IHttpParams CreateHttpParams(string url, HttpMethod method, bool auth = true)
        {
            HttpParams p = new HttpParams(url);
            p.Method = method;
            if (auth)
            {
                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("Authorization", "OAuth2 " + this.GetApplication().Account.Token.AccessToken);
                p.Headers = header;
            }
            return p;
        }
        public async Task<T> InvokeAction<T>(string actionKey, params object[] p)
        {
            Setting actionModel = SettingModel.Action[actionKey];
            UrlEncoder urlEncoder = new UrlEncoder();
            this.OnConfigUrlEncoder(actionKey, urlEncoder, p);
            this.ConfigUrlParams(urlEncoder);
            string url = this.GetActionUrl(actionKey);
            url = url.AppendRequestString(urlEncoder.ToString());
            IHttpParams httpParams = CreateHttpParams(url, HttpMethod.Get);
            T o =await this.Get<T>(httpParams);
            return o;
        }
        protected virtual void OnConfigUrlEncoder(string actionKey, UrlEncoder urlEncoder, params object[] param)
        {

        }
        protected string GetActionUrl(string actionKey, string baseUrl = null)
        {
            string baseURL = SettingModel.Action[SettingModel.act_base_url].Value;
            if (baseUrl != null)
                baseURL = baseUrl;
            return baseURL + SettingModel.Action[actionKey].Value;
        }
    }
}
