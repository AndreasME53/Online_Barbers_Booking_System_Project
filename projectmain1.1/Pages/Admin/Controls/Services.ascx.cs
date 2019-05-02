using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace projectmain1._1.Pages.Admin.Controls
{
    public partial class Services : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)//when the admin opens the "view services" page this code will be run first
            {
                //This opens and creates a connection with the database 
                SqlConnection _Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ado"].ToString());
                _Connection.Open();
                //stores sql into a variable called sqlstring which will be the query for the database 
                //This query will return the details of the service 
                string SqlString = "select b.service_choice,  b.service_long_name,  b.service_short_name,  c.price_id, c.price, c.effective_date, c.service_choice, b.enabled from service b, service_price c where b.service_choice = c.service_choice and c.price_id = (select max(price_id) from service_price d where d.service_choice = c.service_choice  and d.effective_date <= getdate()) order by b.service_choice ASC";
                //This query will ask for all the necessary data that the admin needs to see about the Services offered 
                //it first stores the sql in sqlString and then passes it to in to the ReadRecord class

                //Executes the sql on the database and returns the response object
                Base_Response _Response = GenericServices.ReadRecord.ProcessRead(SqlString, _Connection);
                _Connection.Close();

                if (_Response.TransactionCompleted)//Checks if the query has been sent to the database
                {
                    //dv of dataView type stores the data from the database throught the dataTable ResponseTable in readRecord class,which holds the data table passed from the database, and display it to the admin
                    DataView dv = new DataView(GenericServices.ReadRecord.ResponseTable);
                    ItemsList.DataSource = dv;
                    ItemsList.DataBind();
                }
                else
                {
                    //Show an error message on the screen.
                    lblErrorMessage.Text = _Response.ResponseMessage;//e.g. "The database is currently not available or your search return no values";
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddService");//If the admin clicks "Add service" they will be redirected to an add services form 
        }
    }
}