using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace EsMo.Sina.Model
{
    public class DateTimeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            //JObject jobject = JObject.Load(reader);
            JValue val = JValue.Load(reader) as JValue;
            if (val.Value!=null)
            {
                string format = "ddd MMM d HH:mm:ss  zzz yyyy";
                DateTime result;
                if (DateTime.TryParseExact(val.Value.ToString(), format, CultureInfo.InvariantCulture
                    , DateTimeStyles.AllowWhiteSpaces, out result))
                    return result;
            }
            return null;

        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
