<%@ Page Title="Item Management" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminItemManagement.aspx.cs" Inherits="Assignment_2.UL.AdminManage" %>

<%-- This page will be functionally redesigned once database functions are supported --%>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
         <h2>Product Management</h2>

         <asp:GridView ID="gvProducts" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnSelectedIndexChanged="gvProducts_SelectedIndexChanged">
             <Columns>  
                 <asp:BoundField DataField="prodNumber" HeaderText="ID" ReadOnly="True" />  
                 <asp:BoundField DataField="prodDescription" HeaderText="Description" ReadOnly="True" />  
                 <asp:BoundField DataField="prodPrice" HeaderText="Price" ReadOnly="True" />  
                 <asp:BoundField DataField="teamID" HeaderText="Team ID" ReadOnly="True" /> 
                 <asp:BoundField DataField="teamLocale" HeaderText="Team Locale" ReadOnly="True" />  
                 <asp:BoundField DataField="teamName" HeaderText="Team Name" ReadOnly="True" />  
                 <asp:BoundField DataField="playFirstName" HeaderText="Player FName" ReadOnly="True" />  
                 <asp:BoundField DataField="playLastName" HeaderText="Player LName" ReadOnly="True" /> 
                 <asp:BoundField DataField="jerNumber" HeaderText="Number" ReadOnly="True" /> 
                 <asp:BoundField DataField="imgFront" HeaderText="imgFront" ReadOnly="True" />  
                 <asp:BoundField DataField="imgBack" HeaderText="imgBack" ReadOnly="True" />  
                 <asp:CommandField ShowSelectButton="True" />  
             </Columns>
         </asp:GridView>
    </div>
</asp:Content>
