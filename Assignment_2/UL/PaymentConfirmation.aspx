<%@ Page Title="Payment Confirmation" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="PaymentConfirmation.aspx.cs" Inherits="Assignment_2.PaymentConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col">
                <h2><%: Title %></h2>
                <p>
                    Thank you for your purchase, a digital receipt has been sent to your email. 
                    We hope you chose to shop again with us in the future!
                </p>
                <asp:HyperLink ID="ReturnHome" runat="server" NavigateUrl="~/UL/Default.aspx">Return to Home Page</asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>
