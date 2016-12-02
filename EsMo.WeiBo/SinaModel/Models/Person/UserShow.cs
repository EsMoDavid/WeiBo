using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SQLite.Net.Attributes;

namespace EsMo.Sina.Model.Person
{
    [DataContract]
    public class UserShow
    {
        [DataMember(Name = "id"), PrimaryKey, NotNull]
        public long ID { get; set; }
        [DataMember(Name="class")]
        public int Class { get; set; }
        [DataMember(Name="screen_name")]
        public string ScreenName { get; set; }

        [DataMember(Name = "name")]
        public string Name { get ; set; }

        [DataMember(Name = "province")]
        public int Province { get; set; }

        [DataMember(Name = "city")]
        public int City { get; set; }

        [DataMember(Name = "location")]
        public string Location { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "profile_image_url")]
        public string ProfileImageUrl { get; set; }
        [DataMember(Name = "profile_url")]
        public string ProfileUrl { get; set; }
        [DataMember(Name = "Domain")]
        public string Domain { get; set; }
        [DataMember(Name = "weihao")]
        public string WeiHao { get; set; }
        [DataMember(Name = "gender")]
        public string Gender { get; set; }

        [DataMember(Name = "followers_count")]
        public int FollowersCount { get; set; }

        [DataMember(Name = "friends_count")]
        public int FriendsCount { get; set; }

        [DataMember(Name = "statuses_count")]
        public int StatusesCount { get; set; }

        [DataMember(Name = "favourites_count")]
        public int FavouritesCount { get; set; }

        [DataMember(Name = "created_at")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CreatedAt { get; set; }

        [DataMember(Name = "following")]
        public bool Following { get; set; }
        [DataMember(Name = "allow_all_act_msg")]
        public bool AllowAllActMSG { get; set; }

        [DataMember(Name = "geo_enabled")]
        public bool GeoEnabled { get; set; }

        [DataMember(Name = "verified")]
        public bool Verified { get; set; }
        [DataMember(Name = "verified_type")]
        public int VerifiedType { get; set; }
        [DataMember(Name = "remark")]
        public string Remark { get; set; }

        [DataMember(Name = "ptype")]
        public int PType { get; set; }
        [DataMember(Name = "allow_all_comment")]
        public bool AllowAllComment { get; set; }
        [DataMember(Name = "avatar_large")]
        public string AvatarLarge { get; set; }

        [DataMember(Name = "avatar_hd")]
        public string AvatarHd { get; set; }
        [DataMember(Name = "verified_reason")]
        public string VerifiedReason { get; set; }
        [DataMember(Name = "verified_trade")]
        public string VerifiedTrade { get; set; }
        [DataMember(Name = "verified_reason_url")]
        public string VerifiedReasonUrl { get; set; }
        [DataMember(Name = "verified_source")]
        public string VerifiedSource { get; set; }
        [DataMember(Name = "verified_source_url")]
        public string VerifiedSourceUrl { get; set; }

        [DataMember(Name = "follow_me")]
        public bool FollowMe { get; set; }
        [DataMember(Name = "online_status")]
        public int  OnlineStatus { get; set; }
        [DataMember(Name = "bi_followers_count")]
        public int BIFollowersCount { get; set; }

        [DataMember(Name = "lang")]
        public string Lang { get; set; }

        [DataMember(Name="star")]
        public int Star { get; set; }
        [DataMember(Name = "mbtype")]
        public int MbType { get; set; }
        [DataMember(Name = "mbbrank")]
        public int MbBrank { get; set; }
        [DataMember(Name = "block_word")]
        public int BlockWord { get; set; }
        [DataMember(Name = "block_app")]
        public int BlockApp { get; set; }

        [DataMember(Name = "credit_score")]
        public int CreditScore { get; set; }

        [DataMember(Name = "user_ability")]
        public int UserAbility { get; set; }
        [DataMember(Name = "urank")]
        public int URank { get; set; }

        internal string ActualGeneralName
        {
            get
            {
                return string.IsNullOrEmpty(this.Remark) ? this.ScreenName : this.Remark;
            }
        }
        internal string ActualProfileUrl
        {
            get
            {
                return string.IsNullOrEmpty(this.AvatarLarge) ? this.ProfileImageUrl : this.AvatarLarge;
            }
        }
    }
}
