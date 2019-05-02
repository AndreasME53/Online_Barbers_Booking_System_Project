<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminVerify.ascx.cs" Inherits="projectmain1._1.Pages.Admin.Controls.AdminVerify" %>
<!-- This html will be the design of the admin login page -->
<div class="py-5 text-center">
<!--heading of login page -->

    <h1>Admin Login </h1>
    <p class="lead">Below is where the admin can login </p>
</div>



<div class="container col-md-7 ">
<!-- this will be the design of the usename and password entry fields -->

    <div class="row">
        <div class="col-md-6 ">
            <label for="Username">Username:</label></div>
        <div class="col-md-6 ">
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control mandatory" ValidateRequestMode="Enabled"></asp:TextBox><asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" CssClass="required_field" ErrorMessage="* Required field" SetFocusOnError="True"></asp:RequiredFieldValidator> <!-- this will be a required field and will pop up a mandatory field for the user -->
        </div>
        <div class="col-md-6 ">
            <label for="password">Password:</label></div>
        <div class="col-md-6 ">

            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control mandatory" ValidateRequestMode="Enabled" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="rfvPassword" runat="server" CssClass="required_field" ErrorMessage="* Required field" SetFocusOnError="True" ControlToValidate="txtPassword"></asp:RequiredFieldValidator><!-- this will be a required field and will pop up a mandatory field for the user -->
        </div>
    </div>
    <div>
        <div class="row">
            <div class="col-md-6">
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClientClick="btnLogin_click" CssClass="btn btn-primary btn-lg" OnClick="btnLogin_Click" /><!--this button will be selected in order to check and send the user to the admin home page or it will initialize the error messagers which will be followed by the error message below--> 
            </div>
            <div class="col-md-6"><asp:Label runat="server" ID="lblErrorMessage" cvlass="danger"></asp:Label><!--Incase of any errors this will display them --></div>

        </div>

    </div>
</div>

