<%@ Page Title="Get New Password" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Assignment_2.UL.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="Panel1" CssClass="row" runat="server" DefaultButton="RequestButton">
            <div class="col"></div>
            <div class="col">
                <h2 class="margin-space-top-50 padding-bottom-15"><%: Title %></h2>
                <hr />
                <div>
                    <p>
                        Please enter the email address which you assigned to your user account and we will send you an email to verify your identity. Once the email is received, click on the link and you will
                        then be given the option to update your password.
                    </p>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="EmailTextBox" CssClass="form-control" runat="server" Placeholder="Account Email" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Required" CssClass="text-danger" Display="Dynamic" ControlToValidate="EmailTextBox"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="csvEmail" runat="server" ErrorMessage="No account exists under this email" CssClass="text-danger" OnServerValidate="checkExists" ControlToValidate="EmailTextBox" Display="Dynamic" SetFocusOnError="True"></asp:CustomValidator>
                </div>
                <div class="form-group">
                    <asp:Button ID="RequestButton" runat="server" Text="Get Verification Email" CssClass="btn btn-danger" OnClick="RequestButton_Click" />
                </div>
                <div class="form-group">
                    <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div class="col"></div>
        </asp:Panel>
    </div>
</asp:Content>
