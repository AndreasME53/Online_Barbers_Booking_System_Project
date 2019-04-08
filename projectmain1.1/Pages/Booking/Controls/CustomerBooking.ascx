<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomerBooking.ascx.cs" Inherits="projectmain1._1.Pages.Booking.Controls.CustomerBooking" %>



  <div class="well">
    <table class="table table-striped">
      <thead>
        <tr>
          <th>#</th>
          <th>Date:</th>
          <th>Time:</th>
          <th>Choice:</th>
          <th class="auto-style1"></th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>1</td>
          <td>1/13/2019</td>
          <td>8:00</td>
          <td>straight cut</td>
          <td class="auto-style1">
              <%--<input id="Buttonmain" class="btn btn-info" data-toggle="modal1" data-target="#update" type="submit" value="update" />
              <input id="Button" class="btn btn-danger" data-toggle="modal" data-target="#delete" type="button" value="delete" />--%></td>
        </tr>
      </tbody>
    </table>

    <%--  <div class="modal small hide fade" id="delete" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
    <div class="modal-header" role="document">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h3 id="myModalLabel">Delete Confirmation</h3>
    </div>
    <div class="modal-body">
        <p class="error-text">Are you sure you want to delete the user?</p>
    </div>
    <div class="modal-footer">
        <button class="btn" data-dismiss="modal" aria-hidden="true">Cancel</button>
        <button class="btn btn-danger" data-dismiss="modal">Delete</button>
    </div>
</div><!-- delete pop up -->
      <div class="modal small hide fade" id="update" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
    <div class="modal-header" role="document">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×<!-- make this a pic --></button>
        <h3 id="myModalLabel1">Update Confirmation</h3>
    </div>
    <div class="modal-body">
        <p class="error-text">Are you sure you want to update this?
        </p>
    </div>
    <div class="modal-footer">
        <button class="btn" data-dismiss="modal" aria-hidden="true">Cancel</button>
        <button class="btn btn-danger" data-dismiss="modal">update</button>
    </div>
</div><!-- update pop up  it will delete the booking and then send the user to the booking page where they will rebook appoitment-->
--%>

</div>