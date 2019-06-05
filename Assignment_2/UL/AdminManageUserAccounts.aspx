﻿<%@ Page Title="Manage User Accounts" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminManageUserAccounts.aspx.cs" Inherits="Assignment_2.UL.AdminManageUserAccounts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">
        
        <h2>User Management</h2>

        <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvUsers_SelectedIndexChanged" HeaderStyle-HorizontalAlign="Center">
            <Columns>  
                <asp:BoundField DataField="userID" HeaderText="ID" ReadOnly="True" />  
                <asp:BoundField DataField="userFirstName" HeaderText="FirstName" ReadOnly="True" />  
                <asp:BoundField DataField="userLastName" HeaderText="LastName" ReadOnly="True" />  
                <asp:BoundField DataField="userEmail" HeaderText="Email" ReadOnly="True" /> 
                <asp:BoundField DataField="userPhone" HeaderText="Phone" ReadOnly="True" />  
                <asp:BoundField DataField="userAdmin" HeaderText="Admin" ReadOnly="True" /> 
                <asp:BoundField DataField="userActive" HeaderText="Active" ReadOnly="True" /> 
                <asp:CommandField ShowSelectButton="True" ButtonType="Button" ControlStyle-CssClass="btn btn-outline-danger" />
            </Columns>  
        </asp:GridView>
    </div>
</asp:Content>
