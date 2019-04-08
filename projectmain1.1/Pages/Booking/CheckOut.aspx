<%@ Page Title="" Language="C#" MasterPageFile="~/Booking.Master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="projectmain1._1.Pages.Booking.CheckOut" %>

<%@ Register Src="~/Pages/Booking/Controls/Checkout.ascx" TagPrefix="uc1" TagName="Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:Checkout runat="server" ID="Checkout" />
</asp:Content>
