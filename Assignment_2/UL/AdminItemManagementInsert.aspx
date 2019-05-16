<%@ Page Title="Insert Product" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminItemManagementInsert.aspx.cs" Inherits="Assignment_2.UL.AdminItemManagementInsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<%-- Page to add a new product --%>
    <div class="container">
        <div class="row">
            <div class="col">
                <h2>New Product</h2>
                <hr/>
                <asp:Table ID="tblPlayer" runat="server">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">First Name</asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxFirstName" runat="server" CssClass="form-control"></asp:TextBox></asp:TableCell>
                        <asp:TableCell runat="server"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Last Name</asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxLastName" runat="server" CssClass="form-control"></asp:TextBox></asp:TableCell>
                        <asp:TableCell runat="server"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Team</asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:DropDownList ID="ddlTeam" CssClass="form-control" runat="server" DataSourceID="dsTeams" DataTextField="teamFull" DataValueField="teamID"></asp:DropDownList>
                            <asp:SqlDataSource ID="dsTeams" runat="server" ConnectionString="<%$ ConnectionStrings:JerseySure %>" SelectCommand="usp_getTeams" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        </asp:TableCell>
                        <asp:TableCell runat="server"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Jersey Number</asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxJerNumber" runat="server" CssClass="form-control"></asp:TextBox></asp:TableCell>
                        <asp:TableCell runat="server"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" VerticalAlign="Top">Product Description</asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" MaxLength="0" Columns="100"></asp:TextBox></asp:TableCell>
                        <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvDescription" runat="server" ErrorMessage="Required" CssClass="text-danger" Display="Dynamic" ControlToValidate="tbxDescription"></asp:RequiredFieldValidator></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Front Image</asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxImgFront" runat="server" CssClass="form-control"></asp:TextBox></asp:TableCell>
                        <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvImage1" runat="server" ErrorMessage="Required" CssClass="text-danger" Display="Dynamic" ControlToValidate="tbxImgFront"></asp:RequiredFieldValidator></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Back Image</asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxImgBack" runat="server" CssClass="form-control"></asp:TextBox></asp:TableCell>
                        <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvImage2" runat="server" ErrorMessage="Required" CssClass="text-danger" Display="Dynamic" ControlToValidate="tbxImgBack"></asp:RequiredFieldValidator></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server"></asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxPrice" runat="server" CssClass="form-control"></asp:TextBox></asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ErrorMessage="Required" CssClass="text-danger" Display="Dynamic" ControlToValidate="tbxPrice"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rxvPrice" runat="server" ErrorMessage="Enter a money value" CssClass="text-danger" Display="Dynamic" ControlToValidate="tbxPrice" ValidationExpression="\d+(\.\d{2})?"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>

                <div class="form-group">
                    <asp:Button ID="AddProductButton" runat="server" Text="Add Product" CssClass="btn btn-danger" OnClick="AddProductButton_Click" />
                </div>
            </div>
            <div class="col"></div>
        </div>
    </div>
</asp:Content>
