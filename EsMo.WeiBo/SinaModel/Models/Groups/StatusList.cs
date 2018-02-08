using EsMo.Sina.Model.Person;
using MvvmCross.Platform.Platform;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EsMo.Common.Json;
using Newtonsoft.Json;

namespace EsMo.Sina.Model.Groups
{
    [DataContract]
    public class StatusList
    {
        [DataMember(Name = "statuses")]
        public List<Status> Statuses { get; set; }

        [DataMember(Name = "total_number")]
        public string TotalNumber { get; set; }
        [DataMember(Name = "since_id")]
        public long SinceID { get; set; }

        [DataMember(Name = "max_id")]
        public long MaxID { get; set; }

        [DataMember(Name = "has_unread")]
        public int HasUnread { get; set; }     
    }
    [DataContract]
    public class Status:IMvxJsonConverter
    {
        [ForeignKey(typeof(Account))]
        public long UserID { get; set; }
        [DataMember(Name = "created_at")]
        public string CreatedAt { get; set; }


        [PrimaryKey,NotNull]
        [DataMember(Name = "id")]
        public long ID { get; set; }

        [DataMember(Name = "mid")]
        public string MID { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "source_allowclick")]
        public int SourceAllowClick { get; set; }

        [DataMember(Name = "source_type")]
        public int SourceType { get; set; }

        [DataMember(Name = "source")]
        public string Source { get; set; }

        [DataMember(Name = "favorited")]
        public bool Favorited { get; set; }

        [DataMember(Name = "truncated")]
        public bool Truncated { get; set; }
        [DataMember(Name = "in_reply_to_status_id")]
        public string InReplyToStatusID { get; set; }
        [DataMember(Name = "in_reply_to_user_id")]
        public string InReplyToUserID { get; set; }

        [DataMember(Name = "in_reply_to_screen_name")]
        public string InReplyToScreenName { get; set; }

        [DataMember(Name = "pic_urls")]
        public ImageModel[] PicURLs { get; set; }

        [DataMember(Name = "thumbnail_pic")]
        public string ThumbnailPic { get; set; }

        [DataMember(Name = "bmiddle_pic")]
        public string BMiddlePic { get; set; }

        [DataMember(Name = "original_pic")]
        public string OriginalPic { get; set; }

        [DataMember(Name = "annotations")]
        public Annotation[] Annotations { get; set; }

        [DataMember(Name = "picStatus")]
        public string PicStatus { get; set; }

        [DataMember(Name = "reposts_count")]
        public int RepostsCount { get; set; }

        [DataMember(Name = "comments_count")]
        public int CommentsCount { get; set; }

        [DataMember(Name = "isLongText")]
        public bool IsLongText { get; set; }
        [DataMember(Name = "mlevel")]
        public int MLevel { get; set; }
        [DataMember(Name = "biz_feature")]
        public long BizFeature { get; set; }

        [DataMember(Name = "rid")]
        public string RID { get; set; }

        [DataMember(Name = "userType")]
        public int UserType { get; set; }
        [DataMember(Name = "cardid")]
        public string CardID { get; set; }
        [DataMember(Name = "user")]
        [OneToOne("UserID",CascadeOperations =CascadeOperation.All)]
        public UserShow User { get; set; }

        [DataMember(Name = "retweeted_status")]
        public Status RetweetedStatus { get; set; }

        public object DeserializeObject(Type type, string inputText)
        {
            return JsonConvert.DeserializeObject(inputText, type);
        }

        public T DeserializeObject<T>(string inputText)
        {
            return inputText.ToJsonModel<T>();
        }

        public T DeserializeObject<T>(Stream stream)
        {
            return stream.ToJsonModel<T>();
        }

        public string SerializeObject(object toSerialise)
        {
            return JsonConvert.SerializeObject(toSerialise);
        }
    }
    [DataContract]
    public class Annotation
    {
        [DataMember(Name = "client_mblogid")]
        public string ClientMBlogID { get; set; }
    }
    [DataContract]
    public class ImageModel
    {
        [DataMember(Name = "thumbnail_pic")]
        public string ThumbnailPic { get; set; }     
    }
}
