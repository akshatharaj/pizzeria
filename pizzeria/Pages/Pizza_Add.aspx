﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCMS.master" AutoEventWireup="true"
    CodeFile="Pizza_Add.aspx.cs" Inherits="Pages_Pizza_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>
        Add new Pizza</h3>
    <table cellspacing="15" class="pizzaTable">
        <tr>
            <td style="width: 80px">
                <b>Name:</b>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtName" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 80px">
                <b>Type:</b>
            </td>
            <td>
                <asp:TextBox ID="txtType" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 80px">
                <b>Price:</b>
            </td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 80px">
                <b>Crust:</b>
            </td>
            <td>
                <asp:TextBox ID="txtCrust" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 80px">
                <b>Sause:</b>
            </td>
            <td>
                <asp:TextBox ID="txtSause" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 80px; height: 63px;">
                <b>Image:</b>
            </td>
            <td style="height: 63px">
                <asp:DropDownList ID="ddlImage" runat="server" Width="300px">
                </asp:DropDownList>
                <br/>
                <asp:FileUpload ID="FileUpload1" runat="server" /> 
                <asp:Button ID="btnUploadImage" runat="server" Text="Upload Image" 
                    onclick="btnUploadImage_Click" CausesValidation="False" /> 
            </td>
            
        </tr>
        <tr>
            <td style="width: 80px">
                <b>Review:</b>
            </td>
            <td>
                <asp:TextBox ID="txtReview" runat="server" Height="98px" TextMode="MultiLine" Width="332px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
    
    

</asp:Content>
