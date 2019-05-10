<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="Assignment_1.Payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
<br />
<h1>Payment</h1>

    <%-- Table for Card Details --%>

    <asp:Table ID="tblDetails" runat="server">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblCardNumber" runat="server" Text="Credit card number" AssociatedControlID="tbxCardNumber"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbxCardNumber" runat="server" TextMode="Number"></asp:TextBox></asp:TableCell>
            
            <%-- Validation for card number --%>
            <asp:TableCell runat="server">
                <asp:RequiredFieldValidator ID="rfvNumber" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxCardNumber" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rxvNumber" runat="server" ErrorMessage="Invalid CC Number" CssClass="text-danger" Display="Dynamic" ControlToValidate="tbxCardNumber" ValidationExpression="\d{16}"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblCardName" runat="server" Text="Name on credit card" AssociatedControlID="tbxCardName"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbxCardName" runat="server"></asp:TextBox></asp:TableCell>
            
            <%-- Validation for name --%>
            <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxCardName" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblExpiration" runat="server" Text="Expiration date MMYY" AssociatedControlID="tbxExpiration"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbxExpiration" runat="server" Width="50" TextMode="Number"></asp:TextBox></asp:TableCell>
            
            <%-- Validation for expiration date --%>
            <asp:TableCell runat="server">
                <asp:RequiredFieldValidator ID="rfvExpiration" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxExpiration" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rxvExpiration" runat="server" ErrorMessage="Invalid Expiry" CssClass="text-danger" Display="Dynamic" ControlToValidate="tbxExpiration" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblCSC" runat="server" Text="Card security code" AssociatedControlID="tbxCSC"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbxCSC" runat="server" Width="50" TextMode="Number"></asp:TextBox></asp:TableCell>
           
            <%-- Validation for CSC --%>
            <asp:TableCell runat="server">
                <asp:RequiredFieldValidator ID="rfvCSC" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxCSC" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rxvCSC" runat="server" ErrorMessage="Invalid CSC" CssClass="text-danger" Display="Dynamic" ControlToValidate="tbxCSC" ValidationExpression="\d{3}"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-danger"/></asp:TableCell>
            <asp:TableCell runat="server"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>  
       
</asp:Content>