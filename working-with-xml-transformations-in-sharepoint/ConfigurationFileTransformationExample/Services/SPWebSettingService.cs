using System.Collections.Generic;
using ConfigurationFileTransformationExample.Model;
using Microsoft.SharePoint;
using System.Collections;
using System.Linq;

namespace ConfigurationFileTransformationExample.Services
{
    class SPWebSettingService : ISettingService
    {
        Dictionary<string, Setting> settings;

        public SPWebSettingService()
        {
            InitSettings();
        }

        private void InitSettings()
        {
            SPWeb website = SPContext.Current.Web;

            settings = (from DictionaryEntry property in website.AllProperties
                        where property.Key.ToString().StartsWith(Setting.Prefix)
                        select property)
                        .ToDictionary(de => de.Key.ToString(), de => new Setting { Key = de.Key.ToString(), Value = de.Value.ToString() });

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
