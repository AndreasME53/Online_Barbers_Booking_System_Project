<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Checkout.ascx.cs" Inherits="projectmain1._1.Pages.Booking.Controls.Checkout" %>
<!--Thsi will be the html for the check out section so when the customer is finished creating a booking the will be taken to this finishing page to show then that they have successfully creaed a booking with the business -->
<style>
    .enable_ {
        color: green;
    }
</style>
<!--This is the design of the heading and sub heading -->
<div class="row">
    <h2>Checkout. Thank you for Booking with us today! </h2>
</div>
<div class="row">
    <p class="lead">Below is the details about your appointment. Incase you want to change or cancel your bookings please call Milas Barbers between opening hours. Thank you!</p>
</div>
<!-- this is the tables dimesions, headings and the type of data that will be stored into the table-->
<div class="row">
    <div class="col-md-12 order-md-2 mb-4">

        <asp:DataList ID="ItemsList"
            BorderColor="black"
            CellPadding="10"
            CellSpacing="10"
            RepeatDirection="Vertical"
            RepeatLayout="Table"
            runat="server">
            <AlternatingItemStyle BorderColor="Gray" />
            <HeaderTemplate>
                <tr>
                    <td>Date:</td>
                    <td>Time:</td>
                    <td>Service Choice:</td>
                    <td>Customer Name:</td>
                    <td>Price of service:</td>
                </tr>
            </HeaderTemplate>
            <ItemTemplate><!--This will display the neccessary confirmation details -->
                <tr>
                    </tr>
                    <td class="enable_" id="booking_date"><%#DataBinder.Eval(Container.DataItem, "booking_date","{0:dd/MM/yyyy}")%></td>
                    <td class="enable_" id="booking_time"><%#DataBinder.Eval(Container.DataItem, "booking_time_hour").ToString().PadLeft(2, '0')%>:<%#DataBinder.Eval(Container.DataItem, "booking_time_minute").ToString().PadRight(2, '0')%></td>
                    <td class="enable_" id="service_long_name"><%# DataBinder.Eval(Container.DataItem, "service_long_name") %></td>
                    <td class="enable_"  id="name"><%# DataBinder.Eval(Container.DataItem, "first_name") %> <%# DataBinder.Eval(Container.DataItem, "last_name") %></td>
                    <td class="enable_" id="price_service">£ <%# DataBinder.Eval(Container.DataItem, "price") %></td>
                    </td>
            </ItemTemplate>
        </asp:DataList>
    </div>
</div>
<hr class="mb-4">
     <!--This button will allow the customer to go back to the home page-->
<a href="/" class="btn btn-success">Home <span class="fa fa-home"></span></a>
<hr class="mb-4">
