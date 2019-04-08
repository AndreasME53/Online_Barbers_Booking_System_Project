﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminBookings.ascx.cs" Inherits="projectmain1._1.Pages.Booking.Controls.AdminBookings" %>
<style>
    .enabled_T {
        color: green;
    }

    .enabled_F {
        color: red;
    }
</style>

<div class="well">
    <asp:DataList ID="ItemsList"
        BorderColor="black"
        CellPadding="5"
        CellSpacing="5"
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
                <td>Enabled:</td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="enabled_<%# DataBinder.Eval(Container.DataItem, "enabled") %>">
            <td id="booking_date"><%#DataBinder.Eval(Container.DataItem, "booking_date","{0:dd-MMM-yyyy}")%>
            <td id="booking_time"><%#DataBinder.Eval(Container.DataItem, "booking_time_hour").ToString().PadLeft(2, '0')%>:<%#DataBinder.Eval(Container.DataItem, "booking_time_minute").ToString().PadRight(2, '0')%></td>
            <td id="service_long_name"><%# DataBinder.Eval(Container.DataItem, "service_long_name") %></td>
            <td id="name"><%# DataBinder.Eval(Container.DataItem, "first_name") %> <%# DataBinder.Eval(Container.DataItem, "last_name") %></td>
            <td id="name"><%# DataBinder.Eval(Container.DataItem, "enabled").ToString().Replace("T", "Expecting Client").Replace("F", "Client Cancelled") %></td>
            <td class="auto-style1">
                <a href="BookingDetail/?id=<%# DataBinder.Eval(Container.DataItem, "booking_id") %>" class="btn btn-info">Update</a>
            </td>
                </tr>
        </ItemTemplate>
    </asp:DataList>

</div>
