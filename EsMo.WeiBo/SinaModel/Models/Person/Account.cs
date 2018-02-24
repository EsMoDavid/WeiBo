using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using SQLiteNetExtensions.Attributes;
using EsMo.Sina.Model.Groups;
using System.Collections.ObjectModel;

namespace EsMo.Sina.Model.Person
{
    public class Account
    {
        public Account()
        {
            this.Statuses = new List<Status>();
            this.Groups = new List<Group>();
        }
        public string TokenCode { get; internal set; }
        public Token Token { get; internal set; }

        UserShow show;
        [OneToOne("AccountID", CascadeOperations = CascadeOperation.All)]
        public UserShow Show
        {
            get
            {
                return show;
            }
            set
            {
                this.show = value;
                if (this.show != null)
                    this.AccountID = this.show.ID;
            }
        }
        [PrimaryKey, NotNull]
        public long AccountID
        {
            get; set;
        }
        [ManyToMany(typeof(AccountToGroup),CascadeOperations =CascadeOperation.All)]
        public List<Group> Groups { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Status> Statuses { get; set; }
        public Status GetStatus(long id)
        {
            if (this.Statuses != null)
                return this.Statuses.FirstOrDefault((x) => x.ID == id);
            return null;
        }
        //public StatusList StatusList { get; internal set; }
    }
    [DataContract]
    public class Token
    {
        [DataMember(Name="remind_in")]
        public long RemindIn { get; internal set; }
        [DataMember(Name="expires_in")]
        public long ExpiresIn { get; internal set; }

        [DataMember(Name="access_token")]
        public string AccessToken { get; internal set; }
        [Ignore]
        public bool IsExpired
        {
            get
            {
                int days = TimeSpan.FromSeconds(this.ExpiresIn).Days;
                return false;
            }
        }
        [DataMember(Name="uid")]
        public string UID { get; internal set; }
    }
}
