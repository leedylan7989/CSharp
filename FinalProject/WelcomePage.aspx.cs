using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject_RMTApp
{
    public partial class WelcomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usertype"] == null || !Session["usertype"].Equals("User"))
            {
                Response.Redirect("LoginPage.aspx");

            }
            welcomeLabel.Text = "Welcome, " + Session["username"] + "!";
        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            Session["transactiontype"] = "buy";
            Response.Redirect("Selection.aspx");
        }

        protected void btnSell_Click(object sender, EventArgs e)
        {
            Session["transactiontype"] = "sell";
            Response.Redirect("Selection.aspx");
        }

        protected void btnForum_Click(object sender, EventArgs e)
        {
            Response.Redirect("DiscussionList.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("usertype");
            Response.Redirect("LoginPage.aspx");
        }
    }
}