<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Services.ascx.cs" Inherits="projectmain1._1.Pages.Admin.Controls.Services" %>
<!-- This will be the html for the "view Services" webpage. This page will allow the admin to view all active and inactive services offered to their customers in a form of a table --> 
<style>
    .enabled_T {
        color: green;
    }

    .enabled_F {
        color: red;
    }
</style>
<div class=" text-center col-md" >
            <h2 class="h3 mb-3 font-weight-normal" & "page-header" >Services</h2>
            <p class="lead"><small>Below is where you can view or edit or add Services</small></p>
            <hr /> 
  </div>
<!-- this is the tables dimesions, headings and the type of data that will be stored into the table-->
<div class="well">
    <asp:DataList ID="ItemsList"
        BorderColor="black"
        CellPadding="5"
        CellSpacing="5"
        RepeatDirection="Vertical"
        RepeatLayout="Table"
        runat="server">
        <AlternatingItemStyle BorderColor="Gray" />
        <HeaderTemplate>
            <tr>
            <td>Service Date</td>
            <td>Service Name</td>
            <td>Enabled</td>
            <td>Price</td>
            <td>Options</td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate><!--these will be the records that will be stored into the table from the database -->
            <tr class="enabled_<%# DataBinder.Eval(Container.DataItem, "enabled") %>">
            <td><%#DataBinder.Eval(Container.DataItem, "effective_date","{0:dd-MMM-yyyy}")%></td>
            <td><%# DataBinder.Eval(Container.DataItem, "service_short_name") %> - <%# DataBinder.Eval(Container.DataItem, "service_long_name") %></td>
            <td><%# DataBinder.Eval(Container.DataItem, "enabled").ToString().Replace("T", "Activated service").Replace("F", "Deactivated service") %></td>
            <td>£ <%# DataBinder.Eval(Container.DataItem, "price") %></td>
            <td class="auto-style1">
                 <!--This button will allow the admin to update/edit the services -->
                <a href="ServiceDetails/?id=<%# DataBinder.Eval(Container.DataItem, "service_choice") %>" class="btn btn-info">Update</a>
            </td>
            </tr>
        </ItemTemplate>
    </asp:DataList>
    <hr class="mb-4">
     <!--This button will allow the admin to add a new service to offer to the customers -->
    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-default" OnClick="btnAdd_Click" Text="+Add Service" />
    <asp:HiddenField ID="hidID" runat="server" />
    <div class="col-md-6"><asp:Label runat="server" ID="lblErrorMessage" cvlass="danger"></asp:Label><!--Incase of any errors this will display them -->

</div>
</div>
