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
            if (!this.IsPostBack)
            {

                SqlConnection _Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ado"].ToString());
                _Connection.Open();
                string SqlString = "select a.booking_id,a.booking_date,a.booking_time_hour,a.booking_time_minute,a.first_name, a.last_name,a.mobile_no,a.email_address,a.service_choice,b.service_long_name,  a.created_by,a.date_time_created, a.modified_by,a.date_time_modified,a.price_no, a.enabled from booking a, service b where a.service_choice = b.service_choice";
                SqlString += " and a.booking_date >= '" + DateTime.Now.ToString("dd-MMM-yyyy") + "'";
                BaseResponse _Response = GenericServices.ReadRecord.ProcessRead(SqlString, _Connection);
                _Connection.Close();              

                string Result = "";                       
                
                DataView dv = new DataView(GenericServices.ReadRecord.ResponseTable);
                ItemsList.DataSource = dv;
                ItemsList.DataBind();
                
            }
        }
    }
}