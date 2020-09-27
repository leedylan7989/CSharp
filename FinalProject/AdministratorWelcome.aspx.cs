using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject_RMTApp
{
    public partial class AdministratorWelcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usertype"] == null || !Session["usertype"].Equals("Administrator"))
            {
                Response.Redirect("LoginPage.aspx");
            }

            Label1.Text = "Welcome, " + Session["username"] + "!";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("DiscussionList.aspx");
        }

        protected void btnRequest_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageRequests.aspx");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Session.Remove("usertype");
            Response.Redirect("LoginPage.aspx");
        }
    }
}