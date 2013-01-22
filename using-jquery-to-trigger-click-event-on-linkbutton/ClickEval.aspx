<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ClickEval.aspx.cs" Inherits="ClickEval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">


    <asp:ListView ID="ListView1" runat="server" DataSourceID="BooksDS" 
    EnableModelValidation="True">
    <EditItemTemplate>
        <tr style="background-color:#008A8C;color: #FFFFFF;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                    Text="Update" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                    Text="Cancel" />
            </td>
            <td>
                <asp:TextBox ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />
            </td>
            <td>
                <asp:TextBox ID="AuthorTextBox" runat="server" Text='<%# Bind("Author") %>' />
            </td>
            <td>
                <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
            </td>
            <td>
                <asp:TextBox ID="GenreTextBox" runat="server" Text='<%# Bind("Genre") %>' />
            </td>
            <td>
                <asp:TextBox ID="PriceTextBox" runat="server" Text='<%# Bind("Price") %>' />
            </td>
            <td>
                <asp:TextBox ID="PublishDateTextBox" runat="server" 
                    Text='<%# Bind("PublishDate") %>' />
            </td>
            <td>
                <asp:TextBox ID="DescriptionTextBox" runat="server" 
                    Text='<%# Bind("Description") %>' />
            </td>
        </tr>
    </EditItemTemplate>
    <EmptyDataTemplate>
        <table runat="server" 
            style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
            <tr>
                <td>
                    No data was returned.</td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <ItemTemplate>
        <tr class="command">
            <td class="command">
                <asp:LinkButton Text="Edit" runat="server" CommandName="Edit" />
            </td>
            <td>
                <asp:Label ID="AuthorLabel" runat="server" Text='<%# Eval("Author") %>' />
            </td>
            <td>
                <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
            </td>
            <td>
                <asp:Label ID="GenreLabel" runat="server" Text='<%# Eval("Genre") %>' />
            </td>
            <td>
                <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
            </td>
            <td>
                <asp:Label ID="PublishDateLabel" runat="server" 
                    Text='<%# Eval("PublishDate") %>' />
            </td>
            <td>
                <asp:Label ID="DescriptionLabel" runat="server" 
                    Text='<%# Eval("Description") %>' />
            </td>
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table runat="server">
            <tr runat="server">
                <td runat="server">
                    <table ID="itemPlaceholderContainer" runat="server" border="1" 
                        style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                            <th runat="server">
                                </th>
                            <th runat="server">
                                Author</th>
                            <th runat="server">
                                Title</th>
                            <th runat="server">
                                Genre</th>
                            <th runat="server">
                                Price</th>
                            <th runat="server">
                                PublishDate</th>
                            <th runat="server">
                                Description</th>
                        </tr>
                        <tr ID="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" 
                    style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                </td>
            </tr>
        </table>
    </LayoutTemplate>
    </asp:ListView>
<asp:ObjectDataSource ID="BooksDS" runat="server" SelectMethod="FindAll" 
    TypeName="BookContext"></asp:ObjectDataSource>

</asp:Content>

