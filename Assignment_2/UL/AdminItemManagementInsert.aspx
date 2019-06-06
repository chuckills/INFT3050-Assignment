<%@ Page Title="Insert Product" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminItemManagementInsert.aspx.cs" Inherits="Assignment_2.UL.AdminItemManagementInsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<%-- Page to add a new product --%>
    <div class="container">
        <div class="row">
            <div class="col">
                <h2>New Product</h2>
                <hr/>
                <asp:Table ID="tblProduct" runat="server">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">First Name</asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxFirstName" runat="server" CssClass="form-control"></asp:TextBox></asp:TableCell>
                        <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="Required" CssClass="text-danger" Display="Dynamic" ControlToValidate="tbxFirstName"></asp:RequiredFieldValidator></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Last Name</asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxLastName" runat="server" CssClass="form-control"></asp:TextBox></asp:TableCell>
                        <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvLastName" runat="server" ErrorMessage="Required" CssClass="text-danger" Display="Dynamic" ControlToValidate="tbxLastName"></asp:RequiredFieldValidator></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Team</asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:DropDownList ID="ddlTeam" CssClass="form-control" runat="server" DataTextField="teamFull" DataValueField="teamID" OnDataBound="addDefaultItem"></asp:DropDownList>
                        </asp:TableCell>
                        <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvTeam" runat="server" ErrorMessage="Required" CssClass="text-danger" Display="Dynamic" ControlToValidate="ddlTeam" InitialValue=""></asp:RequiredFieldValidator></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Jersey Number</asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxJerNumber" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox></asp:TableCell>
                        <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvNumber" runat="server" ErrorMessage="Required" CssClass="text-danger" Display="Dynamic" ControlToValidate="tbxJerNumber"></asp:RequiredFieldValidator></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" VerticalAlign="Top">Product Description</asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" MaxLength="0" Columns="100"></asp:TextBox></asp:TableCell>
                        <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvDescription" runat="server" ErrorMessage="Required" CssClass="text-danger" Display="Dynamic" ControlToValidate="tbxDescription"></asp:RequiredFieldValidator></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Price</asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxPrice" runat="server" CssClass="form-control"></asp:TextBox></asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ErrorMessage="Required" CssClass="text-danger" Display="Dynamic" ControlToValidate="tbxPrice"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rxvPrice" runat="server" ErrorMessage="Enter a money value" CssClass="text-danger" Display="Dynamic" ControlToValidate="tbxPrice" ValidationExpression="\d+(\.\d{2})?"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>    
                
                <asp:Table ID="tblStock" runat="server">
                    <asp:TableRow runat="server"><asp:TableCell runat="server"><br/></asp:TableCell></asp:TableRow>
                    <asp:TableRow runat="server"><asp:TableCell runat="server">Stock</asp:TableCell></asp:TableRow>
                    <asp:TableRow CssClass="text-center" runat="server">
                        <asp:TableCell runat="server">S</asp:TableCell>
                        <asp:TableCell runat="server">M</asp:TableCell>
                        <asp:TableCell runat="server">L</asp:TableCell>
                        <asp:TableCell runat="server">XL</asp:TableCell>
                        <asp:TableCell runat="server">XXL</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxSmall" runat="server" Width="40" CssClass="form-control"></asp:TextBox></asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxMedium" runat="server" Width="40" CssClass="form-control"></asp:TextBox></asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxLarge" runat="server" Width="40" CssClass="form-control"></asp:TextBox></asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxXLge" runat="server" Width="40" CssClass="form-control"></asp:TextBox></asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxXXL" runat="server" Width="40" CssClass="form-control"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                
                <asp:Table ID="tblStockVal" runat="server">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">
                            <asp:RegularExpressionValidator runat="server" ID="rxvSmall" ErrorMessage="S quantity invalid " CssClass="text-danger" SetFocusOnError="True" Display="Dynamic" ControlToValidate="tbxSmall" ValidationExpression="\{d}*"></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator runat="server" ID="rxvMedium" ErrorMessage="M quantity invalid " CssClass="text-danger" SetFocusOnError="True" Display="Dynamic" ControlToValidate="tbxMedium" ValidationExpression="\{d}*"></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator runat="server" ID="rxvLarge" ErrorMessage="L quantity invalid " CssClass="text-danger" SetFocusOnError="True" Display="Dynamic" ControlToValidate="tbxLarge" ValidationExpression="\{d}*"></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator runat="server" ID="rxvXLge" ErrorMessage="XL quantity invalid " CssClass="text-danger" SetFocusOnError="True" Display="Dynamic" ControlToValidate="tbxXLge" ValidationExpression="\{d}*"></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator runat="server" ID="rxvXXL" ErrorMessage="XXL quantity invalid " CssClass="text-danger" SetFocusOnError="True" Display="Dynamic" ControlToValidate="tbxXXL" ValidationExpression="\{d}*"></asp:RegularExpressionValidator>
                                
                            <br/>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>

                <asp:Table ID="tblImage" runat="server">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Front Image</asp:TableCell>
                        <asp:TableCell runat="server"><asp:FileUpload ID="fuImgFront" CssClass="form-control-file" runat="server"></asp:FileUpload></asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:RequiredFieldValidator ID="rfvImage1" runat="server" ErrorMessage="Required" CssClass="text-danger" Display="Dynamic" ControlToValidate="fuImgFront"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="csvImage1" runat="server" ErrorMessage="Must be a jpg or png file" CssClass="text-danger" OnServerValidate="checkValidImage" ControlToValidate="fuImgFront" Display="Dynamic" SetFocusOnError="True"></asp:CustomValidator>
                            <asp:CustomValidator ID="csvExist1" runat="server" ErrorMessage="Image name exists on server" CssClass="text-danger" OnServerValidate="fileExists" ControlToValidate="fuImgFront" Display="Dynamic" SetFocusOnError="True"></asp:CustomValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Back Image</asp:TableCell>
                        <asp:TableCell runat="server"><asp:FileUpload ID="fuImgBack" CssClass="form-control-file" runat="server"></asp:FileUpload></asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:RequiredFieldValidator ID="rfvImage2" runat="server" ErrorMessage="Required" CssClass="text-danger" Display="Dynamic" ControlToValidate="fuImgBack"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="csvImage2" runat="server" ErrorMessage="Must be a jpg or png file" CssClass="text-danger" OnServerValidate="checkValidImage" ControlToValidate="fuImgBack" Display="Dynamic" SetFocusOnError="True"></asp:CustomValidator>
                            <asp:CustomValidator ID="csvExist2" runat="server" ErrorMessage="Image name exists on server" CssClass="text-danger" OnServerValidate="fileExists" ControlToValidate="fuImgBack" Display="Dynamic" SetFocusOnError="True"></asp:CustomValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server"><asp:TableCell runat="server"><br/></asp:TableCell></asp:TableRow>
                </asp:Table>

                <div class="form-group">
                    <asp:Button ID="AddProductButton" runat="server" Text="Add Product" CssClass="btn btn-danger" OnClick="AddProductButton_Click" />
                </div>
            </div>
            <div class="col"></div>
        </div>
    </div>
</asp:Content>
