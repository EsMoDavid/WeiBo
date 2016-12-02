using EsMo.Sina.SDK.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace EsMo.Sina.SDK
{
    public class Settings : Dictionary<string, Setting>
    {

    }
    public class Setting
    {
        public string Type { get; set; }
        public string Des { get; set; }
        public string Value { get; set; }
        public List<Setting> Extras { get; set; }
    }
    internal static class SettingModel
    {
        const string actionsPath = "EsMo.Sina.SDK.Assets.XML.actions.xml";

        internal const string act_client_id = "client_id";
        internal const string act_app_secret = "app_secret";
        internal const string act_base_url = "base_url";
        internal const string act_access_token = "access_token";
        internal const string act_callback_url = "callback_url";
        internal const string act_usershow = "usershow";
        internal const string act_friendshipGroups = "friendshipGroups";
        internal const string act_statusesFriendsTimeLine = "statusesFriendsTimeLine";
        internal const string act_commentShow = "commentsShow";

        internal static Settings Settings { get; set; }

        internal static Settings Action { get; set; }
        internal static string GetActDescrption(string act)
        {
           return SettingModel.Action[act].Des;
        }
        static SettingModel()
        {
            Stream stream = FileUtil.ReadEmbeddedResource(actionsPath);
            Action = CreateSettings(stream);
        }
        static Settings CreateSettings(Stream stream)
        {
            Settings settings = new Settings();
            var doc = XDocument.Load(stream);
            XElement appSetting = doc.Root;
            foreach (var item in appSetting.Elements("setting"))
            {
                try
                {
                    Setting setting = new Setting();
                    setting.Type = item.Attribute("type").Value;
                    setting.Des = GetElement(item, "des");
                    setting.Value = GetElement(item, "value");
                    if (!settings.ContainsKey(setting.Type))
                        settings.Add(setting.Type, setting);
                    XElement extras = item.Element("extras");
                    if (extras != null)
                    {
                        setting.Extras = new List<Setting>();
                        foreach (var extra in extras.Elements("extra"))
                        {
                            Setting ext = new Setting();
                            ext.Des = GetElement(extra, "des");
                            ext.Value = GetElement(extra, "value");
                            setting.Extras.Add(ext);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
               
            }
            stream.Dispose();
            return settings;
        }
        static string GetElement(XElement item, string prop)
        {
            XElement xElement = item.Element(prop);
            if (xElement != null)
                return xElement.Value;
            return null;
        }
    }
}
