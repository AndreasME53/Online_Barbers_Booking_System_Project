<%@ Page Title="" Language="C#" MasterPageFile="~/Booking.Master" AutoEventWireup="true" CodeBehind="CreateBooking.aspx.cs" Inherits="projectmain1._1.Pages.Booking.CreateBooking" %>

<%@ Register Src="../Controls/BookingDetail.ascx" TagName="Booking" TagPrefix="uc1" %>

<%--<%@ Register Src="Controls/Menu.ascx" TagName="Menu" TagPrefix="uc3" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h2>Book appointment</h2>
    </div>
    <div class="row">
        <p class="lead">Below is where you can book your appointment for hairdressing.</p>
    </div>
    <div class="row">
      
        <div class="col-md-12">
            <uc1:Booking ID="Booking1" runat="server" />
        </div>
    </div>
</asp:Content>
