﻿<%@ Page Title="Modify User Account" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AccountSettings.aspx.cs" Inherits="Assignment_2.UL.AccountSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
<br />
<h1>Account Settings</h1>
    
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
            <asp:TableCell runat="server"><asp:Label ID="lblEmail" runat="server" Text="Email address" AssociatedControlID="tbxEmail"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbxEmail" runat="server" TextMode="Email"></asp:TextBox></asp:TableCell>
            
            <%-- Validation for email --%>
            <asp:TableCell runat="server">
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxEmail" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="csvEmail" runat="server" ErrorMessage="Email already registered" CssClass="text-danger" OnServerValidate="checkExists" ControlToValidate="tbxEmail" Display="Dynamic" SetFocusOnError="True"></asp:CustomValidator>
            </asp:TableCell>
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

    <asp:Table ID="tblBill" runat="server">
        <asp:TableHeaderRow runat="server">
            <asp:TableHeaderCell runat="server">Billing address</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblBillAddress" runat="server" Text="Address Line" AssociatedControlID="tbxBillAddress"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbxBillAddress" runat="server"></asp:TextBox></asp:TableCell>
            
            <%-- Validation for billing address line --%>
            <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvBillAddress" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxBillAddress" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblBillSuburb" runat="server" Text="Suburb" AssociatedControlID="tbxBillSuburb"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbxBillSuburb" runat="server"></asp:TextBox></asp:TableCell>
            
            <%-- Validation for billing suburb --%>
            <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvBillSuburb" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxBillSuburb" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblBillState" runat="server" Text="State / Territory" AssociatedControlID="ddlBillState"></asp:Label></asp:TableCell>
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
            
            <%-- Validation for billing state --%>
            <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvBillState" runat="server" ErrorMessage="Required" CssClass="text-danger" InitialValue="None" ControlToValidate="ddlBillState" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblBillPostCode" runat="server" Text="Post Code" AssociatedControlID="tbxBillPostCode"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbxBillPostCode" runat="server" TextMode="Number"></asp:TextBox></asp:TableCell>
           
            <%-- Validation for billing postcode --%>
            <asp:TableCell runat="server">
                <asp:RequiredFieldValidator ID="rfvBillPostCode" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxBillPostCode" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rxvBillPostcode" runat="server" ErrorMessage="Postcode must be 4 digits" CssClass="text-danger" Display="Dynamic" ValidationExpression="\d{4}" ControlToValidate="tbxBillPostcode"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell ColumnSpan="2"><asp:CheckBox ID="cbxPostageSame" Text="&nbsp;Postage address the same as the billing address" runat="server" AutoPostBack="True" OnCheckedChanged="cbxPostageSame_CheckedChanged" Checked="True" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" Height="10">
        </asp:TableRow>
    </asp:Table> 

<%-- Table for postal address section --%>

    <asp:Table ID="tblPost" runat="server" Visible="False">
        <asp:TableHeaderRow runat="server">
            <asp:TableHeaderCell runat="server">Postage address</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblPostAddress" runat="server" Text="Address Line" AssociatedControlID="tbxPostAddress"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbxPostAddress" runat="server"></asp:TextBox></asp:TableCell>
            
            <%-- Validation for postal address line --%>
            <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvPostAddress" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxPostAddress" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblPostSuburb" runat="server" Text="Suburb" AssociatedControlID="tbxPostSuburb"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbxPostSuburb" runat="server"></asp:TextBox></asp:TableCell>
            
            <%-- Validation for postal suburb --%>
            <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvPostSuburb" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxPostSuburb" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblPostState" runat="server" Text="State / Territory" AssociatedControlID="ddlPostState"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server">
                <asp:DropDownList ID="ddlPostState" runat="server">
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
           
            <%-- Validation for postal state --%>
            <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvPostState" runat="server" ErrorMessage="Required" CssClass="text-danger" InitialValue="None" ControlToValidate="ddlPostState" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblPostPostCode" runat="server" Text="Post Code" AssociatedControlID="tbxPostPostCode"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbxPostPostCode" runat="server" TextMode="Number"></asp:TextBox></asp:TableCell>
            
            <%-- Validation for postal postcode --%>
            <asp:TableCell runat="server">
                <asp:RequiredFieldValidator ID="rfvPostPostCode" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxPostPostCode" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rxvPostPostcode" runat="server" ErrorMessage="Postcode must be 4 digits" CssClass="text-danger" Display="Dynamic" ValidationExpression="\d{4}" ControlToValidate="tbxBillPostcode"></asp:RegularExpressionValidator>
           </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table ID="tblButtons" runat="server">
        <asp:TableRow runat="server">
            <asp:TableCell ColumnSpan="2" runat="server">
                <br/>
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-danger" OnClick="btnUpdate_Click" />&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" CausesValidation="False" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>