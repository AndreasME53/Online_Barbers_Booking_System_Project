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
    public partial class BookingAdmin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
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
                   
                    ddlDay.SelectedValue = DateTime.Now.Day.ToString();

                

                    string ID = Request.QueryString["id"].ToString(); 
                    SqlConnection _Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ado"].ToString());
                    _Connection.Open();
                    // change sql
                    string SqlString = "select a.booking_id,a.booking_date,a.booking_time_hour,a.booking_time_minute,a.first_name, a.last_name,a.mobile_no,a.email_address,a.service_choice,b.service_long_name,  a.created_by,a.date_time_created, a.modified_by,a.date_time_modified,a.price_no from booking a, service b where a.service_choice = b.service_choice and a.booking_id ='" + ID + "'";
                    BaseResponse _Response = GenericServices.ReadRecord.ProcessRead(SqlString, _Connection);
                    _Connection.Close();

                    DataTable DT = GenericServices.ReadRecord.ResponseTable;

                    hidID.Value = ID;
                   // lsbService.SelectedItem = DT.Rows[0]["service_long_name"].ToString();
                    txtFirstName.Text = DT.Rows[0]["first_name"].ToString();
                    txtLastName.Text = DT.Rows[0]["last_name"].ToString();
                    txtPhone.Text = DT.Rows[0]["mobile_no"].ToString();
                    txtemail.Text= DT.Rows[0]["email_address"].ToString();
                    lblHeading.Text = "Update Booking";
                    DateTime DTV = DateTime.Parse(DT.Rows[0]["booking_date"].ToString());
                    var item = ddlMonth.Items.FindByValue(DTV.Month.ToString());
                    for (int i = 0; i < ddlMonth.Items.Count; i++)
                    {
                        if (ddlMonth.Items[i].Value == DTV.Month.ToString())
                        {
                            ddlMonth.Items[i].Selected = true;
                        }
                    }
                    PopulateDays(Convert.ToInt32(ddlMonth.SelectedValue));

                    for (int i = 0; i < ddlDay.Items.Count-1; i++)
                    {
                        if (ddlDay.Items[i].Value == DTV.Day.ToString())
                        {
                            ddlDay.Items[i].Selected = true;
                        }
                    }
                   // Populatehours();
                 
                    //ddlMonth.SelectedItem.Value = DTV.Month.ToString();
                    // ddlMonth.SelectedItem= DT.Rows[0]["booking_month"].ToString();



                    for (int i=0; i < ddlTimes.Items.Count; i++)
                    {
                        if (ddlTimes.Items[i].Value == DT.Rows[0]["booking_time_hour"].ToString())
                        {
                            ddlTimes.Items[i].Selected = true;
                        }
                    }
                    
                }
                catch
                {

                }

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
            for (int i = 0; i < lsbService.Items.Count; i++)
            {
                if (lsbService.Items[i].Selected && lsbService.Items[i].Value != "")
                {
                    Response.Write(lsbService.Items[i].Value + "<br>");


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

        protected void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtphone_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtemail_TextChanged(object sender, EventArgs e)
        {

        }

        protected void lsbService_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtProducts_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDays(Convert.ToInt32(ddlMonth.SelectedValue));
        }


        protected void PopulateDays(int Month)
        {
            ddlDay.Items.Clear();
            int days = DateTime.DaysInMonth(DateTime.Now.Year, Month);
            ListItem _LI = new ListItem();
            //_LI.Text = "";
            //_LI.Value = "Select Day";
            //ddlDay.Items.Add(_LI);
            for (int i = 0; i <= days; i++)
            {
                _LI = new ListItem();
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