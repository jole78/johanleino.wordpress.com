using System;
using System.Configuration;
using System.IO;

namespace ConfigurationFileTransformationExample.Extensions
{
    /// <summary>
    /// Extensions for the FileInfo class
    /// </summary>
    public static class FileInfoExtensions
    {
        public static KeyValueConfigurationCollection AppSettings(this FileInfo instance)
        {
            Configuration configuration = null;

            try
            {
                var map = new ExeConfigurationFileMap { ExeConfigFilename = instance.FullName };
                configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

                if (configuration.HasFile == false)
                {
                    throw new Exception("FileInfoExtensions: The Configuration instance has no file associated. ExeConfigurationFileMap was constructed with an invalid filepath.");
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return configuration.AppSettings.Settings;
        }
    }
}
