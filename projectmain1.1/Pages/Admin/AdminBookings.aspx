<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminBookings.aspx.cs" Inherits="projectmain1._1.Pages.Admin.AdminBookings" %>
<%@ Register src="Controls/AdminBookings.ascx" tagname="AdminBookings" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:AdminBookings ID="AdminBookings1" runat="server" />
</asp:Content>
