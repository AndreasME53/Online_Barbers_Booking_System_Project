<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ServiceDetails.ascx.cs" Inherits="projectmain1._1.Pages.Admin.Controls.ServiceDetails" %>
<style type="text/css">
    .auto-style1 {
        width: 291px;
    }

    .auto-style2 {
        width: 424px;
    }

    .auto-style3 {
        height: 66px;
    }

    .auto-style4 {
        width: 291px;
        height: 39px;
    }

    .auto-style5 {
        width: 424px;
        height: 39px;
    }
</style>
<h4 class="mb-3">
    <asp:Label ID="lblHeading" runat="server" Text="Add Services"></asp:Label>
</h4>
<div class="row">

    <table class="table">
        <tr>
            <td nowrap class="auto-style4">
                <label for="ServiceName">Service Name(main name):</label></td>
            <td class="auto-style5">
                <asp:TextBox ID="txtServiceNameMain" runat="server" BackColor="White" CssClass="form-control mandatory" placeholder="Service Full name" ValidateRequestMode="Enabled"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvServiceNameMain" runat="server" ErrorMessage="* Required field" ControlToValidate="txtServiceNameMain" SetFocusOnError="True" CssClass="required_field"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td nowrap class="auto-style1">Gender(Ladies or
                <label for="serviceName">Gents):</label></td>
            <td class="auto-style2">

                <asp:TextBox ID="txtServiceNameShort" runat="server" CssClass="form-control mandatory" ValidateRequestMode="Enabled" placeholder="Gender name" BackColor="White"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvServiceNameShort" runat="server" ErrorMessage="* Required field" ControlToValidate="txtServiceNameShort" CssClass="required_field" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td nowrap class="auto-style3">Price:</td>
            <td class="auto-style3">
                <div class="input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text">£</span>
                    </div>

                    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control mandatory" ValidateRequestMode="Enabled" placeholder="Price" BackColor="White"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ErrorMessage="* Required field" ControlToValidate="txtPrice" SetFocusOnError="True" CssClass="required_field"></asp:RequiredFieldValidator>
                &nbsp;<asp:RangeValidator ID="rgvPrice" runat="server" ControlToValidate="txtPrice" ErrorMessage="* In valid number for price" MaximumValue="300" MinimumValue="1" SetFocusOnError="True" Type="Double"></asp:RangeValidator>
                </div>
            </td>

            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lblCreator" runat="server" Text="Created By:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <div class="input-group">

                        <asp:TextBox ID="txtCreatedBy" runat="server" BackColor="White" CssClass="form-control mandatory" ValidateRequestMode="Enabled" placeholder="Admin name"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="rfvCreatedBy" runat="server" ErrorMessage="* Required field" ControlToValidate="txtCreatedBy" SetFocusOnError="True" CssClass="required_field"></asp:RequiredFieldValidator>
                    </div>
                </td>
            </tr>

        <tr>
            <td class="auto-style1">Effective Date:</td>
            <td class="auto-style2">
                <asp:Calendar ID="txtEffectiveDate" runat="server"></asp:Calendar>
            </td>
        </tr>
    </table>
</div>




<div class="row">




    <!-- date -->
    <div class="col-md-9 mb-1">
        Enabled:&nbsp;<asp:CheckBox ID="chbEnabled" runat="server" />

    </div>


</div>
<hr class="mb-4">

<asp:Button ID="btnAdd" runat="server" CssClass="btn btn-lg btn-success" OnClick="btnAdd_Click" Text="Complete" type="submit"/>

<asp:HiddenField ID="hidID" runat="server" />
<!-- this for reusing -->
<hr class="mb-4">
