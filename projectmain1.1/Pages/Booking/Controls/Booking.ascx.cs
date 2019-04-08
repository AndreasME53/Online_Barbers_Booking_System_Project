using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace projectmain1._1.Pages.Booking.Controls
{
    public partial class Booking : System.Web.UI.UserControl
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
                    // Change SQL
                    string SqlString = "select b.service_choice,  b.service_short_name, b.service_long_name,  c.price_id, c.price, c.effective_date, c.service_choice from service b, service_price c where b.service_choice = c.service_choice and c.price_id = (select max(price_id) from service_price d where d.service_choice = c.service_choice  and d.effective_date <= getdate()) and b.service_choice = '" + ID + "'";
                    BaseResponse _Response = GenericServices.ReadRecord.ProcessRead(SqlString, _Connection);
                    _Connection.Close();

                    DataTable DT = GenericServices.ReadRecord.ResponseTable;

                   // hidID.Value = ID;
                    // lsbService.SelectedItem = DT.Rows[0]["service_short_name"].ToString();
                    txtFirstName.Text = DT.Rows[0]["first_name"].ToString();
                    txtLastName.Text = DT.Rows[0]["last_name"].ToString();
                    txtPhone.Text = DT.Rows[0]["mobile_no"].ToString();
                    txtemail.Text = DT.Rows[0]["email_address"].ToString();
                    lblHeading.Text = "View Booking";
                    //  ddlDay.SelectedItem= DT.Rows[0]["service_short_name"].ToString();
                    // ddlMonth.SelectedItem= DT.Rows[0]["service_short_name"].ToString();
                    // ddlTimes.SelectedItem= DT.Rows[0]["service_short_name"].ToString();



                    SqlConnection con = new SqlConnection("Data Source=.;Initial Caalog=PAVALAM;Integrated Security=True; ");
                    SqlDataAdapter sda = new SqlDataAdapter("select b.service_choice,  b.service_long_name,  c.price_id, c.price, c.effective_date, c.service_choice, b.enabled from service b, service_price c where b.service_choice = c.service_choice and c.price_id = (select max(price_id) from service_price d where d.service_choice = c.service_choice  and d.effective_date <= getdate()) order by b.service_choice ASC",con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        lsbService.Items.Add(row["b.service_choice,  b.service_long_name, c.price,  b.enabled"].ToString());
                    }

                }
                catch
                {

                }

            }
            if (!this.IsPostBack)
            {
                for(int i=1; i <= 12; i++)
                {
                  
                    ListItem _LI = new ListItem();
                    _LI.Value = i.ToString();
                    _LI.Text = i.ToString();


                    switch (i)
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
                        case 111:
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

               
                ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
                PopulateDays(Convert.ToInt32(ddlMonth.SelectedValue));
                ddlDay.SelectedValue = DateTime.Now.Day.ToString();

                Populatehours();

            }
        }

        protected void Populatehours()
        {
            ddlTimes.Items.Clear();

            DayOfWeek DayOfTheWeek = DateTime.Parse(ddlDay.SelectedValue.ToString() + "-" + ddlMonth.SelectedItem.Text.ToString() + "-" + DateTime.Now.Year.ToString()).DayOfWeek;
            int StartHours;
            int EndHours;
            if (DayOfTheWeek == DayOfWeek.Saturday)
            {
                StartHours = 9;
                EndHours = 18;
            }
            else
            {
                if (DayOfTheWeek == DayOfWeek.Sunday)
                {
                    StartHours = 10;
                    EndHours = 18;
                }
                else
                {
                    StartHours = 9;
                    EndHours = 19;
                }
            }


            for (int i= StartHours; i <= EndHours; i++ )
            {
                ListItem _LI = new ListItem();
                _LI.Value = i.ToString();
                _LI.Text = i.ToString() + ":00";

                ddlTimes.Items.Add(_LI);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsbService.Items.Count; i++)
            {
               if (lsbService.Items[i].Selected && lsbService.Items[i].Value != "")
                {
                    Response.Write(lsbService.Items[i].Value + "<br>");

                    Response.Redirect("CheckOut");
                    //SqlConnection _Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ado"].ToString());
                    //_Connection.Open();
                    //string SqlString = "select first_name from booking a where first_name = '" + txtFirstName.Text + "'";
                    //BaseResponse _Response = GenericServices.ReadRecord.ProcessRead(SqlString, _Connection);
                    //_Connection.Close();


                    //SqlConnection _Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ado"].ToString());
                    //_Connection.Open();

                    //string SqlString = "select first_name from booking a where first_name = '" + txtFirstName.Text + "'";

                    //DataSet ResultDataSet = new DataSet("dataset");
                    //SqlDataAdapter Adapter = new SqlDataAdapter();
                    //try
                    //{
                    //    Adapter.SelectCommand = new SqlCommand(SqlString, _Connection);
                    //    Adapter.SelectCommand.CommandTimeout = 600;
                    //    Adapter.Fill(ResultDataSet);
                    //}
                    //catch
                    //{
                    //}

                    //DataTable DT = ResultDataSet.Tables[0];

                    //_Connection.Close();









                }
            }
        }

        

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDays(Convert.ToInt32(ddlMonth.SelectedValue));
        }


        protected void PopulateDays(int Month)
        {
            ddlDay.Items.Clear();
            int days = DateTime.DaysInMonth(DateTime.Now.Year, Month);

            for (int i = 1; i <= days; i++)
            {
                ListItem _LI = new ListItem();
                _LI.Text = i.ToString();
                _LI.Value = i.ToString();
                ddlDay.Items.Add(_LI);
            }
        }

        protected void ddlDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            Populatehours();
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            Response.Write(ddlProduct.SelectedValue);
        }

      
    }
}