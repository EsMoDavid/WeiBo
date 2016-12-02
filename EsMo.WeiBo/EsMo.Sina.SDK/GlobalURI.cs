using EsMo.Sina.SDK.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Sina.SDK
{
    internal static class GlobalURI
    {
        const string SchemaHttps = "https://";
        public const string SinaApi = "api.weibo.com";
        public static string XCallback = "http://boyqiang520.s8.csome.cn/oauth2/";

        public static string Auth = SinaApi + "/" + string.Format("oauth2/authorize?client_id={0}&scope=friendships_groups_read,friendships_groups_write,statuses_to_me_read,follow_app_official_microblog&redirect_uri={1}&display=mobile&forcelogin=true"
            , App.ClientID, XCallback);
        public static string ToSchemaHttps(this string url)
        {
            return SchemaHttps + url;
        }
    }
    internal static class AssetsHelper
    {
        const string SinaSDK = "EsMo.Sina.SDK";
        static string Assets = SinaSDK + "." + "Assets";
        static string Img = Assets + "." + "Img";

        internal const string avatar_enterprise_vip = "avatar_enterprise_vip.png";
        internal const string avatar_grassroot = "avatar_grassroot.png";
        internal const string avatar_vip = "avatar_vip.png";
        internal const string timeline_icon_comment = "timeline_icon_comment.png";
        internal const string timeline_icon_like = "timeline_icon_like.png";
        internal const string timeline_icon_redirect = "timeline_icon_redirect.png";
        internal const string timeline_icon_unlike = "timeline_icon_unlike.png";
        internal const string timeline_loading = "timeline_loading.png";
        internal const string bg_banner_dialog = "bg_banner_dialog.jpg";
        internal const string ic_drawer_at = "ic_drawer_at.png";
        internal const string ic_question_answer_grey600_24dp = "ic_question_answer_grey600_24dp.png";
        internal const string ic_view_day_grey600_24dp = "ic_view_day_grey600_24dp.png";
        internal const string login_user_unknown = "login_user_unknown.png";
        internal static string ToAssetsImage(this string fileName)
        {
            return string.Format("{0}.{1}", Img, fileName);
        }
    }
}
