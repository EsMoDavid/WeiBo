using EsMo.Sina.Model.Groups;
using EsMo.Sina.Model.Person;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Sina.Model
{
    public class AccountToGroup
    {
        [ForeignKey(typeof(Account))]
        public long AccountID { get; set; }
        [ForeignKey(typeof(Group))]
        public long GroupID { get; set; }
    }
}
