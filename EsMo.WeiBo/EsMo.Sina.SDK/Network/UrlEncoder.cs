using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Sina.SDK.Network
{
    public class UrlEncoder
    {
        Dictionary<string, string> dic;
        public UrlEncoder()
        {
            this.dic = new Dictionary<string, string>();
        }
        public void Add(string key, string val)
        {
            this.dic.Add(key, val);
            
        }
        public bool ContainKey(string key)
        {
            return this.dic.ContainsKey(key);
        }
        public override string ToString()
        {
            FormUrlEncodedContent t = new FormUrlEncodedContent(dic);
            return (t.ReadAsStringAsync()).Result;
        }
    }
}
