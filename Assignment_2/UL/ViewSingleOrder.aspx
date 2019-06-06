<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="ViewSingleOrder.aspx.cs" Inherits="Assignment_2.UL.ViewSingleOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <h1>Order #<asp:Label ID="lblOrderID" runat="server"></asp:Label></h1>
    <hr />

    Date:&nbsp;<asp:Label ID="lblDate" runat="server"></asp:Label>
    <hr/>
    <asp:ListView runat="server" ID="lsvItems">
        <ItemTemplate>
            <li class="list-group-item">
                <div class="row">
                    <div class="col-6">
                        <%-- Data-bound content. --%>
                        <asp:Label ID="lblprodNum" runat="server" Text='<%#Eval("prodNumber") %>' />,&nbsp;<asp:Label ID="lblSize" runat="server" Text='<%#Eval("sizeID") %>' />
                        ,&nbsp;<asp:Label ID="lblFirst" runat="server" Text='<%#Eval("playFirstName") %>' />,&nbsp;<asp:Label ID="lblLast" runat="server" Text='<%#Eval("playLastName") %>' />
                        ,&nbsp;<asp:Label ID="lblDescription" runat="server" Text='<%#Eval("prodDescription") %>' />,&nbsp;<asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("cartQuantity") %>' />
                        ,&nbsp;<asp:Label ID="lblUnit" runat="server" Text='<%#string.Format("{0:C}",Eval("cartUnitPrice")) %>' />
                    </div>
                </div>
            </li>
        </ItemTemplate>
    </asp:ListView>
    <hr/>
    Subtotal:&nbsp;<asp:Label ID="lblSubtotal" runat="server"></asp:Label>
    <br/>
    Shipping:&nbsp;<asp:Label ID="lblShip" runat="server"></asp:Label><asp:Label ID="lblShipCost" runat="server"></asp:Label>
    <br/>
    Total:&nbsp;<asp:Label ID="lblTotal" runat="server"></asp:Label>
    <br/>
    GST included:&nbsp;<asp:Label ID="lblGst" runat="server"></asp:Label>

</asp:Content>