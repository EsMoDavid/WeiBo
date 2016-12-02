using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Sina.Model.Groups
{
    [DataContract]
    public class GroupListModel
    {
        [DataMember(Name = "lists")]
        public List<Group> Groups { get; set; }
    }
    [DataContract]
    public class Group
    {
        [DataMember(Name = "id")]
        [PrimaryKey, NotNull]
        public long ID { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "mode")]
        public string Mode { get; set; }

        [DataMember(Name = "visible")]
        public int Visible { get; set; }

        [DataMember(Name = "like_count")]
        public int LikeCount { get; set; }
        [DataMember(Name = "member_count")]
        public int MemberCount { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "profile_image_url")]
        public string ProfileImageUrl { get; set; }

        [DataMember(Name = "created_at")]
        public string CreatedAt { get; set; }
    }
}
