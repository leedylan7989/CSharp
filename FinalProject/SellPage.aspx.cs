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
    public partial class SellPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
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

            if (Session["itemtype"].Equals("items"))
            {
                Label1.Text = "SELL YOUR ITEMS";
            }
            else if (Session["itemtype"].Equals("currency"))
            {
                Label1.Text = "SELL YOUR CURRENCY";
            }
            else if (Session["itemtype"].Equals("accounts"))
            {
                Label1.Text = "SELL YOUR ACCOUNTS";
            }

            DataSet ds = client.Connect("Games");

            foreach (DataRow row in ds.Tables["Games"].Rows)
            {
                if (ddlGame.Items.FindByText(row["GameName"].ToString()) == null)
                    ddlGame.Items.Add(row["GameName"].ToString());
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Session.Remove("itemtype");
            Response.Redirect("Selection.aspx");
        }

        protected void ddlGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnProceed.Visible = true;
            if (!ddlGame.SelectedValue.Equals("Please select a game"))
            {
                if (Session["itemtype"].Equals("items"))
                {
                    tradeForm.Visible = true;
                }
                else if (Session["itemtype"].Equals("currency"))
                {
                    ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
                    DataSet ds = client.SelectWithString("Games", "GameName", ddlGame.SelectedValue.ToString());
                    string gameid = ds.Tables["Games"].Rows[0]["GameID"].ToString();
                    ds = client.SelectWithString("Currency", "GameID", gameid);

                    ddlCurrencyType.Items.Clear();
                    foreach(DataRow row in ds.Tables["Currency"].Rows)
                    {
                        ddlCurrencyType.Items.Add(row["CurrencyName"].ToString());
                    }

                    tradeFormCurrency.Visible = true;
                }
                else if (Session["itemtype"].Equals("accounts"))
                {
                    tradeFormAccounts.Visible = true;
                }
            } else
            {
                tradeForm.Visible = false;
                tradeFormCurrency.Visible = false;
                tradeFormAccounts.Visible = false;
            }
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = "server=(local);Database=FinalProjectDB;Integrated Security=SSPI";
                con.Open();
                if (Session["itemtype"].Equals("items"))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO ItemSellRequest (UserID, ItemName, DesiredPrice," +
                        "GameID) VALUES (@UserID, @ItemName, @DesiredPrice," +
                        "@GameID)", con);

                    cmd.Parameters.AddWithValue("@UserID", Session["userid"].ToString());
                    cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text);
                    cmd.Parameters.AddWithValue("@DesiredPrice", txtDesiredPrice.Text);

                    DataSet ds = client.SelectWithString("Games", "GameName", ddlGame.SelectedValue.ToString());

                    cmd.Parameters.AddWithValue("@GameID", ds.Tables["Games"].Rows[0]["GameID"].ToString());

                    cmd.ExecuteNonQuery();

                    Session["Itemname"] = txtItemName.Text;
                    Session["DesiredPrice"] = txtDesiredPrice.Text;


                }
                else if (Session["itemtype"].Equals("currency"))
                {
                    DataSet ds = client.SelectWithString("Games", "GameName", ddlGame.SelectedValue.ToString());
                    string gameid = ds.Tables["Games"].Rows[0]["GameID"].ToString();

                    ds = client.SelectWithString("Currency", "GameID", gameid);
                    DataRow row = null;

                    foreach(DataRow currency in ds.Tables["Currency"].Rows)
                    {
                        if (currency["CurrencyName"].ToString().Equals(ddlCurrencyType.SelectedValue.ToString())) { 
                            row = currency;
                        }
                    }
                    
                    //Adding new currency
                    double newAmount = Convert.ToDouble(row["Amount"].ToString()) + Convert.ToDouble(txtAmount.Text);
                    double rate = Convert.ToDouble(row["PricePerUnit"].ToString());

                    client.UpdateWithDouble("Currency", "Amount", newAmount,
                        "CurrencyID", row["CurrencyID"].ToString());

                    //Adding payment to user account
                    double addAmount = Convert.ToDouble(Session["UserAmount"].ToString()) + 
                        rate * Convert.ToDouble(txtAmount.Text);

                    client.UpdateWithDouble("Users", "Amount", addAmount, 
                        "UserID", Session["userid"].ToString());

                    Session["addAmount"] = (rate * Convert.ToDouble(txtAmount.Text)).ToString();
                }
                else if (Session["itemtype"].Equals("accounts"))
                {
                    DataSet ds = client.SelectWithString("Games", "GameName", ddlGame.SelectedValue.ToString());
                    string gameid = ds.Tables["Games"].Rows[0]["GameID"].ToString();

                    SqlCommand cmd = new SqlCommand("INSERT INTO AccountsSellRequest (UserID, Username, " +
                        "Password, Detail, DesiredPrice, GameID) VALUES (@UserID, @Username, " +
                        "@Password, @Detail, @DesiredPrice, @GameID)", con);

                    cmd.Parameters.AddWithValue("@UserID", Session["userid"].ToString());
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.ToString());
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@Detail", txtDetail.Text);
                    cmd.Parameters.AddWithValue("@DesiredPrice", txtAccountPrice.Text);
                    cmd.Parameters.AddWithValue("@GameID", gameid);

                    cmd.ExecuteNonQuery();

                    Session["Accountname"] = txtUsername.Text.ToString();
                    Session["Detail"] = txtDetail.Text;
                    Session["DesiredPrice"] = txtAccountPrice.Text;
                }
            }
            Response.Redirect("SellConfirmationPage.aspx");
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            labelPayment.Visible = true;
            txtPayment.Visible = true;

            string currencyType = ddlCurrencyType.SelectedValue;


            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            DataSet ds = client.SelectWithString("Currency", "CurrencyName", currencyType);

            string rateString = ds.Tables["Currency"].Rows[0]["PricePerUnit"].ToString();
            double rate = Convert.ToDouble(rateString);

            double price = Convert.ToDouble(txtAmount.Text) * rate;

            txtPayment.Text = price.ToString("C");
        }
    }
}