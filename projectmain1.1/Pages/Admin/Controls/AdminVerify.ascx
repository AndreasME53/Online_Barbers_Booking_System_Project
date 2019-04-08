<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminVerify.ascx.cs" Inherits="projectmain1._1.Pages.Admin.Controls.AdminVerify" %>
<div class="py-5 text-center">
    <h1>Admin Login </h1>
    <p class="lead">Below is where the admin can login </p>
</div>



<div class="container col-md-7 ">
    <div class="row">
        <div class="col-md-6 ">
            <label for="Username">Username:</label></div>
        <div class="col-md-6 ">

            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control mandatory" ValidateRequestMode="Enabled"></asp:TextBox><asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" CssClass="required_field" ErrorMessage="* Required field" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-6 ">
            <label for="password">Password:</label></div>
        <div class="col-md-6 ">

            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control mandatory" ValidateRequestMode="Enabled" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="rfvPassword" runat="server" CssClass="required_field" ErrorMessage="* Required field" SetFocusOnError="True" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div>
        <div class="row">
            <div class="col-md-6">
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClientClick="btnLogin_click" CssClass="btn btn-primary btn-lg" OnClick="btnLogin_Click" />
            </div>
            <div class="col-md-6"><asp:Label runat="server" ID="lblErrorMessage" cvlass="danger"></asp:Label></div>

        </div>

    </div>
</div>

