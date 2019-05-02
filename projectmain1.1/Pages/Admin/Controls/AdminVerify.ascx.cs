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
    public partial class AdminVerify : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {   
            SqlConnection _Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ado"].ToString());//this will request and open the database in order to query it
            _Connection.Open();
            // this is the sql string that will send the filled in username and password information and pass it to the database to check if it matches the entry requirements but first it will pass it to the readRecord class in GenericServices class where it passes it to the database
            string SqlString = "select user_name[user_name], pwd[pwd] from company a where user_name = '" + txtUsername.Text + "'";
            //Executes the sql on the database and returns the response object
            Base_Response _Response =  GenericServices.ReadRecord.ProcessRead(SqlString, _Connection);
            _Connection.Close();

            if (_Response.TransactionCompleted)//Checks if the query has been sent to the database
            {
                if (GenericServices.ReadRecord.ResponseTable.Rows.Count > 0)// This checks of the vairable ResponseTable has data stored in it 
                {
                    //The following set of decisons will check if the data in the username and password fields much that of the ResponseTable variable in the ReadRecord class of GenericServices class,which holds the entry required username and password of the admin.
                   
                    if (txtUsername.Text == GenericServices.ReadRecord.ResponseTable.Rows[0]["user_name"].ToString())//This statement checks if the usernames match
                    {
                        //if the username is correct, this statement checks if the password is correct
                        if (txtPassword.Text == GenericServices.ReadRecord.ResponseTable.Rows[0]["pwd"].ToString())
                        {
                            //This will create a new session for the admin to navigate in admins home page
                            Session.Add("Username", txtUsername.Text);
                            // redirect user
                            Response.Redirect("AdminHome.aspx");
                        }
                        else
                        {
                            //Show invalid password message
                            lblErrorMessage.Text = "Invalid user name and password combination";

                        }
                    }
                    else
                    {
                        //Show invalid username message
                        lblErrorMessage.Text = "Invalid user name and password combination";
                    }
                }
                else
                {
                    //Show invalid username message
                    lblErrorMessage.Text = "Invalid user name and password combination";
                }
            }
            else
            {
                //Shown if the data failed to reach the database
                lblErrorMessage.Text = _Response.ResponseMessage;
            }
        }
    }
}