﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="PurchaseHistory.aspx.cs" Inherits="Assignment_2.UL.PurchaseHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <br />
    <h1>Your Purchase History</h1>
    <hr />

    <asp:GridView ID="gvOrders" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnSelectedIndexChanged="gvOrders_SelectedIndexChanged" CssClass="table">
        <Columns>  
            <asp:BoundField DataField="ordID" HeaderText="Order ID" ReadOnly="True" />  
            <asp:BoundField DataField="ordDate" HeaderText="Date Ordered" ReadOnly="True" DataFormatString="{0:d}" />  
            <asp:BoundField DataField="ordSubTotal" HeaderText="Subtotal" ReadOnly="True" DataFormatString="{0:C}" />  
            <asp:BoundField DataField="ordTotal" HeaderText="Total" ReadOnly="True" DataFormatString="{0:C}" />  
            <asp:BoundField DataField="ordGST" HeaderText="GST" ReadOnly="True" DataFormatString="{0:C}" /> 
            <asp:BoundField DataField="ordPaid" HeaderText="Paid" ReadOnly="True" />
            <asp:CommandField ShowSelectButton="True" ButtonType="Button"> 
                <ControlStyle CssClass="btn btn-outline-danger"></ControlStyle>
            </asp:CommandField>
        </Columns>
        <HeaderStyle HorizontalAlign="Center" CssClass="thead-dark" />
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>

</asp:Content>
