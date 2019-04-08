<%@ Page Title="" Language="C#" MasterPageFile="~/Booking.Master" AutoEventWireup="true" CodeBehind="MilasBarbersAdmin.aspx.cs" Inherits="projectmain1._1.Pages.Admin.MilasBarbersAdmin" %>

<%@ Register Src="~/Pages/Admin/Controls/AdminVerify.ascx" TagPrefix="uc1" TagName="AdminVerify" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class=" text-center col-md">
            <img class="d-block mx-auto mb-4" src="/docs/4.2/assets/brand/bootstrap-solid.svg" alt="" width="52" height="52">
            <hr />
            <uc1:AdminVerify runat="server" ID="AdminVerify" />
            <hr />
        </div>
    </div>

</asp:Content>
