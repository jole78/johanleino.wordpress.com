<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CascadingDropdownExtenderExample._Default" %>


<%--In Markup
<%@ Register TagPrefix="asp" Namespace="CascadingDropdownExtenderExample.WebControls" Assembly="CascadingDropdownExtenderExample" %>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager EnablePartialRendering="true" runat="server" />
    <div>

        <table>
            <tr>
                <td>Make</td>
                <td>
                <asp:NoValidationDropDownList ID="DropDownList1" runat="server" Width="170" />
                <%--<asp:DropDownList ID="DropDownList1" runat="server" Width="170" />--%>
                </td>
            </tr>
            <tr>
                <td>Model</td>
                <td>
                <asp:NoValidationDropDownList ID="DropDownList2" runat="server" Width="170" />
                <%--<asp:DropDownList ID="DropDownList2" runat="server" Width="170" />--%>
                </td>
            </tr>
            <tr>
                <td>Color</td>
                <td>
                <asp:NoValidationDropDownList ID="DropDownList3" runat="server" Width="170" />
                <%--<asp:DropDownList ID="DropDownList3" runat="server" Width="170" />--%>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat="server" Text="Save" OnClick="Save" />
                    <asp:Literal runat="server" ID="MakeModelColor" />
                </td>
            </tr>
        </table>
        <br />
        
        <asp:CascadingDropDown ID="CascadingDropDown1" runat="server" TargetControlID="DropDownList1"
            Category="Make"  PromptText="Please select a make"  LoadingText="[Loading makes...]"
            ServiceMethod="GetDropDownContents" />
        <asp:CascadingDropDown ID="CascadingDropDown2" runat="server" TargetControlID="DropDownList2"
            Category="Model" PromptText="Please select a model" LoadingText="[Loading models...]"
            ServiceMethod="GetDropDownContents" ParentControlID="DropDownList1" />
        <asp:CascadingDropDown ID="CascadingDropDown3" runat="server" TargetControlID="DropDownList3"
            Category="Color" PromptText="Please select a color" LoadingText="[Loading colors...]"
            ServiceMethod="GetDropDownContents"
            ParentControlID="DropDownList2" />
    
    </div>
    </form>
</body>
</html>
