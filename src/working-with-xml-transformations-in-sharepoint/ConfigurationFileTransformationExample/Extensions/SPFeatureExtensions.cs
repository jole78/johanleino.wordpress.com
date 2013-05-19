using System.IO;
using System.Linq;
using Microsoft.SharePoint;

namespace ConfigurationFileTransformationExample.Extensions
{
    /// <summary>
    /// Extensions for the SPFeature class
    /// </summary>
    public static class SPFeatureExtensions
    {
        

        public static DirectoryInfo Directory(this SPFeature instance)
        {
            return new DirectoryInfo(instance.Definition.RootDirectory);
        }

        public static bool TryLocateElementFile(this SPFeature instance, string fileName, out FileInfo value)
        {
           
            value = instance.Directory()
                        .GetFiles(fileName, SearchOption.AllDirectories)
                        .FirstOrDefault();

            return value != null;
        }



 
    }
}
