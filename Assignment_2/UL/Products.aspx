<%@ Page Title="Shop" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Assignment_2.Products" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row margin-space-top-20">
            <div class="col-sm">
                <h2 class="product-buy-heading">Kyrie Irving</h2>
                <img alt="" src="Images/jerseys/kyrie-irving-front.jpg" class="d-block w-100" />
                <h3 class="product-price-title">$100</h3>
                <div class="d-flex justify-content-center">
                    <asp:LinkButton ID="LinkButton1" runat="server" postbackurl="~/UL/SingleProductPage"  
                        class="product-buy-btn btn btn-danger">Buy</asp:LinkButton>
                </div>        
            </div>
            <div class="col-sm">
                <h2 class="product-buy-heading">Steph Curry</h2>
                <img alt="" src="Images/jerseys/steph-curry-front.png" class="d-block w-100" />
                <h3 class="product-price-title">$100</h3>
                <div class="d-flex justify-content-center">
                    <asp:LinkButton ID="LinkButton2" runat="server" postbackurl="~/UL/SingleProductPage"  
                        class="product-buy-btn btn btn-danger">Buy</asp:LinkButton>
                </div> 
            </div>
            <div class="col-sm">
                <h2 class="product-buy-heading">Lebron James</h2>
                <img alt="" src="Images/jerseys/lebron-james-front.jpg" class="d-block w-100" />
                <h3 class="product-price-title">$100</h3>
                <div class="d-flex justify-content-center">
                    <asp:LinkButton ID="LinkButton3" runat="server" postbackurl="~/UL/SingleProductPage"  
                        class="product-buy-btn btn btn-danger">Buy</asp:LinkButton>
                </div> 
            </div>
            <div class="col-sm">
                <h2 class="product-buy-heading">James Harden</h2>
                <img alt="" src="Images/jerseys/james-harden-front.png" class="d-block w-100" />
                <h3 class="product-price-title">$100</h3>
                <div class="d-flex justify-content-center">
                    <asp:LinkButton ID="LinkButton4" runat="server" postbackurl="~/UL/SingleProductPage"  
                        class="product-buy-btn btn btn-danger">Buy</asp:LinkButton>
                </div> 
            </div>
        </div>
        <div class="row margin-space-top-50 padding-bottom-15">
            <div class="col-sm">
                <h2 class="product-buy-heading">Devin Booker</h2>
                <img alt="" src="Images/jerseys/devin-booker-front.png" class="d-block w-100" />
                <h3 class="product-price-title">$100</h3>
                <div class="d-flex justify-content-center">
                    <asp:LinkButton ID="LinkButton5" runat="server" postbackurl="~/UL/SingleProductPage"  
                        class="product-buy-btn btn btn-danger">Buy</asp:LinkButton>
                </div> 
            </div>
            <div class="col-sm">
                <h2 class="product-buy-heading">Russell Westbrook</h2>
                <img alt="" src="Images/jerseys/russell-westbrook-front.png" class="d-block w-100" />
                <h3 class="product-price-title">$100</h3>
                <div class="d-flex justify-content-center">
                    <asp:LinkButton ID="LinkButton6" runat="server" postbackurl="~/UL/SingleProductPage"  
                        class="product-buy-btn btn btn-danger">Buy</asp:LinkButton>
                </div> 
            </div>
            <div class="col-sm">
                <h2 class="product-buy-heading">Kemba Walker</h2>
                <img alt="" src="Images/jerseys/kemba-walker-front.png" class="d-block w-100" />
                <h3 class="product-price-title">$100</h3>
                <div class="d-flex justify-content-center">
                    <asp:LinkButton ID="LinkButton7" runat="server" postbackurl="~/UL/SingleProductPage"  
                        class="product-buy-btn btn btn-danger">Buy</asp:LinkButton>
                </div> 
            </div>
            <div class="col-sm">
                <h2 class="product-buy-heading">Victor Oladipo</h2>
                <img alt="" src="Images/jerseys/victor-oladipo-front.jpg" class="d-block w-100" />
                <h3 class="product-price-title">$100</h3>
                <div class="d-flex justify-content-center">
                    <asp:LinkButton ID="LinkButton8" runat="server" postbackurl="~/UL/SingleProductPage"  
                        class="product-buy-btn btn btn-danger">Buy</asp:LinkButton>
                </div> 
            </div>
        </div>
    </div>

</asp:Content>
