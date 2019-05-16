<%@ Page Title="Login" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Assignment_2.UL.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<%-- Combined user and admin login page --%>
    
    <div class="container">
        <div class="row">
            <div class="col"></div>
            <div class="col">
                <h2 class="margin-space-top-50   padding-bottom-15"><%: Title %></h2>
                <div class="form-group">
                    <asp:TextBox ID="UsernameTextBox" CssClass="form-control" runat="server" Placeholder="Username"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="Required" CssClass="text-danger" Display="Dynamic" ControlToValidate="UsernameTextBox"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="PasswordTextBox" CssClass="form-control" runat="server" Placeholder="Password" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Required" CssClass="text-danger" Display="Dynamic" ControlToValidate="PasswordTextBox"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Button ID="LoginButton" runat="server" Text="Login" CssClass="btn btn-danger" OnClick="LoginButton_Click" />
                </div>
                <div class="form-group">
                    <asp:Label ID="LoginErrorLabel" runat="server" ForeColor="Red"></asp:Label>
                </div>
                <div>
                    <asp:HyperLink ID="RegistrationLink" runat="server" NavigateUrl="~/UL/Registration.aspx">Don't have an account? Register</asp:HyperLink>
                </div>
            </div>
            <div class="col"></div>
        </div>
    </div>
</asp:Content>