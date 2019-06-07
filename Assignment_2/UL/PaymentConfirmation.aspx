<%@ Page Title="Payment Confirmation" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="PaymentConfirmation.aspx.cs" Inherits="Assignment_2.UL.PaymentConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row margin-space-top-20">
            <div class="col">
                <h2><%: Title %></h2>
                <hr />
                <p class="margin-spacing-bottom">
                    Thank you for your purchase, a digital receipt has been sent to your email. 
                    We hope you chose to shop again with us in the future!
                </p>
                <asp:Button ID="ReturnButton" runat="server" Text="Return Home" CssClass="btn btn-danger" PostBackUrl="~/UL/Default.aspx" />
            </div>
        </div>
    </div>
</asp:Content>
