<%@ Page Title="" Language="C#" MasterPageFile="~/Booking.Master" AutoEventWireup="true" CodeBehind="Location.aspx.cs" Inherits="projectmain1._1.Pages.Booking.Location" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!--This is the html that will show the location of the business in a google map design. This code was sourced by google maps  --> 
    <div>
        <h4 class="mb-3"><i class="fas fa-home"></i>
   <asp:Label ID="Label1" runat="server" Text="Location of Store:" Font-Names="Arial"></asp:Label>
</h4>
        
    </div>
    <div> 
        <div class="mapouter"><div class="gmap_canvas"><iframe width="542" height="548" id="gmap_canvas" src="https://maps.google.com/maps?q=mila%20unisex%20&t=&z=15&ie=UTF8&iwloc=&output=embed" frameborder="0" scrolling="no" marginheight="0" marginwidth="0"></iframe><a href="https://www.emojilib.com">emojilib.com</a></div><style>.mapouter{position:relative;text-align:right;height:548px;width:542px;}.gmap_canvas {overflow:hidden;background:none!important;height:548px;width:542px;}</style></div>
    </div>
</asp:Content>
