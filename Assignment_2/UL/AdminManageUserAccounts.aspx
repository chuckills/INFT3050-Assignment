﻿<%@ Page Title="Manage User Accounts" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminManageUserAccounts.aspx.cs" Inherits="Assignment_2.UL.AdminManageUserAccounts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">
        
        <h2 class="margin-space-top-20">User Management</h2>
        <hr/>

        <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvUsers_OnRowDataBound" OnSelectedIndexChanged="gvUsers_SelectedIndexChanged" HeaderStyle-HorizontalAlign="Center" CssClass="table">
            <Columns>  
                <asp:BoundField DataField="userID" HeaderText="ID" ReadOnly="True" />  
                <asp:BoundField DataField="userFirstName" HeaderText="FirstName" ReadOnly="True" />  
                <asp:BoundField DataField="userLastName" HeaderText="LastName" ReadOnly="True" />  
                <asp:BoundField DataField="userEmail" HeaderText="Email" ReadOnly="True" /> 
                <asp:BoundField DataField="userPhone" HeaderText="Phone" ReadOnly="True" />  
                <asp:BoundField DataField="userAdmin" HeaderText="Admin" ReadOnly="True" /> 
                <%--<asp:BoundField DataField="userActive" HeaderText="Active" ReadOnly="True" />--%>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Button ID="btnActive" runat="server" CausesValidation="false" OnClick="btnActive_Clicked" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowSelectButton="True" ButtonType="Button" ControlStyle-CssClass="btn btn-outline-danger" />
            </Columns>  
            <HeaderStyle HorizontalAlign="Center" CssClass="thead-dark" />
            <RowStyle HorizontalAlign="Center" />
        </asp:GridView>
    </div>
</asp:Content>
