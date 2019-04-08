<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookingDetail.ascx.cs" Inherits="projectmain1._1.Pages.Controls.BookingDetail" %>
<h4 class="mb-3"><i class="fas fa-home"></i>
    <asp:Label ID="lblHeading" runat="server" Text="Your information"></asp:Label>
</h4>

<%--<uc1:Menu runat="server" ID="Menu" />--%>
<div class="row">
    <div runat="server" id="divEnabled">
        <table class="table" style="width:100%">
            <tr>
                <td nowrap>
                    <label for="firstName">Enabled</label></td>
                <td>
                    <asp:CheckBox ID="chbEnabled" runat="server" Enabled="false" Checked="true" />
                </td>

            </tr>
        </table>
    </div>
    <table class="table">
        <tr>
            <td nowrap>
                <label for="firstName">First Name</label></td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control mandatory" ValidateRequestMode="Enabled" placeholder="First Name" BackColor="White"></asp:TextBox><asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="* Required field" ControlToValidate="txtFirstName" SetFocusOnError="True" CssClass="required_field"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td nowrap>
                <label for="lastName">Last Name</label></td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control mandatory" ValidateRequestMode="Enabled" placeholder="Last Name" BackColor="White"></asp:TextBox><asp:RequiredFieldValidator ID="rfvLastName" runat="server" ErrorMessage="* Required field" ControlToValidate="txtLastName" CssClass="required_field" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td nowrap>
                <label for="Phone number">Phone number</label></td>
            <td>
                <div class="input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text">+44</span>
                    </div>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control mandatory" ValidateRequestMode="Enabled" placeholder="Phone number" BackColor="White"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfdPhoneNumber" runat="server" ErrorMessage="* Required field" ControlToValidate="txtPhone" SetFocusOnError="True" CssClass="required_field"></asp:RequiredFieldValidator>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <label for="email">Email <span class="text-muted">(Optional)</span></label></td>
            <td>
                <div class="input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text fa fa-envelope"></span>
                    </div>
                    <asp:TextBox ID="txtemail" runat="server" CssClass="form-control mandatory" ValidateRequestMode="Enabled" placeholder="you@example.com"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmailAddress" runat="server" ErrorMessage="* Required field" ControlToValidate="txtemail" SetFocusOnError="True" CssClass="required_field"></asp:RequiredFieldValidator>
                </div>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtemail" CssClass="required_field" ErrorMessage="* Invalid email address format" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
    </table>
</div>
<div class="row">
    <div class="col-md-7 mb-6">
        <label for="Choice">Service choice:</label>
        <div class="input-group-prepend">
            <%-- this will be the menu that the customers can view and select their service. the data will be called from the database --%>
            <asp:ListBox runat="server" ID="lsbService" CssClass="form-control" Rows="26" SelectionMode="Multiple" Height="172px" Width="427px" Font-Bold="True" Font-Italic="True" Font-Names="Arial Rounded MT Bold" Font-Overline="True" Font-Strikeout="False" Font-Underline="False" ForeColor="Black">
                <asp:ListItem Value="">--Select Option--</asp:ListItem>



            </asp:ListBox>
            <asp:RequiredFieldValidator ID="rqfServices" runat="server" ErrorMessage="* Required field" ControlToValidate="lsbService" SetFocusOnError="True" CssClass="required_field"></asp:RequiredFieldValidator>
            <!-- try  make it look better -->
        </div>
    </div>
    <!-- service choice-->
    <div class="col-md-5 mb-3">
        <label for="date">Date</label><small>   (for the appointment)<br />
        </small>
        <asp:Label ID="Label1" runat="server" Text="Month:"></asp:Label>
        <br />
        &nbsp;<asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control mandatory" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
            <asp:ListItem Value="">---Select Month--</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="Day:"></asp:Label>
        <asp:DropDownList ID="ddlDay" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlDay_SelectedIndexChanged">
        </asp:DropDownList>
        <div class="invalid-feedback">
            Please select a valid date.
        </div>
    </div>
    <!-- date -->
    <div class="col-md-4 mb-3">
        <label for="time">Time</label>
        <asp:DropDownList ID="ddlTimes" runat="server" CssClass="form-control" Height="34px" Width="159px">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvTime" runat="server" ControlToValidate="ddlTimes" CssClass="required_field" ErrorMessage="* Required Field" SetFocusOnError="True"></asp:RequiredFieldValidator>
    </div>
    <!-- time -->
    <!-- <div class="col-md-3 mb-3">
        <label for="Products">Product choice(s):</label>
        <div class="input-group-prepend">
            <span class="input-group-text">Option:</span>
            <asp:DropDownList ID="ddlProduct" runat="server" CssClass="form-control mandatory">
                <asp:ListItem Value="">---Select Product--</asp:ListItem>
                <asp:ListItem Value="2">1</asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            <asp:Button ID="btnAddToCart" runat="server" CausesValidation="False" OnClick="btnAddToCart_Click" Text="Add to Cart" />
        </div>
        <div class="invalid-feedback">
            Please enter a valid Product.
        </div>
    </div> -->
    <!-- product choice -->
</div>
<hr class="mb-4">
<asp:Button ID="btnSubmit" CssClass="btn btn-primary btn-lg" runat="server" OnClick="btnSubmit_Click" Text="Check out" BackColor="#009900" />
<button type="reset" class="btn btn-danger btn-lg ">Clear</button>
<hr class="mb-4">
