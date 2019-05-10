<%@ Page Title="Update Item" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminUpdateSelectedItem.aspx.cs" Inherits="Assignment_1.AdminUpdateSelectedItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <%-- Page to update a product details --%>
    <div class="container">
        <div class="row">
            <div class="col"></div>
            <div class="col">

                <h2 class="margin-space-top-100 padding-bottom-15">Edit Product - Update Information</h2>

                <%-- Product Title --%>
                <div class="form-group">
                    <asp:TextBox ID="ProductTitleTextbox" runat="server" PlaceHolder="Product Title" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvProductTitle" runat="server" ErrorMessage="Required" CssClass="text-danger" Display="Dynamic" ControlToValidate="ProductTitleTextbox"></asp:RequiredFieldValidator>
                </div>

                <%-- Product Image --%>
                <div class="form-group">
                    <asp:TextBox ID="ImagePathTextbox" runat="server" PlaceHolder="Image File Path" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvImage" runat="server" ErrorMessage="Required" CssClass="text-danger" Display="Dynamic" ControlToValidate="ImagePathTextbox"></asp:RequiredFieldValidator>
                </div>

                <%-- Product price --%>
                <div class="form-group">
                    <asp:TextBox ID="PriceTextBox" runat="server" PlaceHolder="Price" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ErrorMessage="Required" CssClass="text-danger" Display="Dynamic" ControlToValidate="PriceTextBox"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rxvPrice" runat="server" ErrorMessage="Enter a money value" CssClass="text-danger" Display="Dynamic" ControlToValidate="PriceTextBox" ValidationExpression="\d+(\.\d{2})?"></asp:RegularExpressionValidator>
                </div>

                <div class="form-group">
                    <asp:Button ID="UpdateProductButton" runat="server" Text="Update" CssClass="btn btn-danger" OnClick="UpdateProductButton_Click" />
                    <asp:Button ID="RemoveProductButton" runat="server" Text="Remove Product" CssClass="btn btn-danger" OnClick="RemoveProductButton_Click" />
                </div>
            </div>
            <div class="col"></div>
        </div>
    </div>
</asp:Content>
