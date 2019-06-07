<%@ Page Title="Contact" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Assignment_2.UL.Contact" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
<br />
<h1>Contact Us</h1>
    <hr/>
    <%-- Table for Contact Details section --%>
    <asp:Panel ID="ContactPanel" runat="server" DefaultButton="btnSubmit">
        <asp:Table ID="tblDetails" runat="server">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Your name<%--<asp:Label ID="lblName" runat="server" Text="Your name" AssociatedControlID="tbxName"></asp:Label>--%></asp:TableCell>
                <asp:TableCell runat="server"><asp:TextBox ID="tbxName" CssClass="form-control" runat="server"></asp:TextBox></asp:TableCell>
            
                <%-- Validation for name --%>
                <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxName" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Email address<%--<asp:Label ID="lblEmail" runat="server" Text="Email address" AssociatedControlID="tbxEmail"></asp:Label>--%></asp:TableCell>
                <asp:TableCell runat="server"><asp:TextBox ID="tbxEmail" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox></asp:TableCell>
            
                <%-- Validation for email --%>
                <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxEmail" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" Height="10">
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" VerticalAlign="Top">Your query<%--<asp:Label ID="lblQuery" runat="server" Text="Your query" AssociatedControlID="tbxQuery"></asp:Label>--%></asp:TableCell>
                <asp:TableCell runat="server"><asp:TextBox ID="tbxQuery" CssClass="form-control" TextMode="MultiLine" Columns="100" Rows="5" runat="server"></asp:TextBox></asp:TableCell>
            
                <%-- Validation for query --%>
                <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvQuery" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxQuery" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ColumnSpan="2" runat="server"><hr/></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-danger"/></asp:TableCell>            
            </asp:TableRow>
        </asp:Table> 
    </asp:Panel>
</asp:Content>