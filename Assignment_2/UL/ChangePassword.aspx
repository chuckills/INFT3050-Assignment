<%@ Page Title="Update Password" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Assignment_2.UL.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col"></div>
            <div class="col">
                <h2 class="margin-space-top-50 padding-bottom-15"><%: Title %></h2>
                <div class="form-group">
                    <asp:TextBox ID="Password1TextBox" CssClass="form-control" runat="server" Placeholder="Enter Password" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword1" runat="server" ErrorMessage="Required" CssClass="text-danger" Display="Dynamic" ControlToValidate="Password1TextBox"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="Password2TextBox" CssClass="form-control" runat="server" Placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="Password2TextBox" CssClass="ValidationError" ControlToCompare="Password1TextBox" ErrorMessage="No Match" ToolTip="Password must be the same" />
                    <asp:RequiredFieldValidator ID="rfvPassword2" runat="server" ErrorMessage="Required" CssClass="text-danger" Display="Dynamic" ControlToValidate="Password2TextBox"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Button ID="SubmitButton" runat="server" Text="Update" CssClass="btn btn-danger" OnClick="SubmitButton_Click" />
                </div>
                <div class="form-group">
                    <asp:Label ID="NoMatchErrorLabel" runat="server" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div class="col"></div>
        </div>
    </div>
</asp:Content>
