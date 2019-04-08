<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ServiceDetails.aspx.cs" Inherits="projectmain1._1.Pages.Admin.ServiceDetails" %>
<%@ Register src="Controls/ServiceDetails.ascx" tagname="ServiceDetails" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ServiceDetails ID="ServiceDetails1" runat="server" />
</asp:Content>
