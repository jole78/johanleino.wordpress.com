<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Page language="C#" Inherits="Public.SharePoint.PageLayouts.PageLayoutBase" %>

<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Register Tagprefix="sp" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c"  %>
<%@ Register Tagprefix="sp" Namespace="Microsoft.SharePoint.Publishing.WebControls" Assembly="Microsoft.SharePoint.Publishing, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c"  %>
<%@ Register Tagprefix="sp" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ContentPlaceHolderId="PlaceHolderMain" runat="server">  
 
  <h1><sp:FieldValue FieldName="Title" runat="server"/></h1>
  
  <sp:RichImageField FieldName="PublishingPageImage" runat="server"/>

</asp:Content>