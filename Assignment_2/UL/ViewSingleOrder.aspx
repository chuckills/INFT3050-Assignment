<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="ViewSingleOrder.aspx.cs" Inherits="Assignment_2.UL.ViewSingleOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <h1>Order #<asp:Label ID="lblOrderID" runat="server"></asp:Label></h1>
    <hr />

    Date:&nbsp;<asp:Label ID="lblDate" runat="server"></asp:Label>
    <hr/>
    <div class="row">
        <div class="col-8">
            <asp:ListView runat="server" ID="lsvItems">
                <ItemTemplate>
                    <li class="list-group-item">
                        <div class="row">
                            <div class="col-10">
                                <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("cartQuantity") %>' /> X <asp:Label ID="lblFirst" runat="server" Text='<%#Eval("playFirstName") %>' />
                                <asp:Label ID="lblLast" runat="server" Text='<%#Eval("playLastName") %>' /> - <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("prodDescription") %>' /> 
                                (Size: <asp:Label ID="lblSize" runat="server" Text='<%#Eval("sizeID") %>' />) 
                            </div>
                            <div class="col">
                                <asp:Label ID="lblUnit" runat="server" Text='<%#string.Format("{0:C}",Eval("cartUnitPrice")) %>' />
                            </div>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="col"></div>
    </div>
    
    <hr/>
    Subtotal:&nbsp;<asp:Label ID="lblSubtotal" runat="server"></asp:Label>
    <br/>
    Shipping:&nbsp;<asp:Label ID="lblShip" runat="server"></asp:Label> - <asp:Label ID="lblShipCost" runat="server"></asp:Label>
    <br/>
    Total:&nbsp;<asp:Label ID="lblTotal" runat="server"></asp:Label>
    <br/>
    GST included:&nbsp;<asp:Label ID="lblGst" runat="server"></asp:Label>

    <div class="margin-space-top-20">
        <asp:LinkButton ID="BackButton" runat="server" PostBackUrl="~/UL/PurchaseHistory" CssClass="btn btn-danger">Return to Purchase History</asp:LinkButton>
    </div>

</asp:Content>