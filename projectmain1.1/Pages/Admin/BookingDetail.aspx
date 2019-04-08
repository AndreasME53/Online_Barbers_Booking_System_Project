<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="BookingDetail.aspx.cs" Inherits="projectmain1._1.Pages.Admin.BookingDetail" %>
<%@ Register src="../Controls/BookingDetail.ascx" tagname="BookingDetail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <uc1:BookingDetail ID="BookingDetail1" runat="server" />
   
</asp:Content>
