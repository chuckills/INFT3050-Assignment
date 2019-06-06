<%@ Page Title="Item Management" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminItemManagement.aspx.cs" Inherits="Assignment_2.UL.AdminManage" %>

<%-- This page will be functionally redesigned once database functions are supported --%>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
         <h2>Product Management</h2>
         <hr/>

         <asp:GridView ID="gvProducts" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnSelectedIndexChanged="gvProducts_SelectedIndexChanged" OnRowDataBound="gvProducts_RowDataBound">
             <Columns>  
                 <asp:BoundField DataField="prodNumber" HeaderText="ID" ReadOnly="True" />  
                 <asp:BoundField DataField="prodDescription" HeaderText="Description" ReadOnly="True" />  
                 <asp:BoundField DataField="prodPrice" HeaderText="Price" ReadOnly="True" />  
                 <asp:BoundField DataField="teamID" HeaderText="Team ID" ReadOnly="True" HeaderStyle-Wrap="False" /> 
                 <asp:BoundField DataField="teamLocale" HeaderText="Team Locale" ReadOnly="True" HeaderStyle-Wrap="False" />  
                 <asp:BoundField DataField="teamName" HeaderText="Team Name" ReadOnly="True" HeaderStyle-Wrap="False" />  
                 <asp:BoundField DataField="playFirstName" HeaderText="Player FName" ReadOnly="True" HeaderStyle-Wrap="False" />  
                 <asp:BoundField DataField="playLastName" HeaderText="Player LName" ReadOnly="True" HeaderStyle-Wrap="False" /> 
                 <asp:BoundField DataField="jerNumber" HeaderText="Number" ReadOnly="True" /> 
                 <asp:BoundField DataField="imgFront" HeaderText="imgFront" ReadOnly="True" />  
                 <asp:BoundField DataField="imgBack" HeaderText="imgBack" ReadOnly="True" />
                 <asp:BoundField DataField="prodActive" HeaderText="Active" ReadOnly="True" />
                 <asp:CommandField ShowSelectButton="True" ButtonType="Button"> 
                    <ControlStyle CssClass="btn btn-outline-danger"></ControlStyle>
                 </asp:CommandField>
                 <asp:TemplateField ItemStyle-Wrap="False" HeaderText="Stock">
                     <ItemTemplate>
                         <asp:label id="lblLowStock" CssClass="text-danger" Visible="False" runat="server"/> 
                     </ItemTemplate>
                     <ItemStyle Wrap="False"></ItemStyle>
                 </asp:TemplateField>
             </Columns>
             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
         </asp:GridView>
    </div>
</asp:Content>
