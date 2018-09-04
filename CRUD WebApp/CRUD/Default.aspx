<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="CRUD._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div style="font-weight:bold">Create User</div>
    <span style="height:50px; vertical-align:top">Email :</span> 
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <span style="height:50px; vertical-align:top">Given Name :</span> 
    <asp:TextBox ID="txtGivenName" runat="server"></asp:TextBox>
    <span style="height:50px; vertical-align:top">Family Name :</span> 
    <asp:TextBox ID="txtFamilyName" runat="server"></asp:TextBox>    
    <asp:Button ID="btnCreate" runat="server" Text="Create" 
    onclick="btnCreate_Click" />
    <hr />

    <div style="font-weight:bold">Delete User By ID</div>
    <span style="height:20px; vertical-align:top">User ID :</span>
    <asp:TextBox ID="txtDeleteID" runat="server"></asp:TextBox>
    <asp:Button ID="btnDelete" runat="server" Text="Delete" onclick="btnDelete_Click" />
    <hr />

    <div style="font-weight:bold">Search User</div>
    <span style="height:20px; vertical-align:top">User Given Name :</span>
    <asp:TextBox ID="txtSearchName" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Search" 
        onclick="btnSearch_Click" />
    <asp:GridView ID="gvCountryList" runat="server">
    </asp:GridView>
    <hr />
<div style="font-weight:bold">Edit User Info</div>
<span style="height:20px; vertical-align:top">User ID :</span>
<asp:DropDownList ID="ddlUsers" runat="server" AutoPostBack="True" onselectedindexchanged="ddlUsers_SelectedIndexChanged">    
</asp:DropDownList>        
<br />
<span style="height:50px; vertical-align:top">Email :</span> 
    <asp:TextBox ID="txtEmailUpdate" runat="server"></asp:TextBox>
    <span style="height:50px; vertical-align:top">Given Name :</span> 
    <asp:TextBox ID="txtGivenNameUpdate" runat="server"></asp:TextBox>
    <span style="height:50px; vertical-align:top">Family Name :</span> 
    <asp:TextBox ID="txtFamilyNameUpdate" runat="server"></asp:TextBox> 
<asp:Button ID="btnEditUser" runat="server" Text="UpdateUser" onclick="btnEditUserName_Click" />
</asp:Content>
