using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using ConfigurationFileTransformationExample.Extensions;
using ConfigurationFileTransformationExample.Model;
using Microsoft.SharePoint.Utilities;

namespace ConfigurationFileTransformationExample.Services
{
    class MappedFolderSettingService : ISettingService
    {
        Dictionary<string, Setting> settings;

        public MappedFolderSettingService()
        {
            InitSettings();
        }

        private void InitSettings()
        {
            FileInfo file = new FileInfo(Path.Combine(SPUtility.GetGenericSetupPath(@"CONFIG\MyExample"), "app1.config"));

            if (file.Exists == false)
            {
                throw new FileNotFoundException("No config file", "app1.config");
            }

            settings = (from KeyValueConfigurationElement appSetting in file.AppSettings()
                        select appSetting)
                        .ToDictionary(kvce => kvce.Key, kvce => new Setting { Key = kvce.Key, Value = kvce.Value });
        }

        public bool TryLocateByKey(string key, out Model.Setting value)
        {
            return settings.TryGetValue(key, out value);
        }

        public IEnumerable<Model.Setting> FindAll()
        {
            return settings.Values;
        }
    }
}
