
namespace ConfigurationFileTransformationExample.Model
{
    class Setting
    {
        public const string Prefix = "appSetting__";

        public string Key { get; set; }
        public string Value { get; set; }

        internal static string BuildWebSitePropertyKey(string key)
        {
            return string.Concat(Prefix, key);
        }
    }
}
