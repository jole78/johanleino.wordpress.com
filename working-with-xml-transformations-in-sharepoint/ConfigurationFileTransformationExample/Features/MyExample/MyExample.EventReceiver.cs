using System;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using ConfigurationFileTransformationExample.Extensions;
using ConfigurationFileTransformationExample.Model;
using Microsoft.SharePoint;

namespace ConfigurationFileTransformationExample.Features.MyExample
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("acbfb733-e375-4aa8-88d9-b9edda66603d")]
    public class MyExampleEventReceiver : SPFeatureReceiver
    {
        

        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {            

            SPWeb website = properties.Feature.Parent as SPWeb;

            FileInfo file;
            if (properties.Feature.TryLocateElementFile("app2.config", out file) == false)
            {
                throw new FileNotFoundException("element file file not found", "app2.config");
            }

            foreach (KeyValueConfigurationElement appSetting in file.AppSettings())
            {
                string fullkey = Setting.BuildWebSitePropertyKey(appSetting.Key);

                if (website.AllProperties.Contains(fullkey))
                {
                    website.SetProperty(fullkey, appSetting.Value);
                }
                else
                {
                    website.AddProperty(fullkey, appSetting.Value);
                }
                
                website.Update();
            }
            
        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPWeb website = properties.Feature.Parent as SPWeb;

            var query = from DictionaryEntry property in website.AllProperties
                        where property.Key.ToString().StartsWith(Setting.Prefix)
                        select property.Key.ToString();

            foreach (var result in query)
            {
                website.DeleteProperty(result);
                website.Update();
            }
        }


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
