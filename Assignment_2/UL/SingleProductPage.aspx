﻿<%@ Page Title="ProductPage" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="SingleProductPage.aspx.cs" Inherits="Assignment_2.UL.SingleProductPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container margin-space-top-100">
        <div class="row">
            <div class="col-sm center-text">
                <!-- Item description -->
                <asp:Label ID="lblTitle" runat="server" CssClass="h2"></asp:Label>
                <br/>
                <asp:Label ID="lblDescription" runat="server" CssClass="h3"></asp:Label>
                <br/><hr/>
                <asp:Label ID="lblPrice" runat="server" CssClass="h4"></asp:Label>
                <hr/>
                <h4 class="center-text">Size</h4>
                <!-- Validator for size radio list -->
                <div class="center-text">
                    <asp:RequiredFieldValidator ID="rfvSize" runat="server" ErrorMessage="Please select a size" ControlToValidate="rblSizeOption" CssClass="text-danger" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <!-- Size selection -->
                <div>
                    <asp:RadioButtonList ID="rblSizeOption" runat="server" RepeatDirection="Horizontal" CellPadding="10" OnSelectedIndexChanged="rblSizeOption_SelectedIndexChanged">
                        <asp:ListItem Text=" S" Value="S" />
                        <asp:ListItem Text=" M" Value="M" />
                        <asp:ListItem Text=" L" Value="L" />
                        <asp:ListItem Text=" XL" Value="XL" />
                        <asp:ListItem Text=" XXL" Value="XXL" />
                    </asp:RadioButtonList>
                </div>
                <!-- Validator for quantity selection -->
                <div class="center-text">
                    <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ErrorMessage="Please select a quantity" ControlToValidate="tbxQuantity" Display="Dynamic" CssClass="text-danger" SetFocusOnError="True" />
                    <asp:RegularExpressionValidator ID="rxvQuantity" runat="server" ErrorMessage="Select a whole number" CssClass="text-danger" Display="Dynamic" ControlToValidate="tbxQuantity" ValidationExpression="\d+" />
                    <asp:CustomValidator ID="csvQuantity" runat="server" CssClass="text-danger" Display="Dynamic" ControlToValidate="tbxQuantity" OnServerValidate="checkStock"></asp:CustomValidator>
                </div>

                <!-- Quantity -->
                <div id="quantity-select" class="input-group d-flex justify-content-center">
                    <asp:TextBox ID="tbxQuantity" runat="server" CssClass="form-control" PlaceHolder="0" TextMode="Number"></asp:TextBox>
                </div>

                <!-- Add to cart -->
                <div class="d-flex justify-content-center">
                    <asp:LinkButton ID="btnAddToCart" runat="server" CssClass="btn btn-danger" OnClick="btnAddToCart_Click">Add to Cart</asp:LinkButton>
                    <asp:Label ID="lblNoStock" runat="server" CssClass="text-danger" Text="No Stock"></asp:Label>

                </div>
            </div>
            <div class="col-sm">
                <!-- Product images -->
                <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel" data-interval="false">
                  <ol class="carousel-indicators">
                    <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                  </ol>
                  <div class="carousel-inner">
                    <div class="carousel-item active">
                        <asp:Image ID="imgFront" CssClass="d-block" runat="server" />
                    </div>
                    <div class="carousel-item">
                        <asp:Image ID="imgBack" CssClass="d-block" runat="server" />
                    </div>
                  </div>
                  <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                  </a>
                  <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                  </a>
                </div>
            </div>
        </div>
    </div>

    <%-- Input spinner for quantity input --%>
    <script src="/Scripts/bootstrap-input-spinner.js"></script>
    <script>
        $("#MainContent_tbxQuantity").inputSpinner()
    </script>
</asp:Content>
