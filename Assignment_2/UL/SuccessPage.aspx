﻿<%@ Page Title="Success" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="SuccessPage.aspx.cs" Inherits="Assignment_2.UL.SuccessPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="margin-space-top-20">
        <asp:Label ID="StatusLabel" runat="server" Text="Label" CssClass="h2"></asp:Label>
    </div>
    <hr/>
    <div class="margin-spacing-bottom">
        <asp:Label ID="DescriptionLabel" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <asp:Button ID="ResultingButton" runat="server" Text="Button" CssClass="btn btn-danger" />
    </div>
</asp:Content>
