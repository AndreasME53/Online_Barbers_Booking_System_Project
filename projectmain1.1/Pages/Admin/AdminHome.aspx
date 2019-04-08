<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="projectmain1._1.Pages.Admin.AdminHome" %>
<%@ Register src="Controls/AdminHome.ascx" tagname="AdminHome" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:AdminHome ID="AdminHome1" runat="server" />
</asp:Content>
