using System;
using System.Configuration;

namespace WebAppStatus.Services
{
    public static class ConfigurationProvider
    {
        public static string GetOwnerName()
        {
            return GetConfigValue("WebHealthPage.Owner", "Your name here");
        }

        public static string GetPageTitle()
        {
            return GetConfigValue("WebHealthPage.PageTItle", "Health Check");
        }

        private static string GetConfigValue(string key, string defaultValue)
        {
            var value = defaultValue;
            try
            {
                var configValue = ConfigurationManager.AppSettings[key];
                if (!string.IsNullOrEmpty(configValue))
                    value = configValue;
            }
            catch (Exception)
            {

                throw;
            }
            return value;
        }

    }
}
