<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminHome.ascx.cs" Inherits="projectmain1._1.Pages.Admin.Controls.AdminHome" %>

 <div class=" text-center col-md" >
            <h1 class="h3 mb-3 font-weight-normal" & "page-header" >Please chooce a option</h1>
            <p class="lead"><small>Below is where the administrator can choose to View Upcoming Appointments and Edit Services</small></p>
            <hr /> 
  </div>
 <div class="row">
           <div class="col-md-4">
            <div class="card" style="text-align: center">
                <div class="card-header">View Booking</div>
                <div class="card-body">
                    <p><span class="far fa-calendar-check fa-5x"></span></p>
                </div>
                <div class="card-footer"><a class="btn btn-primary btn-lg" href="adminbookings" style="width: 250px">Appointments &raquo;</a></div>
            </div>
        </div>
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