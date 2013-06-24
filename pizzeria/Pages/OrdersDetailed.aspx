<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCMS.master" AutoEventWireup="true" CodeFile="OrdersDetailed.aspx.cs" Inherits="Pages.Pages_OrdersDetailed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblTitle" runat="server"></asp:Label>
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
        CellPadding="12" DataSourceID="sds_DetailedOrder" ForeColor="Black" 
        GridLines="Vertical" Width="503px" DataKeyNames="id">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" 
                ReadOnly="True" SortExpression="id" InsertVisible="False" />
<asp:BoundField DataField="client" HeaderText="client" SortExpression="client"></asp:BoundField>
            <asp:BoundField DataField="product" HeaderText="product" 
                SortExpression="product" />
            <asp:BoundField DataField="amount" HeaderText="amount" 
                SortExpression="amount" />
            <asp:BoundField DataField="price" HeaderText="price" 
                SortExpression="price" />
            <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
            <asp:CheckBoxField DataField="orderShipped" HeaderText="orderShipped" 
                SortExpression="orderShipped" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
    <asp:SqlDataSource ID="sds_DetailedOrder" runat="server" 
        ConnectionString="<%$ ConnectionStrings:pizzaConnection %>" 
        SelectCommand="SELECT [id], [client], [product], [amount], [price], [date], [orderShipped] FROM [orders] WHERE (([client] = @client) AND ([date] = @date))" 
        onselecting="sds_DetailedOrder_Selecting">
        <SelectParameters>
            <asp:QueryStringParameter Name="client" QueryStringField="client" 
                Type="String" />
            <asp:QueryStringParameter DbType="Date" Name="date" QueryStringField="date" />
        </SelectParameters>
    </asp:SqlDataSource>
     <br />
    <asp:Button ID="btnShip" runat="server" Height="41px" Text="Ship Order" 
        Width="125px" onclick="btnShip_Click" />
    <br />
    </asp:Content>

