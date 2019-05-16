<%@ Page Title="Shop" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Assignment_2.UL.Products" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row margin-space-top-20">
            <asp:Repeater ID="rptProducts" runat="server">
                <ItemTemplate>
                    <div class="col-sm-3">
                        <h2 class="product-buy-heading"><%# DataBinder.Eval(Container.DataItem, "playFirstName") + "<br/>" + DataBinder.Eval(Container.DataItem, "playLastName")%></h2>
                        <img alt="" src="Images/jerseys/<%# DataBinder.Eval(Container.DataItem, "imgFront") %>" class="d-block w-100" />
                        <h3 class="product-price-title"><%# string.Format("{0:C0}", DataBinder.Eval(Container.DataItem, "prodPrice")) %></h3>
                        <div class="d-flex justify-content-center">
                            <asp:LinkButton ID="btnBuy" runat="server" CssClass="product-buy-btn btn btn-danger" onClick="btnBuy_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "prodNumber") %>'>Buy</asp:LinkButton>
                        </div> 
                        <hr/>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
