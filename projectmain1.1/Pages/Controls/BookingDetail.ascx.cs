using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace projectmain1._1.Pages.Controls
{
    public partial class BookingDetail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)//when the admin is redirected to this page this code will be run first
            {
                for (int i = 1; i <= 12; i++)//This helps create teh month drop down by converting the months value in to worlds for the customer to see
                {

                    ListItem _LI = new ListItem();
                    _LI.Value = i.ToString();
                    _LI.Text = i.ToString();


                    switch (i)//This switch chnagers the values into words 
                    {
                        case 1:
                            _LI.Text = "January";
                            _LI.Value = "1";
                            ddlMonth.Items.Add(_LI);

                            break;
                        case 2:
                            _LI.Text = "February";
                            _LI.Value = "2";
                            ddlMonth.Items.Add(_LI);
                            break;
                        case 3:
                            _LI.Text = "March";
                            _LI.Value = "3";
                            ddlMonth.Items.Add(_LI);
                            break;
                        case 4:
                            _LI.Text = "April";
                            _LI.Value = "4";
                            ddlMonth.Items.Add(_LI);
                            break;
                        case 5:
                            _LI.Text = "May";
                            _LI.Value = "5";
                            ddlMonth.Items.Add(_LI);
                            break;
                        case 6:
                            _LI.Text = "June";
                            _LI.Value = "6";
                            ddlMonth.Items.Add(_LI);
                            break;
                        case 7:
                            _LI.Text = "July";
                            _LI.Value = "7";
                            ddlMonth.Items.Add(_LI);
                            break;
                        case 8:
                            _LI.Text = "August";
                            _LI.Value = "8";
                            ddlMonth.Items.Add(_LI);
                            break;
                        case 9:
                            _LI.Text = "September";
                            _LI.Value = "9";
                            ddlMonth.Items.Add(_LI);
                            break;
                        case 10:
                            _LI.Text = "October";
                            _LI.Value = "10";
                            ddlMonth.Items.Add(_LI);
                            break;
                        case 11:
                            _LI.Text = "November";
                            _LI.Value = "11";
                            ddlMonth.Items.Add(_LI);
                            break;
                        case 12:
                            _LI.Text = "December";
                            _LI.Value = "12";
                            ddlMonth.Items.Add(_LI);
                            break;
                    }
                }

                //This populates the month and day drop down list's with the current month and day
                ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
                //This subroutine for the day is run first before the day drop down is given the current day
                PopulateDays(Convert.ToInt32(ddlMonth.SelectedValue));
                ddlDay.SelectedValue = DateTime.Now.Day.ToString();
                //This subroutine is run to fill the time drop down list


                //This opens and creates a connection with the database 
                SqlConnection _Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ado"].ToString());
                _Connection.Open();
                //Stores sql into variable sqlstring2 which will be the query for the database 
                string SqlString2 = "select b.service_choice,  b.service_long_name,  b.service_short_name,  c.price_id, c.price, c.effective_date, c.service_choice, b.enabled from service b, service_price c where b.service_choice = c.service_choice and b.enabled = 'T' and c.price_id = (select max(price_id) from service_price d where d.service_choice = c.service_choice  and d.effective_date <= getdate()) order by b.service_long_name ASC";
                //This query will ask for all the necessary data that the admin needs to see the services offered by the business
                //it first stores the sql in sqlString2 and then passes it to in to the ReadRecord class

                //Executes the sql on the database and returns the response object
                Base_Response _Response = GenericServices.ReadRecord.ProcessRead(SqlString2, _Connection);


                //dt ,of type dataTable, stores the data from response of the service call
                DataTable dt = GenericServices.ReadRecord.ResponseTable;
                //Populates and displays each service offered by the business into the service table/menu
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListItem _LI = new ListItem();
                    _LI.Value = dt.Rows[i]["service_choice"].ToString();
                    _LI.Text = dt.Rows[i]["service_short_name"].ToString() + " - " + dt.Rows[i]["service_long_name"].ToString() + " (£ " + Convert.ToDouble(dt.Rows[i]["price"].ToString()).ToString() + ")";

                    lsbService.Items.Add(_LI);
                }
                try//Protects the system from crashing
                {
                    //The next few lines of code are here for when the admin is requesting to update the customers details and appointment

                    //stores id of the customer
                    string ID = Request.QueryString["id"].ToString();
                    //If the ID exists on the query string then following code flows, which means the screen acts as an update and not an insert.
                    //stores sql into variable sqlstring which will be the query for the database 
                    string SqlString = "select a.booking_id,a.booking_date,a.booking_time_hour,a.booking_time_minute,a.first_name, a.last_name,a.mobile_no,a.email_address,a.service_choice,b.service_long_name,  a.created_by,a.date_time_created, a.modified_by,a.date_time_modified,a.price_no, a.enabled from booking a, service b where a.service_choice = b.service_choice and a.booking_id = '" + ID + "'";
                    //This query will ask for all the necessary data that the admin needs to see the customer's appointment and it gets the correct customer information by it requesting the id ,of the customer generated when the customer created a booking, and sends it with the sql to create the neccessary table
                    //it first stores the sql in sqlString and then passes it to in to the ReadRecord class

                    //Executes the sql on the database and returns the response object
                    _Response = GenericServices.ReadRecord.ProcessRead(SqlString, _Connection);
                    _Connection.Close();//Closees the connection

                    //DT ,of dataTable type, stores the data from the database throught the dataTable ResponseTable in readRecord class,which holds the data table passed from the database
                    DataTable DT = GenericServices.ReadRecord.ResponseTable;

                    //These lines of code will pull out the necessary information from DT and store it correctly into the correct fields of the form and corrects them appropriately
                    txtFirstName.Text = DT.Rows[0]["first_name"].ToString();
                    txtLastName.Text = DT.Rows[0]["last_name"].ToString();
                    txtPhone.Text = DT.Rows[0]["mobile_no"].ToString();
                    txtemail.Text = DT.Rows[0]["email_address"].ToString();

                    DateTime NewDate = DateTime.Parse(DT.Rows[0]["booking_date"].ToString());
                    Populatehours(NewDate.DayOfWeek);


                    lblHeading.Text = "View Booking";
                    lsbService.SelectedValue = DT.Rows[0]["service_choice"].ToString();
                    if (DT.Rows[0]["enabled"].ToString() == "T")
                    {
                        chbEnabled.Checked = true;

                    }
                    else
                    {
                        chbEnabled.Checked = false;

                    }
                    chbEnabled.Enabled = true;

                    ddlMonth.SelectedValue = NewDate.Month.ToString();
                    ddlDay.SelectedValue = NewDate.Day.ToString();
                    ddlTimes.SelectedValue = DT.Rows[0]["booking_time_hour"].ToString();
                }
                catch
                {
                    //The page will land here if there is no "ID" on the querystring therefore making the screen be used for insert records.
                    //This reveals the enabled button to the admin in order to cancel or uncancel a booking
                    Populatehours(DateTime.Now.DayOfWeek);
                    divEnabled.Visible = false;
                }

                _Connection.Close();//closes connection

            }

        }

        /// <summary>
        /// Populates the applicable hours according to the selected date. If the screen is an update of a record that is not "Today", then the screen needs to show the appplicable hours for the applicable day. otherwise it must show the hours for the applicable date being used. For example if the method is called for a create booking then the hours must be populated for the date of the booking. if the screen is being used for updating a historical record then the historical records day must be used to determine the appropriate hours.
        /// </summary>
        /// <param name="Day"></param>
        protected void Populatehours(DayOfWeek Day)
        {

            //clears drop down incase they change the day or month
            ddlTimes.Items.Clear();
            //This stores the choosen day and month in their drop downs
            DayOfWeek DayOfTheWeek = DateTime.Parse(ddlDay.SelectedValue.ToString() + "-" + ddlMonth.SelectedItem.Text.ToString() + "-" + DateTime.Now.Year.ToString()).DayOfWeek;
            //vairables for the beging and end hours
            int StartHours;
            int EndHours;

            if (Day == DayOfWeek.Sunday)//checks of the choosen day is "sunday"
            {
                //if it is sunday, the hours then choosen opening and closing times of that daytimes of that day
                StartHours = 10;
                EndHours = 18;
            }
            else//if it is a weekday or saturday, the hours then choosen opening and closing times of that day
            {
                StartHours = 9;
                EndHours = 19;
            }

            if (Day == DayOfWeek.Saturday)//checks of the choosen day is "saturday"
            {
                //if it is saturday, the hours then choosen opening and closing times of that day
                StartHours = 9;
                EndHours = 18;
            }
            



            for (int i = StartHours; i <= EndHours; i++)//This populates the time drop down list accourding to the day so that teh correct day has the correct available open times
            {
                ListItem _LI = new ListItem();
                _LI.Value = i.ToString();
                _LI.Text = i.ToString() + ":00";

                ddlTimes.Items.Add(_LI);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)//This button is used to insert or update the database once it has been clicked
        {
            //The nexts lines of code is used to check if the admin is updating a customer's information or the customer has created a booking
            string ID = "";
            try
            {
                ID = Request.QueryString["id"].ToString();

            }
            catch
            {

            }

            if (ID == "")//This checks if the information in the form is the creation of a new booking
            {
                // DT will store the choosen time that the customer selected based on the 3 drop downs.
                DateTime DT = DateTime.Parse(ddlMonth.SelectedValue + "-" + ddlDay.SelectedValue + "-" + DateTime.Now.Year.ToString());
                //sqlString stores the sql for the new booking to be inserted into the database
                string SqlString = "insert into [booking] (first_name, last_name, mobile_no, email_address, service_choice, booking_date, booking_time_hour, booking_time_minute)";
                SqlString += " values (";
                SqlString += "'" + txtFirstName.Text + "',";
                SqlString += "'" + txtLastName.Text + "',";
                SqlString += "'" + txtPhone.Text + "',";
                SqlString += "'" + txtemail.Text + "',";
                SqlString += "'" + lsbService.SelectedValue + "',";
                SqlString += "'" + DT.ToString("dd-MMM-yyyy") + "',";
                SqlString += "'" + ddlTimes.SelectedValue + "',";
                SqlString += "'00'";
                SqlString += ")";
                // This is the necessary information needed to be stored into the database inorder to create a new booking
                //This opens and creates a connection with the database 
                SqlConnection _Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ado"].ToString());
                _Connection.Open();

                //Executes the sql on the database and returns the response object
                Base_Response _Response = GenericServices.CreateRecord.Processcreate(SqlString, true, _Connection);
                _Connection.Close();//closes connection
                //once query has been sent to database to insert a new booking for the customer, they will be redirect to a checkout page to view service purchase
                Response.Redirect("Checkout/?ID=" + _Response.NewID);
            }
            else//if there is a ID that is passed this will update data in the database
            {

                // DT will store the choosen time that the customer selected based on the 3 drop downs.
                DateTime DT = DateTime.Parse(ddlMonth.SelectedValue + "-" + ddlDay.SelectedValue + "-" + DateTime.Now.Year.ToString());
                //sqlString stores the sql for the updating customer details on the booking in the table
                string SqlString = "update  [booking] set ";
                SqlString += "first_name = '" + txtFirstName.Text + "',";
                SqlString += "last_name = '" + txtLastName.Text + "',";
                SqlString += "mobile_no = '" + txtPhone.Text + "',";
                SqlString += " email_address ='" + txtemail.Text + "',";
                SqlString += " service_choice = '" + lsbService.SelectedValue + "',";
                SqlString += " booking_date = '" + DT.ToString("dd-MMM-yyyy") + "',";
                SqlString += " booking_time_hour = '" + ddlTimes.SelectedValue + "',";
                SqlString += " booking_time_minute = '00',";
                SqlString += " enabled = '" + chbEnabled.Checked.ToString().Substring(0, 1).ToUpper() + "'";
                SqlString += " where booking_id ='" + ID + "'";

                //This opens and creates a connection with the database 
                SqlConnection _Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ado"].ToString());
                _Connection.Open();

                //Executes the sql on the database and returns the response object
                Base_Response _Response = GenericServices.UpdateRecord.ProcessUpdate(SqlString, _Connection);
                _Connection.Close();//closes connection

                Response.Redirect("../AdminBookings");//Once the data has been passed to othe database the admin is returned to "View appointments" page
            }

        }


        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)//This passes the month value that is in the month drop down list to the day drop down list
        {
            PopulateDays(Convert.ToInt32(ddlMonth.SelectedValue));//passes the month value
        }


        protected void PopulateDays(int Month)//This populates the day drop down list to match the month value that is in the month drop down list alsready
        {
            ddlDay.Items.Clear();//cleares the list incase of reselection of month
            int days = DateTime.DaysInMonth(DateTime.Now.Year, Month);//stores the number of valid days accourding to the month in variable

            for (int i = 1; i <= days; i++)//loops each day value in the drop down list
            {
                ListItem _LI = new ListItem();
                _LI.Text = i.ToString();
                _LI.Value = i.ToString();
                ddlDay.Items.Add(_LI);
            }
        }

        protected void ddlDay_SelectedIndexChanged(object sender, EventArgs e)//This runs the populate douurs subrutine
        {
            DateTime DTValue = DateTime.Parse(ddlDay.SelectedValue + "-" + ddlMonth.SelectedItem.Text + "-" + DateTime.Now.Year.ToString());

            Populatehours(DTValue.DayOfWeek);
        }


    }
}