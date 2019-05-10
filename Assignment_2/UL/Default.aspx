<%@ Page Title="Home" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment_2.UL.Main" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <%-- Change background colour for mainpage only --%>
    <script>
        $('body').css('background', 'black');
    </script>
    
    <%-- Hero image of mainpage --%>
    <div>
        <img alt="" src="Images/wade-back.jpg" class="d-block w-100" id="hero-img"/>
    </div>

</asp:Content>