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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
           

            SqlConnection _Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ado"].ToString());
            _Connection.Open();

            if (hidID.Value == "0" || hidID.Value == "")
            {
                
            }
            else
            {
            }
            _Connection.Close();
            }
       


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                SqlConnection _Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ado"].ToString());
                _Connection.Open();
                string SqlString = "select b.service_choice,  b.service_long_name,  c.price_id, c.price, c.effective_date, c.service_choice, b.enabled from service b, service_price c where b.service_choice = c.service_choice and c.price_id = (select max(price_id) from service_price d where d.service_choice = c.service_choice  and d.effective_date <= getdate()) order by b.service_choice ASC";
                BaseResponse _Response = GenericServices.ReadRecord.ProcessRead(SqlString, _Connection);
                _Connection.Close();

                DataView dv = new DataView(GenericServices.ReadRecord.ResponseTable);
                ItemsList.DataSource = dv;
                ItemsList.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddService");
        }
    }
}