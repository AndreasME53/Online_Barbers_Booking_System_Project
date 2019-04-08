<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Services.ascx.cs" Inherits="projectmain1._1.Pages.Admin.Controls.Services" %>

<style>
    .enabled_T {
        color: green;
    }

    .enabled_F {
        color: red;
    }
</style>

<div class="well">
    <table class="table table-striped">
        <tbody>
            <asp:Label runat="server" ID="lblResults02"></asp:Label>
        </tbody>
    </table>
</div>

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
            <td>#</td>
            <td>Service Date</td>
            <td>Service Name</td>
            <td>Enabled</td>
            <td>Price</td>
            <td>Options</td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="enabled_<%# DataBinder.Eval(Container.DataItem, "enabled") %>">
            <td><%# DataBinder.Eval(Container.DataItem, "service_choice") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, "effective_date","{0:dd-MMM-yyyy}")%></td>
            <td><%# DataBinder.Eval(Container.DataItem, "service_long_name") %></td>
            <td><%# DataBinder.Eval(Container.DataItem, "enabled").ToString().Replace("T", "Activated service").Replace("F", "Deactivated service") %></td>
            <td>£ <%# DataBinder.Eval(Container.DataItem, "price") %></td>
            <td class="auto-style1">
                <a href="ServiceDetails/?id=<%# DataBinder.Eval(Container.DataItem, "service_choice") %>" class="btn btn-info">Update</a>
            </td>
            </tr>
        </ItemTemplate>
    </asp:DataList>
    <hr class="mb-4">
    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-default" OnClick="btnAdd_Click" Text="+Add Service" />
    <asp:HiddenField ID="hidID" runat="server" />
</div>
