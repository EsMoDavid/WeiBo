using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsMo.Sina.Model.Person;
using EsMo.Sina.SDK.Network;
using System.Net.Http;
using EsMo.Sina.SDK.Model;
using EsMo.Sina.Model.Groups;

namespace EsMo.Sina.SDK.Service
{
    public class AccountService : SinaNetworkService, IAccountService
    {
        const int PageCount = 20;
        public async Task InitialUserShow(Account account)
        {
            account.Show = await this.InvokeAction<UserShow>(SettingModel.act_usershow, account.Token.UID);
        }
        public async Task InitialAccountInfo(Account account)
        {
            GroupListModel groupsModel = await this.InvokeAction<GroupListModel>(SettingModel.act_friendshipGroups, -1, -1);
            account.Groups.AddRange(groupsModel.Groups);
            var statusList = (await this.InvokeAction<StatusList>(SettingModel.act_statusesFriendsTimeLine, -1, -1));
            account.Statuses.AddRange(statusList.Statuses);
        }
        public async Task<List<Status>> GetNextPageTimeline(long firstID, long nextID)
        {
            StatusList statuslist = await this.InvokeAction<StatusList>(SettingModel.act_statusesFriendsTimeLine, -1, nextID);
            return statuslist.Statuses;
        }
        public async Task<List<Comment>> GetComments(Status status)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("id", status.ID.ToString());
            var list= await this.InvokeAction<CommentsList>(SettingModel.act_commentShow, -1, -1, dic);
            return list.Comments;
        }
        public async Task<Account> LoginWithToken(string baseUrl)
        {
            Uri uri = new Uri(baseUrl);
            var names = HttpUtility.ParseQueryString(uri.Query);
            string key = "code";
            bool hasToken = names.ContainsKey(key);

            if (hasToken)
            {
                UrlEncoder urlEncoder = new UrlEncoder();
                string code = "code";
                Setting access_toke = SettingModel.Action[SettingModel.act_access_token];
                string url = access_toke.Extras[0].Value + access_toke.Value;

                var p = CreateHttpParams(url, HttpMethod.Post, false);
                urlEncoder.Add(code, names[key]);
                urlEncoder.Add(SettingModel.act_client_id, App.ClientID);
                urlEncoder.Add("client_secret", SettingModel.Action[SettingModel.act_app_secret].Value);
                urlEncoder.Add("grant_type", "authorization_code");
                urlEncoder.Add("redirect_uri", SettingModel.Action[SettingModel.act_callback_url].Value);
                this.ConfigUrlParams(urlEncoder);

                string str = urlEncoder.ToString();
                p.Content = Encoding.UTF8.GetBytes(str);
                p.ContentType = "application/x-www-form-urlencoded";
                StringContent content = new StringContent(str, Encoding.UTF8, "application/x-www-form-urlencoded");
                p.HttpContent = content;

                Token token = await this.Get<Token>(p);
                Account account = new Account();
                account.Token = token;
                account.TokenCode = code;
                return account;
            }
            return null;
        }
        protected override void OnConfigUrlEncoder(string actionKey, UrlEncoder urlEncoder, params object[] param)
        {
            switch (actionKey)
            {
                case SettingModel.act_usershow:
                    urlEncoder.Add("uid", param[0].ToString());
                    if (param.Length > 1)
                        urlEncoder.Add("screen_name", param.ToString());
                    break;
                case SettingModel.act_statusesFriendsTimeLine:
                case SettingModel.act_commentShow:
                    urlEncoder.Add("count", PageCount.ToString());
                    long prevID = long.Parse(param[0].ToString());
                    long nextID = long.Parse(param[1].ToString());
                    if (nextID != -1)
                        urlEncoder.Add("max_id", nextID.ToString());
                    if (param.Length > 2)
                    {
                        Dictionary<string, string> dic = param[2] as Dictionary<string, string>;
                        foreach (var item in dic)
                        {
                            urlEncoder.Add(item.Key, item.Value);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
