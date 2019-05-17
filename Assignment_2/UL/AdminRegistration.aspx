<%@ Page Title="Admin Registration" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminRegistration.aspx.cs" Inherits="Assignment_2.UL.AdminRegistration" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
<br />
<h1>New Admin Registration</h1>
    
<%-- Table for User Details section --%>

    <asp:Table ID="tblDetails" runat="server">
        <asp:TableHeaderRow runat="server">
            <asp:TableHeaderCell runat="server">Your Details</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblFirstName" runat="server" Text="First name" AssociatedControlID="tbxFirstName"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbxFirstName" runat="server"></asp:TextBox></asp:TableCell>
            
            <%-- Validation for first name --%>
            <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxFirstName" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblLastName" runat="server" Text="Last name" AssociatedControlID="tbxLastName"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbxLastName" runat="server"></asp:TextBox></asp:TableCell>
            
            <%-- Validation for last name --%>
            <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvLastName" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxLastName" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblPhone" runat="server" Text="Phone number" AssociatedControlID="tbxPhone"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbxPhone" runat="server" TextMode="Phone"></asp:TextBox></asp:TableCell>
            
            <%-- Validation for phone --%>
            <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvPhone" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxPhone" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" Height="10">
        </asp:TableRow>
    </asp:Table>  

<%-- Table for billing address section --%>   

    <asp:Table ID="tblAddress" runat="server">
        <asp:TableHeaderRow runat="server">
            <asp:TableHeaderCell runat="server">Address</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblAddress" runat="server" Text="Address Line" AssociatedControlID="tbxAddress"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbxAddress" runat="server"></asp:TextBox></asp:TableCell>
            
            <%-- Validation for address line --%>
            <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxAddress" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblSuburb" runat="server" Text="Suburb" AssociatedControlID="tbxSuburb"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbxSuburb" runat="server"></asp:TextBox></asp:TableCell>
           
            <%-- Validation for suburb --%>
            <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvSuburb" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxSuburb" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblState" runat="server" Text="State / Territory" AssociatedControlID="ddlBillState"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server">
                <asp:DropDownList ID="ddlBillState" runat="server">
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
            
            <%-- Validation for state --%>
            <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="Required" CssClass="text-danger" InitialValue="None" ControlToValidate="ddlBillState" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblBillPostCode" runat="server" Text="Post Code" AssociatedControlID="tbxBillPostCode"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbxBillPostCode" runat="server" TextMode="Number"></asp:TextBox></asp:TableCell>
            
            <%-- Validation for postcode --%>
            <asp:TableCell runat="server">
                <asp:RequiredFieldValidator ID="rfvPostCode" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxBillPostCode" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rxvBillPostcode" runat="server" ErrorMessage="Postcode must be 4 digits" CssClass="text-danger" Display="Dynamic" ValidationExpression="\d{4}" ControlToValidate="tbxBillPostcode"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" Height="10">
        </asp:TableRow>
    </asp:Table>

<%-- Table for login details section --%>

    <asp:Table ID="tblLogin" runat="server">
        <asp:TableHeaderRow runat="server">
            <asp:TableHeaderCell runat="server">Login details</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblUsername" runat="server" Text="Username" AssociatedControlID="tbxUsername"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbxUsername" runat="server"></asp:TextBox></asp:TableCell>
            
            <%-- Validation for username --%>
            <asp:TableCell runat="server">@jerseysure.com.au<asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxUsername" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblPassword" runat="server" Text="Password" AssociatedControlID="tbxPassword"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbxPassword" runat="server" TextMode="Password"></asp:TextBox></asp:TableCell>
            
            <%-- Validation for password --%>
            <asp:TableCell runat="server">
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxPassword" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rxvPassword" runat="server" ErrorMessage="Password must be 6 or more alphanumeric characters" ControlToValidate="tbxPassword" CssClass="text-danger" Display="Dynamic" ValidationExpression="^([a-zA-Z0-9]{6,255})$"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblPassword2" runat="server" Text="Confirm Password" AssociatedControlID="tbxPassword2"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbxPassword2" runat="server" TextMode="Password"></asp:TextBox></asp:TableCell>
            
            <%-- Validation for password2 --%>
            <asp:TableCell runat="server">
                <asp:CompareValidator ID="cpvPassword2" runat="server" ErrorMessage="Passwords do not match" CssClass="text-danger" ControlToValidate="tbxPassword2" ControlToCompare="tbxPassword" SetFocusOnError="True" Operator="Equal" Display="Dynamic"></asp:CompareValidator>
                <asp:RequiredFieldValidator ID="rfvPassword2" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxPassword2" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-danger"/></asp:TableCell>
            <asp:TableCell runat="server"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>