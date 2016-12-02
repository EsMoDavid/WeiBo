using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Sina.SDK.Utils
{
    internal static class FileUtil
    {
        public static async Task<Stream> ReadEmbeddedResourceAsync(string path)
        {
            return await Task.Run<Stream>(() => ReadEmbeddedResource(path));
        }
        public static Stream ReadEmbeddedResource(string path)
        {
            return Assembly.Load(new AssemblyName("EsMo.Sina.SDK")).GetManifestResourceStream(path);
        }
    }
}
