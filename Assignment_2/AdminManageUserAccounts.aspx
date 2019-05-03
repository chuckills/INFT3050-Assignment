<%@ Page Title="Manage User Accounts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminManageUserAccounts.aspx.cs" Inherits="Assignment_1.AdminManageUserAccounts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%-- This page will be functionally redesigned once database functions are supported --%>
    
    <div class="container">
        <div class="row">
            <div class="col"></div>
            <div class="col-8">
                <h2 class="margin-space-top-20 padding-bottom-15"><%: Title %></h2>
                <ul class="list-group">
                  <li class="list-group-item align-items-center">
                      <div class="row">
                          <div class="col-2 text-left"><asp:Label ID="lblBadge1" runat="server" CssClass="badge badge-primary badge-pill" Text="Active"></asp:Label></div>
                          <div class="col-4 text-left">dylan@gmail.com</div>
                          <div class="col-6 text-right">
                            <asp:Button ID="Button1" runat="server" Text="View Transactions"  CssClass="btn btn-dark" OnClick="ViewTransactions_Click" />
                            <asp:Button ID="Button2" runat="server" Text="Suspend"  CssClass="btn btn-dark" OnClick="Button2_Click"/>
                          </div>
                      </div>
                  </li>
                  <li class="list-group-item align-items-center">
                      <div class="row">
                          <div class="col-2 text-left"><asp:Label ID="lblBadge2" runat="server" CssClass="badge badge-primary badge-pill" Text="Suspended"></asp:Label></div>
                          <div class="col-4 text-left">gregory@gmail.com</div>
                          <div class="col-6 text-right">
                            <asp:Button ID="Button3" runat="server" Text="View Transactions"  CssClass="btn btn-dark" OnClick="ViewTransactions_Click" />
                            <asp:Button ID="Button4" runat="server" Text="Activate"  CssClass="btn btn-dark" OnClick="Button4_Click"/>
                          </div>
                      </div>
                  </li>
                  <li class="list-group-item align-items-center">
                      <div class="row">
                          <div class="col-2 text-left"><asp:Label ID="lblBadge3" runat="server" CssClass="badge badge-primary badge-pill" Text="Active"></asp:Label></div>
                          <div class="col-4 text-left">christopher@gmail.com</div>
                          <div class="col-6 text-right">
                            <asp:Button ID="Button5" runat="server" Text="View Transactions"  CssClass="btn btn-dark" OnClick="ViewTransactions_Click" />
                            <asp:Button ID="Button6" runat="server" Text="Suspend"  CssClass="btn btn-dark" OnClick="Button6_Click" />
                          </div>
                      </div>
                  </li>
                </ul>
            </div>
            <div class="col"></div>
        </div>
    </div>
</asp:Content>
