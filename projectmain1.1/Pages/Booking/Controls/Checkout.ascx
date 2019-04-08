<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Checkout.ascx.cs" Inherits="projectmain1._1.Pages.Booking.Controls.Checkout" %>
<style>
    .enable_ {
        color: green;
    }
</style>
<div class="row">
    <h2>Checkout. Thank you for Booking with us today! </h2>
</div>
<div class="row">
    <p class="lead">Below is the details about your appointment.</p>
</div>
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
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    </tr>
                    <td class="enable_" id="booking_date"><%#DataBinder.Eval(Container.DataItem, "booking_date","{0:dd/MM/yyyy}")%></td>
                    <td class="enable_" id="booking_time"><%#DataBinder.Eval(Container.DataItem, "booking_time_hour").ToString().PadLeft(2, '0')%>:<%#DataBinder.Eval(Container.DataItem, "booking_time_minute").ToString().PadRight(2, '0')%></td>
                    <td class="enable_" id="service_long_name"><%# DataBinder.Eval(Container.DataItem, "service_long_name") %></td>
                    <td class="enable_"  id="name"><%# DataBinder.Eval(Container.DataItem, "first_name") %> <%# DataBinder.Eval(Container.DataItem, "last_name") %></td>
                    </td>
            </ItemTemplate>
        </asp:DataList>
    </div>
</div>
<hr class="mb-4">
<a href="/" class="btn btn-success">Home <span class="fa fa-home"></span></a>
<hr class="mb-4">
