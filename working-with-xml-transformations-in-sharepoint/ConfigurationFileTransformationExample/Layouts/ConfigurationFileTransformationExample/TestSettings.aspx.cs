using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using ConfigurationFileTransformationExample.Services;

namespace ConfigurationFileTransformationExample.Layouts.ConfigurationFileTransformationExample
{
    public partial class TestSettings : LayoutsPageBase
    {
        ISettingService mappedfolderSVC;
        ISettingService spwebSVC;

        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataSource = mappedfolderSVC.FindAll();
            Repeater1.DataBind();

            Repeater2.DataSource = spwebSVC.FindAll();
            Repeater2.DataBind();
        }

        public TestSettings()
        {
            mappedfolderSVC = ServiceLocators.SettingServiceLocator.SettingService<MappedFolderSettingService>();
            spwebSVC = ServiceLocators.SettingServiceLocator.SettingService<SPWebSettingService>();
        }
    }
}
