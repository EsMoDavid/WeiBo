using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace EsMo.Extension.EnumReflection
{
    public class EnumDicionary:Dictionary<Enum,string>
    {
        public EnumDicionary()
        {
           
        }
        public static void Init()
        {

        }
    }
    [AttributeUsage(AttributeTargets.Enum)]
    public class EnumTextAttribute : Attribute
    {
        Dictionary<string, string> dic;
        public EnumTextAttribute(Type enumType)
        {
            string[] str=Enum.GetNames(enumType);
            dic = new Dictionary<string, string>();
         
            
        }    
    }
}
