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
            if (!this.IsPostBack)
            {
                try
                {
                    string ID = Request.QueryString["id"].ToString();
                    SqlConnection _Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ado"].ToString());
                    _Connection.Open();
                    string SqlString = "select b.service_choice,  b.service_short_name, b.service_long_name,  c.price_id, c.price, c.effective_date, c.service_choice, b.enabled, b.effective_date[service_date] from service b, service_price c where b.service_choice = c.service_choice and c.price_id = (select max(price_id) from service_price d where d.service_choice = c.service_choice  and d.effective_date <= getdate()) and b.service_choice = '" + ID + "'"; 
                    BaseResponse _Response = GenericServices.ReadRecord.ProcessRead(SqlString, _Connection);
                    _Connection.Close();

                    DataTable DT = GenericServices.ReadRecord.ResponseTable;

                    hidID.Value = ID;
                    txtServiceNameShort.Text = DT.Rows[0]["service_short_name"].ToString();
                    txtServiceNameMain.Text = DT.Rows[0]["service_long_name"].ToString();
                    txtPrice.Text = DT.Rows[0]["price"].ToString();


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
                catch
                {

                }
               
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection _Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ado"].ToString());
            _Connection.Open();

            if (hidID.Value == "0" || hidID.Value == "")
            {
                string SqlString = "Insert into Service(service_long_name,service_short_name,effective_date,created_by,enabled) values('" + txtServiceNameMain.Text + "','" + txtServiceNameShort.Text + "','" + txtEffectiveDate.SelectedDate.ToString("dd-MMM-yyyy") + "','" + txtCreatedBy.Text + "','" + chbEnabled.Checked.ToString().Substring(0, 1).ToUpper() + "') ";

                BaseResponse _Response = GenericServices.CreateRecord.Processcreate(SqlString, true, _Connection);

                string SqlString1 = "Insert into Service_price(service_choice, effective_date,price,created_by,enabled) values('" + _Response.NewID + "','" + txtEffectiveDate.SelectedDate.ToString("dd-MMM-yyyy") + "','" + txtPrice.Text + "','" + txtCreatedBy.Text + "','" + chbEnabled.Checked.ToString().Substring(0, 1).ToUpper() + "')";


                _Response = GenericServices.CreateRecord.Processcreate(SqlString1, true, _Connection);
            }
            else
            {
                //Update goes here
                string SqlString = " update ";
                SqlString += " service set ";
                SqlString += " service_long_name = '" + txtServiceNameMain.Text.ToString().Replace("'", "''") + "',";
                SqlString += " service_short_name='" + txtServiceNameShort.Text.ToString().Replace("'", "''") + "',";
                SqlString += " enabled='" + chbEnabled.Checked.ToString().Substring(0,1).ToUpper() + "'";
                SqlString += " where service_choice ='" + hidID.Value + "'";
                                             
                BaseResponse _Response = GenericServices.UpdateRecord.ProcessUpdate(SqlString, _Connection);
            }

            _Connection.Close();

            Response.Redirect("~/pages/admin/services");
        }

       
        

    }
}