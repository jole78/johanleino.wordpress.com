using System;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.UI;
using AjaxControlToolkit;
using System.Xml;
using System.Text.RegularExpressions;

namespace CascadingDropdownExtenderExample
{
    public partial class _Default : Page
    {

        private static XmlDocument m_Document;
        private static Regex m_InputValidationRegex;
        private static readonly object m_Lock = new object();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static XmlDocument Document
        {
            get
            {
                lock (m_Lock)
                {
                    if (m_Document == null)
                    {
                        // Read XML data from disk
                        m_Document = new XmlDocument();
                        m_Document.Load(HttpContext.Current.Server.MapPath("~/App_Data/SampleData.xml"));
                    }
                }
                return m_Document;
            }
        }

        public static string[] Hierarchy
        {
            get { return new string[] { "make", "model" }; }
        }

        public static Regex InputValidationRegex
        {
            get
            {
                lock (m_Lock)
                {
                    if (null == m_InputValidationRegex)
                    {
                        m_InputValidationRegex = new Regex("^[0-9a-zA-Z \\(\\)]*$");
                    }
                }
                return m_InputValidationRegex;
            }
        }

        protected void Save(object sender, EventArgs e)
        { 
            MakeModelColor.Text = string.Format("{0} {1} {2}", DropDownList1.Text, DropDownList2.Text, DropDownList3.Text);
        }

        [WebMethod]
        [ScriptMethod]
        public static CascadingDropDownNameValue[] GetDropDownContents(string knownCategoryValues, string category)
        {
            // Get a dictionary of known category/value pairs
            var knownCategoryValuesDictionary = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

            // Perform a simple query against the data document
            return CascadingDropDown.QuerySimpleCascadingDropDownDocument(Document, Hierarchy, knownCategoryValuesDictionary, category, InputValidationRegex);
        }
    }
}