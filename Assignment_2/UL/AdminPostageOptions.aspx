<%@ Page Title="Edit Postage Options" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminPostageOptions.aspx.cs" Inherits="Assignment_2.AdminPostageOptions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        
<br />
<h1>Add Postage Option</h1>
    
    <asp:ListView ID="lsvPostage" runat="server" ItemType="System.String"
                  SelectMethod="GetPostageOptions">
        <EmptyDataTemplate>
            <li class="list-group-item">No postage options defined...</li>
        </EmptyDataTemplate>
        <ItemTemplate>
            <li class="list-group-item">
                <div class="row">
                    <div class="col-6">
                        <%#:Item %> 
                    </div>
                    <div class="col">
                        <asp:CheckBox ID="cbxRemove" runat="server" Text="&nbsp;Remove" AutoPostBack="False" />
                    </div>
                </div>
            </li>
        </ItemTemplate>
    </asp:ListView>
    <div class="margin-space-bottom-50">
        <asp:LinkButton ID="btnRemove" runat="server" CssClass="btn btn-danger" OnClick="btnRemove_Click" CausesValidation="False">Remove Selected</asp:LinkButton>
    </div>
<%--Table for Postage options--%>
    <asp:Table ID="tblOptions" runat="server">
        <asp:TableHeaderRow runat="server">
            <asp:TableHeaderCell runat="server">New postage method</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblMethodName" runat="server" Text="Postage method name" AssociatedControlID="tbxMethodName"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbxMethodName" runat="server"></asp:TextBox></asp:TableCell>
            <%--Validation--%>
            <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvMethodName" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxMethodName" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblDescription" runat="server" Text="Description" AssociatedControlID="tbxDescription"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbxDescription" runat="server"></asp:TextBox></asp:TableCell>
            <%--Validation--%>
            <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvDescription" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxDescription" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblAvgTime" runat="server" Text="Average delivery time" AssociatedControlID="tbxAvgTime"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbxAvgTime" runat="server" TextMode="Number"></asp:TextBox></asp:TableCell>
            <%--Validation--%>
            <asp:TableCell runat="server">
            <asp:RequiredFieldValidator ID="rfvAvgTime" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxAvgTime" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" ErrorMessage="Must be a whole number" ID="rxvAvgTime" ValidationExpression="\d{1,2}" CssClass="text-danger" ControlToValidate="tbxAvgTime" Display="Dynamic"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label ID="lblPrice" runat="server" Text="Postage price" AssociatedControlID="tbxPrice"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="tbxPrice" runat="server" TextMode="SingleLine"></asp:TextBox></asp:TableCell>
            <%--Validation--%>
            <asp:TableCell runat="server"><asp:RequiredFieldValidator ID="rfvPrice" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxPrice" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" ErrorMessage="Must be a valid currency value" ID="rxvPrice" ValidationExpression="^(\d{1,3})(\.\d{2})?" CssClass="text-danger" ControlToValidate="tbxPrice"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" Height="10">
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-danger"/></asp:TableCell>
            <asp:TableCell runat="server"></asp:TableCell>
        </asp:TableRow>
    </asp:Table> 
    
   

</asp:Content>
