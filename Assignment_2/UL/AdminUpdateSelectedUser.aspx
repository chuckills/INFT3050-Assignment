<%@ Page Title="Update User" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminUpdateSelectedUser.aspx.cs" Inherits="Assignment_2.UL.AdminUpdateSelectedUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <%-- Page to update a User details --%>
    <div class="container">
        <div class="row">
            <div class="col">
                <h2>Edit User - Update Information</h2>
                <hr/>
                
            <%--Table for User Details--%>
                <asp:Table ID="tblDetails" runat="server">
                    <asp:TableHeaderRow runat="server">
                        <asp:TableHeaderCell runat="server">Your Details</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">User ID</asp:TableCell>
                        <asp:TableCell runat="server"><asp:Label ID="lblUserID" runat="server" Text="Label"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">First name</asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxFirstName" runat="server" CssClass="form-control"></asp:TextBox></asp:TableCell>
                        <%--Validation--%>
                        <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxFirstName" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Last name</asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxLastName" runat="server" CssClass="form-control"></asp:TextBox></asp:TableCell>
                        <%--Validation--%>
                        <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvLastName" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxLastName" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Email address</asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox></asp:TableCell>
                        <%--Validation--%>
                        <asp:TableCell runat="server">
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxEmail" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="csvEmail" runat="server" ErrorMessage="Email already registered" CssClass="text-danger" OnServerValidate="checkExists" ControlToValidate="tbxEmail" Display="Dynamic" SetFocusOnError="True"></asp:CustomValidator>
                        </asp:TableCell></asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Confirm email address</asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxEmail2" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox></asp:TableCell>
                        <%--Validation--%>
                        <asp:TableCell runat="server">
                            <asp:CompareValidator ID="cpvEmail2" runat="server" ErrorMessage="Emails do not match" CssClass="text-danger" ControlToCompare="tbxEmail" ControlToValidate="tbxEmail2" Operator="Equal" SetFocusOnError="True" Display="Dynamic"></asp:CompareValidator>
                            <asp:RequiredFieldValidator ID="rfvEmail2" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxEmail2" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Phone number</asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxPhone" runat="server" CssClass="form-control"></asp:TextBox></asp:TableCell>
                        <%--Validation--%>
                        <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvPhone" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxPhone" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server" Height="10">
                    </asp:TableRow>
                </asp:Table>  

            <%--Table for billing address--%>    
                <asp:Table ID="tblBill" runat="server">
                    <asp:TableHeaderRow runat="server">
                        <asp:TableHeaderCell runat="server">Billing address</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Address Line</asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxBillAddress" CssClass="form-control" runat="server"></asp:TextBox></asp:TableCell>
                        <%--Validation--%>
                        <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvBillAddress" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxBillAddress" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Suburb</asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxBillSuburb" CssClass="form-control" runat="server"></asp:TextBox></asp:TableCell>
                        <%--Validation--%>
                        <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvBillSuburb" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxBillSuburb" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">State / Territory</asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:DropDownList ID="ddlBillState" CssClass="form-control" runat="server">
                                <asp:ListItem Enabled="true" Text="Select State" Value="None"></asp:ListItem>
                                <asp:ListItem Text="ACT" Value="ACT"></asp:ListItem>
                                <asp:ListItem Text="NSW" Value="NSW"></asp:ListItem>
                                <asp:ListItem Text="VIC" Value="VIC"></asp:ListItem>
                                <asp:ListItem Text="QLD" Value="QLD"></asp:ListItem>
                                <asp:ListItem Text="WA" Value="WA"></asp:ListItem>
                                <asp:ListItem Text="SA" Value="SA"></asp:ListItem>
                                <asp:ListItem Text="TAS" Value="TAS"></asp:ListItem>
                                <asp:ListItem Text="NT" Value="NT"></asp:ListItem>
                            </asp:DropDownList>
                        </asp:TableCell>
                        <%--Validation--%>
                        <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvBillState" runat="server" ErrorMessage="Required" CssClass="text-danger" InitialValue="None" ControlToValidate="ddlBillState" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Post Code</asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxBillPostCode" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox></asp:TableCell>
                        <%--Validation--%>
                        <asp:TableCell runat="server">
                            <asp:RequiredFieldValidator ID="rfvBillPostCode" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxBillPostCode" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rxvBillPostcode" runat="server" ErrorMessage="Postcode must be 4 digits" CssClass="text-danger" Display="Dynamic" ValidationExpression="\d{4}" ControlToValidate="tbxBillPostcode"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server" Height="10">
                    </asp:TableRow>
                </asp:Table> 

            <%--Table for postal address--%>
                <asp:Table ID="tblPost" runat="server">
                    <asp:TableHeaderRow runat="server">
                        <asp:TableHeaderCell runat="server">Postage address</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Address Line</asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxPostAddress" CssClass="form-control" runat="server"></asp:TextBox></asp:TableCell>
                        <%--Validation--%>
                        <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvPostAddress" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxPostAddress" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Suburb</asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxPostSuburb" CssClass="form-control" runat="server"></asp:TextBox></asp:TableCell>
                        <%--Validation--%>
                        <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvPostSuburb" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxPostSuburb" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">State / Territory</asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:DropDownList ID="ddlPostState" CssClass="form-control" runat="server">
                                <asp:ListItem Enabled="true" Text="Select State" Value="None"></asp:ListItem>
                                <asp:ListItem Text="ACT" Value="ACT"></asp:ListItem>
                                <asp:ListItem Text="NSW" Value="NSW"></asp:ListItem>
                                <asp:ListItem Text="VIC" Value="VIC"></asp:ListItem>
                                <asp:ListItem Text="QLD" Value="QLD"></asp:ListItem>
                                <asp:ListItem Text="WA" Value="WA"></asp:ListItem>
                                <asp:ListItem Text="SA" Value="SA"></asp:ListItem>
                                <asp:ListItem Text="TAS" Value="TAS"></asp:ListItem>
                                <asp:ListItem Text="NT" Value="NT"></asp:ListItem>
                            </asp:DropDownList>
                        </asp:TableCell>
                        <%--Validation--%>
                        <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvPostState" runat="server" ErrorMessage="Required" CssClass="text-danger" InitialValue="None" ControlToValidate="ddlPostState" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Post Code</asp:TableCell>
                        <asp:TableCell runat="server"><asp:TextBox ID="tbxPostPostCode" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox></asp:TableCell>
                        <%--Validation--%>
                        <asp:TableCell runat="server">
                            <asp:RequiredFieldValidator ID="rfvPostPostCode" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxPostPostCode" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rxvPostPostcode" runat="server" ErrorMessage="Postcode must be 4 digits" CssClass="text-danger" Display="Dynamic" ValidationExpression="\d{4}" ControlToValidate="tbxBillPostcode"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server" Height="10">
                    </asp:TableRow>
                </asp:Table> 

            <%--Table for login details--%>
                <asp:Table ID="tblLogin" runat="server">
                    <asp:TableHeaderRow runat="server">
                        <asp:TableHeaderCell runat="server">Login details</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Active&nbsp;<asp:CheckBox ID="cbxActive" runat="server" /></asp:TableCell>
                        <asp:TableCell runat="server"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server"><asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-danger" OnClick="btnUpdate_Click" /></asp:TableCell>
                        <asp:TableCell runat="server"><asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" /></asp:TableCell>
                    </asp:TableRow>
                </asp:Table> 

            </div>
            <div class="col"></div>
        </div>
    </div>
</asp:Content>
