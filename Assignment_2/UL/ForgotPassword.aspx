<%@ Page Title="Get New Password" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Assignment_2.UL.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col"></div>
            <div class="col">
                <h2 class="margin-space-top-50 padding-bottom-15"><%: Title %></h2>
                <div>
                    <p>
                        Please enter the email address which you assigned to your user account and we will send you an email to verify your identity. Once the email is received, click on the link and you will
                        then be given the option to update your password.
                    </p>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="EmailTextBox" CssClass="form-control" runat="server" Placeholder="Account Email" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="Required" CssClass="text-danger" Display="Dynamic" ControlToValidate="UsernameTextBox"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Button ID="RequestButton" runat="server" Text="Get Verification Email" CssClass="btn btn-danger" OnClick="RequestButton_Click" />
                </div>
                <div class="form-group">
                    <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div class="col"></div>
        </div>
    </div>
</asp:Content>
