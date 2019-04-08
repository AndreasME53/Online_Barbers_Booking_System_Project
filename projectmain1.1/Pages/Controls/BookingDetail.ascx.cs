using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace projectmain1._1.Pages.Controls
{
    public partial class BookingDetail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                SqlConnection _Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ado"].ToString());
                _Connection.Open();

                string SqlString2 = "select b.service_choice,  b.service_long_name,  c.price_id, c.price, c.effective_date, c.service_choice, b.enabled from service b, service_price c where b.service_choice = c.service_choice and c.price_id = (select max(price_id) from service_price d where d.service_choice = c.service_choice  and d.effective_date <= getdate()) order by b.service_long_name ASC";
                BaseResponse _Response = GenericServices.ReadRecord.ProcessRead(SqlString2, _Connection);
              

                DataTable dt = GenericServices.ReadRecord.ResponseTable;
               
                for(int i=0; i < dt.Rows.Count; i++)
                {
                    ListItem _LI = new ListItem();
                    _LI.Value = dt.Rows[i]["service_choice"].ToString();
                    _LI.Text = dt.Rows[i]["service_long_name"].ToString();

                    lsbService.Items.Add(_LI);
                }
                try
                {
                 
                    string ID = Request.QueryString["id"].ToString();
                    
                    // Change SQL
                    string SqlString = "select a.booking_id,a.booking_date,a.booking_time_hour,a.booking_time_minute,a.first_name, a.last_name,a.mobile_no,a.email_address,a.service_choice,b.service_long_name,  a.created_by,a.date_time_created, a.modified_by,a.date_time_modified,a.price_no, a.enabled from booking a, service b where a.service_choice = b.service_choice and a.booking_id = '" + ID + "'";
                    _Response = GenericServices.ReadRecord.ProcessRead(SqlString, _Connection);
                    _Connection.Close();

                    DataTable DT = GenericServices.ReadRecord.ResponseTable;

                    // hidID.Value = ID;
                    // lsbService.SelectedItem = DT.Rows[0]["service_short_name"].ToString();
                    txtFirstName.Text = DT.Rows[0]["first_name"].ToString();
                    txtLastName.Text = DT.Rows[0]["last_name"].ToString();
                    txtPhone.Text = DT.Rows[0]["mobile_no"].ToString();
                    txtemail.Text = DT.Rows[0]["email_address"].ToString();
                    lblHeading.Text = "View Booking";
                    lsbService.SelectedValue = DT.Rows[0]["service_choice"].ToString();
                    if(DT.Rows[0]["enabled"].ToString() == "T")
                    {
                        chbEnabled.Checked = true;
                       
                    }
                    else
                    {
                        chbEnabled.Checked = false;

                    }
                    chbEnabled.Enabled = true;

                    //  ddlDay.SelectedItem= DT.Rows[0]["service_short_name"].ToString();
                    // ddlMonth.SelectedItem= DT.Rows[0]["service_short_name"].ToString();
                    // ddlTimes.SelectedItem= DT.Rows[0]["service_short_name"].ToString();





                }
                catch
                {
                    divEnabled.Visible = false;
                }

                _Connection.Close();

            }
            if (!this.IsPostBack)
            {
                for (int i = 1; i <= 12; i++)
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
                        case 11:
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


            for (int i = StartHours; i <= EndHours; i++)
            {
                ListItem _LI = new ListItem();
                _LI.Value = i.ToString();
                _LI.Text = i.ToString() + ":00";

                ddlTimes.Items.Add(_LI);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string ID = "";
            try
            {
                ID = Request.QueryString["id"].ToString();
            }
            catch
            {

            }

            if(ID == "")
            {
                //Create
                DateTime DT = DateTime.Parse(ddlMonth.SelectedValue + "-" + ddlDay.SelectedValue + "-" + DateTime.Now.Year.ToString());
                string SqlString = "insert into [booking] (first_name, last_name, mobile_no, email_address, service_choice, booking_date, booking_time_hour, booking_time_minute)";
                SqlString += " values (";
                SqlString += "'" + txtFirstName.Text + "',";
                SqlString += "'" + txtLastName.Text + "',";
                SqlString += "'" + txtPhone.Text + "',";
                SqlString += "'" + txtemail.Text + "',";
                SqlString += "'" + lsbService.SelectedValue + "',";
                SqlString += "'" + DT.ToString("dd-MMM-yyyy") + "',";
                SqlString += "'" + ddlTimes.SelectedValue + "',";
                SqlString += "'00'";
                SqlString += ")";
                SqlConnection _Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ado"].ToString());
                _Connection.Open();

                BaseResponse _Response  = GenericServices.CreateRecord.Processcreate(SqlString, true, _Connection);
                _Connection.Close();

                Response.Redirect("Checkout/?ID=" + _Response.NewID);
            }
            else
            {
                //Update
                //Create
                DateTime DT = DateTime.Parse(ddlDay.SelectedValue + "-" + ddlMonth.SelectedValue + "-" + DateTime.Now.Year.ToString());
                string SqlString = "update  [booking] set ";
                //(first_name, last_name, mobile_no, email_address, service_choice, booking_date, booking_time_hour, booking_time_minute)";
                
                SqlString += "first_name = '" + txtFirstName.Text + "',";
                SqlString += "last_name = '" + txtLastName.Text + "',";
                SqlString += "mobile_no = '" + txtPhone.Text + "',";
                SqlString += " email_address ='" + txtemail.Text + "',";
                SqlString += " service_choice = '" + lsbService.SelectedValue + "',";
                SqlString += " booking_date = '" + DT.ToString("dd-MMM-yyyy") + "',";
                SqlString += " booking_time_hour = '" + ddlTimes.SelectedValue + "',";
                SqlString += " booking_time_minute = '00',";
                SqlString += " enabled = '" + chbEnabled.Checked.ToString().Substring(0, 1).ToUpper() + "'" ;
                SqlString += " where booking_id ='" + ID + "'";

                SqlConnection _Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ado"].ToString());
                _Connection.Open();

                GenericServices.UpdateRecord.ProcessUpdate(SqlString,  _Connection);
                _Connection.Close();

                Response.Redirect("../AdminBookings");
            }
            //for (int i = 0; i < lsbService.Items.Count; i++)
            //{
            //    if (lsbService.Items[i].Selected && lsbService.Items[i].Value != "")
            //    {
            //        Response.Write(lsbService.Items[i].Value + "<br>");


            //        //SqlConnection _Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ado"].ToString());
            //        //_Connection.Open();
            //        //string SqlString = "select first_name from booking a where first_name = '" + txtFirstName.Text + "'";
            //        //BaseResponse _Response = GenericServices.ReadRecord.ProcessRead(SqlString, _Connection);
            //        //_Connection.Close();


            //        //SqlConnection _Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ado"].ToString());
            //        //_Connection.Open();

            //        //string SqlString = "select first_name from booking a where first_name = '" + txtFirstName.Text + "'";

            //        //DataSet ResultDataSet = new DataSet("dataset");
            //        //SqlDataAdapter Adapter = new SqlDataAdapter();
            //        //try
            //        //{
            //        //    Adapter.SelectCommand = new SqlCommand(SqlString, _Connection);
            //        //    Adapter.SelectCommand.CommandTimeout = 600;
            //        //    Adapter.Fill(ResultDataSet);
            //        //}
            //        //catch
            //        //{
            //        //}

            //        //DataTable DT = ResultDataSet.Tables[0];

            //        //_Connection.Close();









            //    }
            //}
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