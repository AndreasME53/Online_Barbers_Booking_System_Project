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
    public partial class ServiceDetails : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)//when the admin clicks the update button this code will be run first
            {
                try//This is here to protect the system from crashing
                {
                    //The next few lines are for the updating service option.
                    //This line stores the id of the updating service inorder to pass it to the database through the ReadRecord class ,of GenericServices class, so that the services information can be fill out the fields that can be edited.
                    string ID = Request.QueryString["id"].ToString();
                    SqlConnection _Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ado"].ToString());
                    _Connection.Open();//Requests and opens the database
                    //stores sql into a variable called sqlstring which will be the query for the database 
                //This query will return the details of the service
                    //the sql that will ask for the neccessary information about the service that is being updated
                    string SqlString = "select b.service_choice,  b.service_short_name, b.service_long_name,  c.price_id, c.price, c.effective_date, c.service_choice, b.enabled, b.effective_date[service_date] from service b, service_price c where b.service_choice = c.service_choice and c.price_id = (select max(price_id) from service_price d where d.service_choice = c.service_choice  and d.effective_date <= getdate()) and b.service_choice = '" + ID + "'";
                    //Executes the sql on the database and returns the response object
                    Base_Response _Response = GenericServices.ReadRecord.ProcessRead(SqlString, _Connection);
                    _Connection.Close();//closes database


                    if (_Response.TransactionCompleted)//Checks if the query has been sent to the database
                    {
                        //DT ,of dataTable type, stores the data from the database throught the dataTable ResponseTable in readRecord class,which holds the data table passed from the database
                        DataTable DT = GenericServices.ReadRecord.ResponseTable;

                        if (DT.Rows.Count > 0)//Checks if DT has data in it
                        {
                            //These lines of code will pull out the necessary information from DT and store it correctly into the correct fields of the form and corrects them appropriately
                            hidID.Value = ID;
                            txtServiceNameShort.Text = DT.Rows[0]["service_short_name"].ToString();
                            txtServiceNameMain.Text = DT.Rows[0]["service_long_name"].ToString();
                            txtPrice.Text = DT.Rows[0]["price"].ToString();
                            hidPrice.Value = DT.Rows[0]["price"].ToString();


                            DateTime SelectedDate = DateTime.Parse(DT.Rows[0]["service_date"].ToString());
                            txtEffectiveDate.SelectedDate = SelectedDate;
                            txtEffectiveDate.VisibleDate = SelectedDate;
                            lblHeading.Text = "Update Service";
                            lblCreator.Text = "Modified By:";

                            chbEnabled.Checked = false;
                            if (DT.Rows[0]["enabled"].ToString().ToLower() == "t")
                            {
                                chbEnabled.Checked = true;
                            }
                        }
                        else
                        {
                            //Error message handling goes here
                            lblErrorMessage.Text = _Response.ResponseMessage;
                        }
                    }
                    else
                    {
                        //Error message handling goes here
                        lblErrorMessage.Text = _Response.ResponseMessage;
                    }

                }
                catch
                {
                    
                }

            }
        }
        
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //If the "add" button is clicked after the admin has filled it up these lines of code will run
            //This opens and creates a connection with the database 
            SqlConnection _Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ado"].ToString());
            _Connection.Open();

            if (hidID.Value == "0" || hidID.Value == "")//This checks if the information in the form belongs to a new service being created
            {
                //sqlString stores the sql for the new item to be inserted into the database's table called Service
                string SqlString = "Insert into Service(service_long_name,service_short_name,effective_date,created_by,enabled) values('" + txtServiceNameMain.Text + "','" + txtServiceNameShort.Text + "','" + txtEffectiveDate.SelectedDate.ToString("dd-MMM-yyyy") + "','" + txtCreatedBy.Text + "','" + chbEnabled.Checked.ToString().Substring(0, 1).ToUpper() + "') ";//This is the necessary information needed to be stored into the database inorder to create a new service 

                //Executes the sql on the database and returns the response object
                Base_Response _Response = GenericServices.CreateRecord.Processcreate(SqlString, true, _Connection);


               //sqlString1 stores the sql for the new item to be inserted into the database's table called Service_Price
                string SqlString1 = "Insert into Service_price(service_choice, effective_date,price,created_by,enabled) values('" + _Response.NewID + "','" + txtEffectiveDate.SelectedDate.ToString("dd-MMM-yyyy") + "','" + txtPrice.Text + "','" + txtCreatedBy.Text + "','" + chbEnabled.Checked.ToString().Substring(0, 1).ToUpper() + "')";//This is the necessary information needed to be stored into the database inorder to allow the new service to have a price

                //Executes the sql on the database and returns the response object
                _Response = GenericServices.CreateRecord.Processcreate(SqlString1, true, _Connection);
            }
            else//This checks if the information in the form belongs to an existing service
            {
                //sqlString stores the sql for the updating item to be updated into the database 
                string SqlString = " update ";// need to fix this so the price can change and store modified by
                SqlString += " service set ";
                SqlString += " service_long_name = '" + txtServiceNameMain.Text.ToString().Replace("'", "''") + "',";
                SqlString += " service_short_name='" + txtServiceNameShort.Text.ToString().Replace("'", "''") + "',";
                SqlString += " enabled='" + chbEnabled.Checked.ToString().Substring(0, 1).ToUpper() + "'";
                SqlString += " where service_choice ='" + hidID.Value + "'";

                //the code bellow does the insert into the database for when the admin changers the prices and so the database will keep record or when the prices changed
                double CurrentPrice = Convert.ToDouble(hidPrice.Value);
                double NewPrice = Convert.ToDouble(txtPrice.Text);
                if (CurrentPrice != NewPrice)
                {
                    string SqlString1 = "Insert into Service_price(service_choice, effective_date,price,created_by,enabled) values('" + hidID.Value + "','" + txtEffectiveDate.SelectedDate.ToString("dd-MMM-yyyy") + "','" + txtPrice.Text + "','" + txtCreatedBy.Text + "','" + chbEnabled.Checked.ToString().Substring(0, 1).ToUpper() + "')";//This is the necessary information needed to be stored into the database inorder to allow the new service to have a price

                    //Executes the sql on the database and returns the response object
                    Base_Response _Response2 = GenericServices.CreateRecord.Processcreate(SqlString1, true, _Connection);
                }

                //Executes the sql on the database and returns the response object
                Base_Response _Response = GenericServices.UpdateRecord.ProcessUpdate(SqlString, _Connection);

                if(_Response.TransactionCompleted)
                {

                }
            }

            _Connection.Close();//Closes database

            Response.Redirect("~/pages/admin/services");//Once the data has been passed to othe database the admin is returned to "View Services" page
        }
                     
    }
}