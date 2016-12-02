using EsMo.Sina.SDK;
using System.Globalization;
using System.Threading;
using UIKit;

namespace EsMo.iOS.WeiBo
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            
            CultureInfo culture = CultureInfo.CreateSpecificCulture("zh-Hans");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}