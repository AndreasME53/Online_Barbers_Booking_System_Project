<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminHome.ascx.cs" Inherits="projectmain1._1.Pages.Admin.Controls.AdminHome" %>
<!-- This is the html for the admins home page where the admin can choose to view up coming appointments or view the services offered by the business--> 
 <div class=" text-center col-md" >
     <!-- This is the design of the heading-->
            <h1 class="h3 mb-3 font-weight-normal" & "page-header" >Admin Homepage</h1>
            <p class="lead"><small>Below is where the administrator can choose to View Appointments and View Services</small></p>
            <hr /> 
  </div>
 <div class="row">
     <!--This is the design of the "view bookings" button with heading and features -->

           <div class="col-md-4">
            <div class="card" style="text-align: center">
                <div class="card-header">View Booking</div>
                <div class="card-body">
                    <p><span class="far fa-calendar-check fa-5x"></span></p>
                </div>
                <div class="card-footer"><a class="btn btn-primary btn-lg" href="adminbookings" style="width: 250px">Appointments &raquo;</a></div>
            </div>
        </div>
     <!--This is the design of the "view services" button with heading and features -->
        <div class=" col-md-4">
            <div class="card" style="text-align: center">
                <div class="card-header">View Services</div>
                <div class="card-body">
                    <p><span class="fa fa-map fa-5x"></span></p>
                </div>
                <div class="card-footer">
                    <a class="btn btn-primary btn-lg" href="Services" style="width: 250px">View Services &raquo;</a>
                </div>
            </div>
        </div>
  </div>