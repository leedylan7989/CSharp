using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject_RMTApp
{
    public partial class GameSelection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usertype"] == null || !Session["usertype"].Equals("User"))
            {
                Response.Redirect("LoginPage.aspx");

            }
            if(Session["transactiontype"] == null)
            {
                Response.Redirect("WelcomePage.aspx");
            }
            Label1.Text = "Select what you want to " + Session["transactiontype"];
        }

        protected void btnCurrency_Click(object sender, EventArgs e)
        {
            Session["itemtype"] = "currency";
            if (Session["transactiontype"].Equals("buy"))
                Response.Redirect("BuyItems.aspx");
            else
                Response.Redirect("SellPage.aspx");
        }

        protected void btnItems_Click(object sender, EventArgs e)
        {
            Session["itemtype"] = "items";
            if (Session["transactiontype"].Equals("buy"))
                Response.Redirect("BuyItems.aspx");
            else
                Response.Redirect("SellPage.aspx");
        }

        protected void btnAccounts_Click(object sender, EventArgs e)
        {
            Session["itemtype"] = "accounts";
            if (Session["transactiontype"].Equals("buy"))
                Response.Redirect("BuyItems.aspx");
            else
                Response.Redirect("SellPage.aspx");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Session.Remove("transactiontype");
            Response.Redirect("WelcomePage.aspx");
        }
    }
}