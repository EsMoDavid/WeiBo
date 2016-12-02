using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if __WIN32__
using _SQLitePlatform = SQLite.Net.Platform.Win32.SQLitePlatformWin32;
#elif WINDOWS_PHONE
using _SQLitePlatform = SQLite.Net.Platform.WindowsPhone8.SQLitePlatformWP8;
#elif __WINRT__
using _SQLitePlatform = SQLite.Net.Platform.WinRT.SQLitePlatformWinRT;
#elif __IOS__
using _SQLitePlatform = SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS;
#elif __ANDROID__
using _SQLitePlatform = SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid;
#elif __OSX__
using _SQLitePlatform = SQLite.Net.Platform.OSX.SQLitePlatformOSX;
#elif __GENERIC__
using _SQLitePlatform = SQLite.Net.Platform.Generic.SQLitePlatformGeneric;
#endif

// ReSharper disable once CheckNamespace
namespace EsMo.SQLite
{
    public class SQLitePlatform : _SQLitePlatform
    {
    }
}
