<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PurchaseHistory.aspx.cs" Inherits="Assignment_1.PurchaseHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <br />
    <h1>Your Purchase History</h1>
    

    <asp:ListView ID="lsvHistory" runat="server" ItemType="System.String"
                  SelectMethod="GetPurchaseHistory">
        <EmptyDataTemplate>
            <li class="list-group-item">No orders for this user...</li>
        </EmptyDataTemplate>
        <ItemTemplate>
            <li class="list-group-item">
                <div class="row">
                    <div class="col-6">
                        <%#:Item %> 
                    </div>
                </div>
            </li>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
