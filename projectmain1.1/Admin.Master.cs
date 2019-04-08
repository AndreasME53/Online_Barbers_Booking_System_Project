using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectmain1._1
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session.Contents["Username"].ToString() == "" || Session.Contents["Username"] == null)
                {
                    Response.Redirect("MilasBarbersAdmin");
                }
            }
            catch
            {
                Response.Redirect("MilasBarbersAdmin");
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Contents.Clear();
            Response.Redirect("MilasBarbersAdmin");
        }
    }
}