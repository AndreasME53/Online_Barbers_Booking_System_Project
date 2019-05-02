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
    public partial class Checkout : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)//when the customer is sent to "Checkout" page this code will be run first
            {
                //This opens and creates a connection with the database 
                SqlConnection _Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ado"].ToString());
                _Connection.Open();
                //stores sql into a variable called sqlstring which will be the query for the database 
                //This query will return the details of the booking
                string SqlString = "select a.booking_id,a.booking_date,a.booking_time_hour,a.booking_time_minute,a.first_name, a.last_name,a.service_choice,b.service_long_name, c.price from booking a, service b, service_price c where a.service_choice = b.service_choice and b.service_choice = c.service_choice and c.effective_date =(select max(effective_date) from service_price d where c.service_choice = d.service_choice and d.effective_date <=getdate()) ";
                SqlString += " and a.booking_id ='" + Request.QueryString["ID"] + "'";

                //Executes the sql on the database and returns the response object
                Base_Response _Response = GenericServices.ReadRecord.ProcessRead(SqlString, _Connection);
                _Connection.Close();//Closees the connection

                //dv, of type dataView, stores the data from the database from the dataTable ResponseTable in readRecord class, which holds the data table passed from the database, and then displays it to the customer
                DataView dv = new DataView(GenericServices.ReadRecord.ResponseTable);
                ItemsList.DataSource = dv;
                ItemsList.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");//When the custoemr is finished looking at there checkout menu they select this button which they will be redirected to their home page
        }
    }
}