<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewBooking.ascx.cs" Inherits="projectmain1._1.Pages.Booking.Controls.ViewBooking" %>
<div class="well">
    <table class="table table-striped">
        <tbody>
            <asp:Label runat="server" ID="lblResults02"></asp:Label>
        </tbody>
    </table>
    <div class="modal fade" id="Delete" tabindex="-1" role="dialog" aria-labelledby="delLabel">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <a href="#" class="Close" data-dismiss="modal" aria-label="Close">&times;</a>

                    <h4 class="modal-title text-center" id="delLabel">Delete Confirmation</h4>
                </div>
                <form action="" method="post">
                    <!-- what is the action-->

                    <div class="modal-body">
                        <p class="text-center">Are you sure you want to delete the service?</p>
                        <input type="hidden" name="category_id" id="cat1_id" value="" />
                    </div>
                    <div class="modal-footer">
                        <button type="submit" class="btn btn-success">Cancel</button>
                        <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger" Text="Delete" />
                    </div>
                </form>
            </div>
        </div>
    </div>
    <!-- delete pop up -->
</div>
<div class="well">
    <table class="table table-striped">
        <thead>
            <tr>
                <th>#</th>
                <th>Date of appointment:</th>
                <th>Choice name:</th>
                <th>Time:</th>
                <th>Price:</th>
                <th class="auto-style1"></th>
            </tr>
        </thead>
        <tbody>
            <asp:DataList ID="ItemsList"
                BorderColor="black"
                CellPadding="5"
                CellSpacing="5"
                RepeatDirection="Vertical"
                RepeatLayout="Table"
                RepeatColumns="3"
                runat="server">
                <HeaderStyle BackColor="#aaaadd"></HeaderStyle>
                <ItemTemplate>
                    <tr class="table">
                        <td>1</td>
                        <td id="booking_date"><%#DataBinder.Eval(Container.DataItem, "booking_date","{0:dd/MM/yyyy}")%>
                        </t>
                        <td id="service_long_name"><%# DataBinder.Eval(Container.DataItem, "service_long_name") %></td>
                        <td id="booking_time"><%#DataBinder.Eval(Container.DataItem, "booking_time_hour")%>:<%#DataBinder.Eval(Container.DataItem, "booking_time_minute")%></td>
                        <td>£ <%# DataBinder.Eval(Container.DataItem, "price") %></td>
                        <td class="auto-style1">
                            <input id="btndel" class="btn btn-danger" data-toggle="modal" data-target="#Delete" type="button" value="Delete" />
                            <a href="ServiceDetails/?id=<%# DataBinder.Eval(Container.DataItem, "service_choice") %>" class="btn btn-info">Update</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:DataList>
        </tbody>
    </table>
    <hr class="mb-4">
    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-default" OnClick="btnAdd_Click" Text="+Change Service" />
</div>
