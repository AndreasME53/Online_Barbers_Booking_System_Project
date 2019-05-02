<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ServiceDetails.ascx.cs" Inherits="projectmain1._1.Pages.Admin.Controls.ServiceDetails" %>
<!--This will be the html for the form of the services, which will let the admin to fill out inorder to create a new service or update/edit a service -->
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
</style><!--this is the heading of the "Add Services " webpage -->
<h4 class="mb-3">
    <asp:Label ID="lblHeading" runat="server" Text="Add Services"></asp:Label>
</h4>
<div class="row">
    <!--This will be the design of the form for the services to be added or updated to the database. It will ask for the services name, which gender is it offerd to, price, created by, Effective date and enabled in order for the customers to choose it or not. In Addition I have made the Service name, Gender, Price and created by fields mandatory becuase those fielded need to be meet in order for the service to be stored properly in the database. Effective date and enabled are not mandatory because the admin can come back later to activate and set the date whenever they choose to  -->
    <!--The form will change if the admin is updating a service. When the admin clicks on the update button the form will be filled with the correct service information ,that they are updating, and the heading will change to "Update Service" and the created by lable will change to modified. As the database will keep a record of the people who has modified the service and who has added a service as all databases should--> 
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

<asp:Button ID="btnAdd" runat="server" CssClass="btn btn-lg btn-success" OnClick="btnAdd_Click" Text="Complete" type="submit"/><!--once the form has been correctly fill out this button will the pass the filled fields to databsae to be stored and accessed in a later date -->
<asp:HiddenField ID="hidPrice" runat="server" /><!--this for when the user cahngers the price -->
<asp:HiddenField ID="hidID" runat="server" /><!--This allow the service form to change for the "add service" form to "update service" form and "created by" field into "modifiled by" field  --> 
<!-- I made the form do this because i wanted to re use my code and make the project more effiecent as it takes upless space and moves at a faster pace -->
<div class="col-md-6"><asp:Label runat="server" ID="lblErrorMessage" cvlass="danger"></asp:Label><!--Incase of any errors this will display them -->

</div>
<hr class="mb-4">
