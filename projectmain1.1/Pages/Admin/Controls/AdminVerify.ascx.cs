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
        //public string conString = "Data Source=LAPTOP-S0ESM9EE\\MAIN_SQL;Initial Catalog=TestDatabase;Integrated Security=True";
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection _Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ado"].ToString());
            _Connection.Open();
            string SqlString = "select user_name[user_name], pwd[pwd] from company a where user_name = '" + txtUsername.Text + "'";            
            BaseResponse _Response =  GenericServices.ReadRecord.ProcessRead(SqlString, _Connection);
            _Connection.Close();

            if (_Response.TransactionCompleted)
            {
                if (GenericServices.ReadRecord.ResponseTable.Rows.Count > 0)
                {

                    if (txtUsername.Text == GenericServices.ReadRecord.ResponseTable.Rows[0]["user_name"].ToString())
                    {
                        //do something
                        if (txtPassword.Text == GenericServices.ReadRecord.ResponseTable.Rows[0]["pwd"].ToString())
                        {
                            Session.Add("Username", txtUsername.Text);
                            //redirect user
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
                        lblErrorMessage.Text = "Invalid user name";
                    }
                }
                else
                {

                    lblErrorMessage.Text = "Invalid user name";
                }
            }
            else
            {
                lblErrorMessage.Text = _Response.ResponseMessage;
            }
        }
    }
}