<%@ Page Title="Manage User Accounts" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminManageUserAccounts.aspx.cs" Inherits="Assignment_2.UL.AdminManageUserAccounts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">
        
        <h2 class="margin-space-top-20">User Management</h2>
        <hr/>

        <asp:GridView ID="gvUsers" runat="server" OnRowCommand="gvUsers_OnRowCommand" AutoGenerateColumns="False" OnRowDataBound="gvUsers_OnRowDataBound" HeaderStyle-HorizontalAlign="Center">
            <Columns>  
                <asp:BoundField DataField="userID" HeaderText="ID" ReadOnly="True" />  
                <asp:BoundField DataField="userFirstName" HeaderText="FirstName" ReadOnly="True" />  
                <asp:BoundField DataField="userLastName" HeaderText="LastName" ReadOnly="True" />  
                <asp:BoundField DataField="userEmail" HeaderText="Email" ReadOnly="True" /> 
                <asp:BoundField DataField="userPhone" HeaderText="Phone" ReadOnly="True" />  
                <asp:BoundField DataField="userAdmin" HeaderText="Admin" ReadOnly="True" />
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Button ID="btnStatus" runat="server" CausesValidation="False" CommandName="Status" CommandArgument="<%# (Container as GridViewRow).RowIndex %>" Text="Activated" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:Button ID="btnSelect" CssClass="btn btn-outline-danger" runat="server" CausesValidation="False" CommandName="Select" CommandArgument="<%# (Container as GridViewRow).RowIndex %>" Text="Select" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>  
            <HeaderStyle HorizontalAlign="Center" CssClass="thead-dark" />
            <RowStyle HorizontalAlign="Center" />
        </asp:GridView>
    </div>
</asp:Content>
