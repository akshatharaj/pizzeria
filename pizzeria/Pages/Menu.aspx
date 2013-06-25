<%@ Page Title="Menu" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Pages_Pizza" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
    Select a type:
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        DataSourceID="sds_type" DataTextField="type" DataValueField="type" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:SqlDataSource ID="sds_type" runat="server" 
        ConnectionString="<%$ ConnectionStrings:pizzaConnection %>" 
        SelectCommand="SELECT DISTINCT [type] FROM [pizza] ORDER BY [type]">
    </asp:SqlDataSource>
</p>
<p>
    <asp:Label ID="lblOuput" runat="server" Text="Label"></asp:Label>
</p>
</asp:Content>

