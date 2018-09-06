using System;
using System.IO;
using System.Reflection;

namespace WebAppStatus.Services
{
    public static class EmbeddedResourceProvider
    {
        public static string Read(string resourceName)
        {
            string result = null;
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream != null)
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch
            {
                //throw;
            }
            return result;
        }
    }
}
