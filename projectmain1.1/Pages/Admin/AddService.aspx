<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddService.aspx.cs" Inherits="projectmain1._1.Pages.Admin.AddService" %>
<%@ Register src="Controls/ServiceDetails.ascx" tagname="ServiceDetails" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ServiceDetails ID="ServiceDetails1" runat="server" />
</asp:Content>
