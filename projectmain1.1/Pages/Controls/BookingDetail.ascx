<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookingDetail.ascx.cs" Inherits="projectmain1._1.Pages.Controls.BookingDetail" %>
<%--<uc1:Menu runat="server" ID="Menu" />--%>

<!--This will be the html for the form of the "make a booking", which will let the customer to fill out inorder to create a new booking or allow the admin to update/edit the customers booking incase the customers call and have a problem with there appointment -->

<!--This is the heading design of the "make a booking" webpage -->
<h4 class="mb-3"><i class="fas fa-home"></i>
    <asp:Label ID="lblHeading" runat="server" Text="Your information"></asp:Label>
</h4>

<div class="form-horizontal">
    <!--
        This will be the layout of the form for the customers to make a booking or the admin to edit customres booking.
    
    It will ask for the customers first and second names, Phone number, email address, service choise, date of the appointment and the time that the customer would like to come to the booking. 
    
    In Addition I have made all fields mandatory becuase all fields need to be meet in order for a booking to be stored properly in the database.          
    -->
    <!--
        The form will respond differently if the admin is updating a booking. 
        
        When the admin clicks on the update booking button in the admin logged in section, the form will be filled with the correct customer information from the booking record they will be updating. The heading will change to "Customer Information" as well as an enable button will appear in the case of the customer cancelled their appointment. 
        
        As the database will keep a record of all past, canceled and current appointments as all databases should 
        
        -->
    <div class="row">
        <div runat="server" id="divEnabled">
            <table class="table" style="width: 100%">
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
                        <!--<asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtPhone" CssClass="required_field" ErrorMessage="* Invalid phone number format" SetFocusOnError="True"></asp:RegularExpressionValidator><!--this is a further validation check because it checks if the users phone number is from the uk but not if it is an actual phone number from the uk -->
                        <br />
                        <asp:RequiredFieldValidator ID="rfdPhoneNumber" runat="server" ErrorMessage="* Required field" ControlToValidate="txtPhone" SetFocusOnError="True" CssClass="required_field"></asp:RequiredFieldValidator>
                        &nbsp;<asp:RegularExpressionValidator ID="revPhoneNumber" runat="server" ControlToValidate="txtPhone" CssClass="required_field" ErrorMessage="* Invalid mobile no format" SetFocusOnError="True" ValidationExpression="^(((\+44\s?\d{4}|\(?0\d{4}\)?)\s?\d{3}\s?\d{3})|((\+44\s?\d{3}|\(?0\d{3}\)?)\s?\d{3}\s?\d{4})|((\+44\s?\d{2}|\(?0\d{2}\)?)\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$"></asp:RegularExpressionValidator>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="email">Email</label></td>
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
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtemail" CssClass="required_field" ErrorMessage="* Invalid email address format" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><!--This is a further validation check because it checks if the users email address is has the @ symblo in it but not if it is an actual email address -->
                </td>
            </tr>
        </table>
    </div>
    <div class="row">

        <div class="col-md-2">
            <label for="Choice">Service choice:</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Required field" ControlToValidate="lsbService" SetFocusOnError="True" CssClass="required_field"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="col-md-7">
        <%-- this will be the menu that the customers can view and select their service from. the data will be called from the database --%>


        <asp:ListBox runat="server" ID="lsbService" CssClass="form-control-list" Rows="20" SelectionMode="Multiple" Font-Bold="True" Font-Italic="True" Font-Names="Arial Rounded MT Bold" Font-Overline="True" Font-Strikeout="False" Font-Underline="False" ForeColor="Black">
            <asp:ListItem Value="">--Select Option--</asp:ListItem>
        </asp:ListBox>
    </div>
    <div class="col-md-3">
    </div>

    <div class="row">

        <!-- This is the date drop down for days and months which as the customer loads into the webpage it will automatically select the current date -->
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
        <div class="col-md-4 mb-3">
            <!--This is the time drop down all of all the avaible times of the business in the choosen day -->
            <label for="time">Time</label>
            <asp:DropDownList ID="ddlTimes" runat="server" CssClass="form-control" Height="34px" Width="159px">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvTime" runat="server" ControlToValidate="ddlTimes" CssClass="required_field" ErrorMessage="* Required Field" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>
    </div>
    <hr class="mb-4">
    <asp:Button ID="btnSubmit" CssClass="btn btn-primary btn-lg" runat="server" OnClick="btnSubmit_Click" Text="Check out" BackColor="#009900" /><!--This button will pass the data store in each fields to the database once all required fields have been meet -->
    <button type="reset" class="btn btn-danger btn-lg ">Clear</button><!--This button clears the list incase the user wants to redue their selections -->
    <hr class="mb-4">
</div>

