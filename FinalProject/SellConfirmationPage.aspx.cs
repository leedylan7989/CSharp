using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace FinalProject_RMTApp
{
    public partial class SellConfirmationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usertype"] == null || !Session["usertype"].Equals("User"))
            {
                Response.Redirect("LoginPage.aspx");

            }
            if (Session["transactiontype"] == null && !Session["transactiontype"].Equals("sell"))
            {
                Response.Redirect("WelcomePage.aspx");
            }
            if (Session["itemtype"] == null)
            {
                Response.Redirect("Selection.aspx");
            }
            if(Session["itemtype"].Equals("currency") && Session["addAmount"] == null)
            {
                Response.Redirect("SellPage.aspx");
            }

            if (Session["itemtype"].ToString().Equals("items") || Session["itemtype"].ToString().Equals("accounts"))
            {
                linkDiv.Visible = true;
                if (Session["itemtype"].ToString().Equals("items"))
                    labelLink.Text = "Your item is waiting for a confirmation from an administrator. Please " +
                            "follow the link and discuss for the price. Thank you.";
                else
                    labelLink.Text = "Your account is waiting for a confirmation from an administrator. Please " +
                            "follow the link and discuss for the price. Thank you.";
                LiteralControl line = new LiteralControl("<br/><br/>");

                LinkButton link = new LinkButton();
                link.Click += new EventHandler(linkButton_Click);
                link.Text = "Click this link";
                
                using(SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = "server=(local);Database=FinalProjectDB;Integrated Security=SSPI";
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Discussions (UserID, Title, Detail, Private)" +
                        " VALUES (@UserID, @Title, @Detail, @Private)", con);

                    string detail = "";

                    cmd.Parameters.AddWithValue("@UserID", "2");
                    cmd.Parameters.AddWithValue("@Title", "PRICE DISCUSSION: " + Session["username"].ToString());
                    if (Session["itemtype"].ToString().Equals("items")) {
                        detail = "Item Name: " + Session["Itemname"].ToString() +
                            "|Desired Price: " + Session["DesiredPrice"].ToString();
                        cmd.Parameters.AddWithValue("@Detail", detail);
                    }
                    else
                    {
                        detail = "Username: " + Session["Accountname"].ToString() +
                            "|Detail: " + Session["Detail"].ToString() + "|Desired Price: " +
                            Session["DesiredPrice"].ToString();
                        cmd.Parameters.AddWithValue("@Detail", detail);

                    }
                    cmd.Parameters.AddWithValue("@Private", "Yes");

                    Session["details"] = detail;

                    cmd.ExecuteNonQuery();

                }
                

                linkDiv.Controls.Add(line);
                linkDiv.Controls.Add(link);
                
                

            } else
            {
                currency.Visible = true;
                labelCurrency.Text = "Your currency is sold. " + Session["addAmount"].ToString() + 
                    " has been added to your account.";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Remove("itemtype");
            Session.Remove("transactiontype");
            if (Session["addAmount"] != null)
                Session.Remove("addAmount");
            Session.Remove("details");
            Session.Remove("Itemname");
            Session.Remove("DesiredPrice");
            
            Session.Remove("Detail");
            Session.Remove("DesiredPrice");
            Response.Redirect("WelcomePage.aspx");
        }

        private string findID()
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

            DataSet ds = client.SelectWithString("Discussions", "Detail", Session["details"].ToString());


            return ds.Tables["Discussions"].Rows[0]["DiscussionID"].ToString();
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {

            Session["DiscussionID"] = findID();

            Session["SellConfirmationPage"] = "Yes";
            Response.Redirect("Discussion.aspx");
        }
    }
}