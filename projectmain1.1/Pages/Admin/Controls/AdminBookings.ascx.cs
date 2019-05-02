using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace projectmain1._1.Pages.Booking.Controls
{
    public partial class AdminBookings : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)//when the admin opens the "view bookings" page this code will be run first
            {
                //This opens and creates a connection with the database 
                SqlConnection _Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ado"].ToString());
                _Connection.Open();
                //stores sql into a variable called sqlstring which will be the query for the database 
                //This query will return the details of the booking
                string SqlString = "select a.booking_id,a.booking_date,a.booking_time_hour,a.booking_time_minute,a.first_name, a.last_name,a.mobile_no,a.email_address,a.service_choice,b.service_long_name,  a.created_by,a.date_time_created, a.modified_by,a.date_time_modified,a.price_no, a.enabled from booking a, service b where a.service_choice = b.service_choice";
                SqlString += " and a.booking_date >= '" + DateTime.Now.ToString("dd-MMM-yyyy") + "'order by booking_date ASC,booking_time_hour ASC ";
                //This query will ask for all the necessary data that the admin needs to see about the up comming appointments 
                //Executes the sql on the database and returns the response object
                Base_Response _Response = GenericServices.ReadRecord.ProcessRead(SqlString, _Connection);
                _Connection.Close();
                //dv of dataView type stores the data from the database throught the dataTable ResponseTable in readRecord class,which holds the data table passed from the database, and display it to the admin
                DataView dv = new DataView(GenericServices.ReadRecord.ResponseTable);
                ItemsList.DataSource = dv;
                ItemsList.DataBind();
                
            }
        }
    }
}