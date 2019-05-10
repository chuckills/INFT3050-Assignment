<%@ Page Title="Shopping Cart" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Assignment_2.UL.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2 class="margin-space-top-50 tag-spacing-bottom"><%: Title %></h2>

    <div class="container">
        <div class="row">
            <div class="col">
                <ul class="list-group list-group-flush">

                    <%-- Lists the cart items --%>
                    <asp:ListView ID="ItemList" runat="server" ItemType="Assignment_2.Models.CartItem"
                        SelectMethod="GetCartItems">
                        <EmptyDataTemplate>
                            <li class="list-group-item">Cart is currently empty...</li>
                        </EmptyDataTemplate>
                        <ItemTemplate>
                            <li class="list-group-item">
                                <div class="row">
                                    <div class="col">
                                        <img alt="" src="Images\jerseys\kyrie-irving-front.jpg" class="cart-product-icon" />
                                    </div>
                                    <div class="col-6 center-text">
                                        <%#:Item.ToString() %>
                                    </div>
                                    <div class="col">
                                        <asp:CheckBox ID="cbxRemove" runat="server" Text="&nbsp;Remove" />
                                    </div>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:ListView>

                </ul>
            </div>
            
            <%-- Cart operations --%>
            <div class="col">
                <div class="margin-space-bottom-50">
                    <asp:LinkButton ID="btnRemove" runat="server" CssClass="btn btn-danger" OnClick="btnRemove_Click">Remove Selected</asp:LinkButton>
                </div>
                <div class="padding-bottom-15">
                    <h3>Total Cost:</h3>
                    <asp:Label ID="Cost" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="padding-bottom-15">
                    <asp:LinkButton ID="btnCheckout" runat="server" CssClass="btn btn-danger" OnClick="btnCheckout_Click">Checkout</asp:LinkButton>
                    <asp:LinkButton ID="btnEmptyCart" runat="server" CssClass="btn btn-danger" OnClick="btnEmptyCart_Click">Empty Cart</asp:LinkButton>
                </div>
                <div>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UL/Products.aspx">Continue shopping?</asp:HyperLink>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
