﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="Assignment_2.UL.Payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


<br />
<h1>Payment</h1>
    <hr/>
    
    <%-- Table for Order Details --%>
    <asp:Panel ID="PaymentPanel" runat="server" DefaultButton="btnSubmit">
        <asp:Table ID="tblOrderDetails" runat="server">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:Label ID="lblFirst" runat="server"></asp:Label>&nbsp;<asp:Label ID="lblLast" runat="server"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" VerticalAlign="Top">Bill to:</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:Label ID="lblBillStreet" runat="server"></asp:Label><br/>
                    <asp:Label ID="lblBillSuburb" runat="server"></asp:Label>&nbsp;
                    <asp:Label ID="lblBillState" runat="server"></asp:Label>&nbsp;
                    <asp:Label ID="lblBillZip" runat="server"></asp:Label><br/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" VerticalAlign="Top">Post to:</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:Label ID="lblPostStreet" runat="server"></asp:Label><br/>
                    <asp:Label ID="lblPostSuburb" runat="server"></asp:Label>&nbsp;
                    <asp:Label ID="lblPostState" runat="server"></asp:Label>&nbsp;
                    <asp:Label ID="lblPostZip" runat="server"></asp:Label><br/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Shipping Method&nbsp;</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:DropDownList ID="ddlShipping" CssClass="form-control" DataTextField="shipFull" DataValueField="shipID" runat="server" OnDataBound="addDefaultItem" OnSelectedIndexChanged="ddlShipping_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:RequiredFieldValidator ID="RequiredShipping" runat="server" ErrorMessage="No shipping option selected" ControlToValidate="ddlShipping" ForeColor="red"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <%-- Table for Card Type --%>
        <asp:Table ID="tblCardType" runat="server">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Card Type&nbsp;</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:RadioButtonList ID="rblCardType" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="MCARD">&nbsp;MasterCard&nbsp;</asp:ListItem>
                        <asp:ListItem Value="VISA">&nbsp;Visa&nbsp;</asp:ListItem>
                        <asp:ListItem Value="AMEX">&nbsp;American Express&nbsp;</asp:ListItem>
                        <asp:ListItem Value="DINR">&nbsp;Diner's Club&nbsp;</asp:ListItem>
                    </asp:RadioButtonList>
                </asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:RequiredFieldValidator ID="rfvCardType" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="rblCardType" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    
        <%-- Table for Card Details --%>
        <asp:Table ID="tblDetails" runat="server">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Credit card number</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="tbxCardNumber" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                </asp:TableCell>
            
                <%-- Validation for card number --%>
                <asp:TableCell runat="server">
                    <asp:RequiredFieldValidator ID="rfvNumber" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxCardNumber" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:UpdatePanel ID="uplCardNumber" runat="server">
                        <ContentTemplate>
                            <asp:CustomValidator ID="csvNumberVal" runat="server" CssClass="text-danger" Display="Dynamic" ControlToValidate="tbxCardNumber" ErrorMessage="Invalid Number" OnServerValidate="checkCardNumber" SetFocusOnError="True"></asp:CustomValidator>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click"/>
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Name on credit card</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="tbxCardName" CssClass="form-control" runat="server"></asp:TextBox>
                </asp:TableCell>
            
                <%-- Validation for name --%>
                <asp:TableCell runat="server">
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxCardName" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Expiration date MM-YYYY</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="tbxExpiration" CssClass="form-control" runat="server"></asp:TextBox>
                </asp:TableCell>
            
                <%-- Validation for expiration date --%>
                <asp:TableCell runat="server">
                    <asp:RequiredFieldValidator ID="rfvExpiration" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxExpiration" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rxvExpiration" runat="server" ErrorMessage="Invalid Expiry" CssClass="text-danger" Display="Dynamic" ControlToValidate="tbxExpiration" ValidationExpression="0?[1-9]-[2-9][0-9]{3}|1[0-2]-[2-9][0-9]{3}"></asp:RegularExpressionValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Card security code</asp:TableCell>
                <asp:TableCell runat="server"><asp:TextBox ID="tbxCSC" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox></asp:TableCell>
           
                <%-- Validation for CSC --%>
                <asp:TableCell runat="server">
                    <asp:RequiredFieldValidator ID="rfvCSC" runat="server" ErrorMessage="Required" CssClass="text-danger" ControlToValidate="tbxCSC" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rxvCSC" runat="server" ErrorMessage="Invalid CSC" CssClass="text-danger" Display="Dynamic" ControlToValidate="tbxCSC" ValidationExpression="\d{3}"></asp:RegularExpressionValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ColumnSpan="2" runat="server"><hr/></asp:TableCell> 
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ColumnSpan="2" runat="server"><h3>Total Amount : </h3><asp:Label ID="lblAmount" CssClass="h3" runat="server"></asp:Label></asp:TableCell> 
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ColumnSpan="2" runat="server"><hr/></asp:TableCell> 
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" CssClass="text-danger"> 
                    <asp:UpdateProgress ID="upgProcessing" runat="server" AssociatedUpdatePanelID="uplProcessing" DisplayAfter="100">
                        <ProgressTemplate>
                            Processing payment...
                        </ProgressTemplate>
                    </asp:UpdateProgress> 
                    <asp:UpdatePanel runat="server" ID="uplProcessing">
                        <ContentTemplate>
                            <div>
                                <asp:Label ID="lblResult" CssClass="text-danger" runat="server"></asp:Label>
                            </div>
                            <div>
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-danger margin-space-top-20"/>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table> 
    </asp:Panel>
</asp:Content>