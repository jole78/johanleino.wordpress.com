using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Publishing;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace Public.SharePoint.PageLayouts
{
    public class PageLayoutBase : PublishingLayoutPage
    {
        
        protected override void OnPreInit(EventArgs e)
        {
            // this sets the MasterPageFile to public.master (if the web has been setup to use that)
            base.OnPreInit(e);

            try
            {
                if (SPContext.Current.Web.CurrentUser != null && this.MasterPageFile.EndsWith("public.master", StringComparison.OrdinalIgnoreCase))
                { 
                    //the user is logged in and the site uses the public.master

                    // change it to private.master
                    this.MasterPageFile = SPUrlUtility.CombineUrl(SPContext.Current.Site.ServerRelativeUrl, string.Concat("_catalogs/masterpage/", "private.master"));
                    
                    
                }

            }
            catch { } // this is an error trap, don't do anything 
        }
    }
}
