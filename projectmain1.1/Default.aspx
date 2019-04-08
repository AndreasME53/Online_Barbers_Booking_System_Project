<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="projectmain1._1._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class=" text-center col-md" >
            <h1 class="Bebas Neue" & "page-header" >Welcome to Milas Unisex Babers</h1>
            <h2 class="h3 mb-3 font-weight-normal" & "page-header" >Please chooce a option</h2>
            <p class="lead"><small>Below is where you can Make an Appointment or View the location of the Store</small></p>
            <hr /> 
  </div>
    <div class="row">
        <div class=" col-md-4">
            <div class="card" style="text-align: center">
                <div class="card-header">Make A booking</div>
                <div class="card-body">
                    <p><span class="fa fa-calendar-alt fa-5x"></span></p>
                </div>
                <div class="card-footer"><a class="btn btn-primary btn-lg" href="pages/booking/CreateBooking" style="width: 250px">Make a Booking &raquo;</a></div>
            </div>
        </div>
        <div class=" col-md-4">
            <div class="card" style="text-align: center">
                <div class="card-header">Find Us</div>
                <div class="card-body">
                    <p><span class="fa fa-map fa-5x"></span></p>
                </div>
                <div class="card-footer">
                    <a class="btn btn-primary btn-lg" href="Pages/Booking/ViewBookings.aspx" style="width: 250px">Show in Map &raquo;</a>
                </div>
            </div>
        </div>
        <div class=" col-md-4">
            <asp:Image ID="Image4" runat="server" ImageUrl="~/image/mila5.jpg" Height="260px" Width="300px" />
            </div>
    </div>
   <div class="row">
    <span class="text-muted"><i class="fas fa-folder"></i>Gallery:</span>
<hr class="mb-4">
       </div>
    <div>
    <h6 class="row">
        <asp:Image ID="Image2" runat="server" ImageUrl="~/image/mila.jpg" Height="223px" Width="350px" />
        <asp:Image ID="Image1" runat="server" ImageUrl="~/image/mila2.jpg" Height="223px" Width="350px" />
        <asp:Image ID="Image3" runat="server" ImageUrl="~/image/mila3.jpg" Height="223px" Width="350px" />
    </h6>
</div>
</asp:Content>