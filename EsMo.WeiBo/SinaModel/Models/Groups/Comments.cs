using EsMo.Sina.Model.Person;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Sina.Model.Groups
{
    [DataContract]
    public class CommentsList
    {
        [DataMember(Name ="comments")]
        public List<Comment> Comments { get; set; }

        [DataMember(Name = "hasvisible")]
        public bool HasVisible { get; set; }

        [DataMember(Name = "previous_cursor")]
        public int PreviousCursor { get; set; }
        [DataMember(Name = "next_cursor")]
        public long NextCursor { get; set; }

        [DataMember(Name = "total_number")]
        public int TotalNumber { get; set; }
    }


    [DataContract]
    public class Comment
    {
        [DataMember(Name = "created_at")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CreatedAt { get; set; }

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
        [DataMember(Name = "user")]
        public UserShow User { get; set; }
        [DataMember(Name = "status")]
        public Status Status { get; set; }

        [DataMember(Name ="reply_comment")]
        public Comment ReplyComment { get; set; }
    }
}
