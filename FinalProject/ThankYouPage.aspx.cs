using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

namespace FinalProject_RMTApp
{
    public partial class ThankYouPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usertype"] == null || !Session["usertype"].Equals("User"))
            {
                Response.Redirect("LoginPage.aspx");
            }

            if (Session["PaymentCompleted"] == null)
            {
                Response.Redirect("WelcomePage.aspx");
            }

            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            ArrayList arr = (ArrayList)Session["IngameName"];
            for (int i = 0; i < arr.Count; i++)
            {
                DataSet ds = client.SelectWithString("Sellers", "IngameName", arr[i].ToString());
                DataRow row = ds.Tables["Sellers"].Rows[0];

                string gameid = row["GameID"].ToString();

                ds = client.SelectWithString("Games", "GameID", gameid);
                row = ds.Tables["Games"].Rows[0];


                string game = row["GameName"].ToString();



                TextBox1.Text = "";
                TextBox1.Text += game + " items: ";
                TextBox1.Text += Environment.NewLine;
                TextBox1.Text += "Please send a friend request to " + arr[i].ToString()
                    + " and send an ingame message.";
                TextBox1.Text += Environment.NewLine;
                TextBox1.Text += Environment.NewLine;
                TextBox1.Text += "----------------------------------------";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Remove("transactiontype");
            Session.Remove("itemtype");
            if (Session["itemcart"] != null)
                Session.Remove("itemcart");
            if (Session["currencycart"] != null)
                Session.Remove("currencycart");
            if (Session["accountcart"] != null)
                Session.Remove("accountcart");
            if(Session["PaymentCompleted"] != null)
                Session.Remove("PaymentCompleted");
            Session.Remove("totalamount");
            Response.Redirect("WelcomePage.aspx");
        }
    }
}