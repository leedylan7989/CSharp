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
    public partial class PaymentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usertype"] == null || !Session["usertype"].Equals("User"))
            {
                Response.Redirect("LoginPage.aspx");

            }

            if (Session["itemcart"] != null)
            {
                if (((ArrayList)Session["itemcart"]).Count <= 0)
                    Response.Redirect("BuyItems.aspx");
                else
                    itemsTotal();
            }
            else if (Session["currencycart"] != null)
            {
                currencyTotal();
            }
            else if (Session["accountcart"] != null)
            {
                accountsTotal();
            }
            else
            {
                Response.Redirect("WelcomePage.aspx");
            }
        }

        private void accountsTotal()
        {
            ArrayList arr = (ArrayList)Session["accountcart"];
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();


            tbItemList.Text = "";

            double price = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                DataSet ds = client.SelectWithString("Accounts", "AccountID", arr[i].ToString());
                DataRow row = ds.Tables["Accounts"].Rows[0];
                tbItemList.Text += row["Username"] + ": $" + row["Price"];
                tbItemList.Text += Environment.NewLine;
                price += Convert.ToDouble(row["Price"].ToString());
            }
            tbItemList.Text += "-------------------------------------------------";
            tbItemList.Text += Environment.NewLine;
            tbItemList.Text += "Total: $" + price;
            tbItemList.Text += Environment.NewLine;
            tbItemList.Text += "-------------------------------------------------";
            tbItemList.Text += Environment.NewLine;
            double useramount = Convert.ToDouble(Session["UserAmount"].ToString());
            tbItemList.Text += "Amount you currently have: $" + useramount;
            tbItemList.Text += Environment.NewLine;
            tbItemList.Text += "Amount after this transaction: $" + (useramount - price);
            Session["left"] = useramount - price;
        }

        private void currencyTotal()
        {
            ArrayList arr = (ArrayList)Session["currencycart"];
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

            tbItemList.Text = "";

            double totalprice = Convert.ToDouble(Session["totalamount"].ToString());

            for(int i = 0; i < arr.Count; i++)
            {
                string priceString = arr[i].ToString().Split(' ')[0];
                string amountString = arr[i].ToString().Split(' ')[1];
                string currencyName = arr[i].ToString().Split(' ')[2];

                tbItemList.Text += amountString + " " + currencyName + ": " + "$" + priceString;
                tbItemList.Text += Environment.NewLine;
            }

            tbItemList.Text += Environment.NewLine;
            tbItemList.Text += "-------------------------------------------";
            tbItemList.Text += Environment.NewLine;
            tbItemList.Text += "Total Price: $" + totalprice;
            tbItemList.Text += "-------------------------------------------";
            tbItemList.Text += Environment.NewLine;
            double useramount = Convert.ToDouble(Session["UserAmount"].ToString());
            tbItemList.Text += "The amount you have: " + useramount.ToString();
            tbItemList.Text += Environment.NewLine;
            tbItemList.Text += "The amount left after this transaction: " + (useramount - totalprice).ToString();
            Session["left"] = (useramount - totalprice).ToString();

        }

        private void itemsTotal()
        {
            ArrayList arr = (ArrayList)Session["itemcart"];
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();


            tbItemList.Text = "";

            double price = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                DataSet ds = client.SelectWithString("Items", "ItemID", arr[i].ToString());
                DataRow row = ds.Tables["Items"].Rows[0];
                tbItemList.Text += row["ItemName"] + ": $" + row["Price"];
                tbItemList.Text += Environment.NewLine;
                price += Convert.ToDouble(row["Price"].ToString());
            }
            tbItemList.Text += "-------------------------------------------------";
            tbItemList.Text += Environment.NewLine;
            tbItemList.Text += "Total: $" + price;
            tbItemList.Text += Environment.NewLine;
            tbItemList.Text += "-------------------------------------------------";
            tbItemList.Text += Environment.NewLine;
            double useramount = Convert.ToDouble(Session["UserAmount"].ToString());
            tbItemList.Text += "Amount you currently have: $" + useramount;
            tbItemList.Text += Environment.NewLine;
            tbItemList.Text += "Amount after this transaction: $" + (useramount- price);
            Session["left"] = useramount - price;
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            if (Session["itemtype"] != null && Session["itemtype"].Equals("items"))
            {
                itemsPurchase();
            } else if (Session["itemtype"].Equals("currency"))
            {
                currencyPurchase();
            }
            else if (Session["itemtype"].Equals("accounts"))
            {
                accountsPurchase();
            }
        }

        private void accountsPurchase()
        {
            ArrayList arr = (ArrayList)Session["accountcart"];
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            Session["IngameName"] = new ArrayList();
            for (int i = 0; i < arr.Count; i++)
            {
                DataSet ds = client.SelectWithString("Accounts", "AccountID", arr[i].ToString());
                DataRow row = ds.Tables["Accounts"].Rows[0];



                string userid = Session["userid"].ToString();
                string detail = row["Username"].ToString();
                string price = row["Price"].ToString();

                ds = client.SelectWithString("Games", "GameID", row["GameID"].ToString());
                row = ds.Tables["Games"].Rows[0];


                string game = row["GameName"].ToString();

                detail += " " + game;



                ds = client.SelectWithString("Sellers", "GameID", row["GameID"].ToString());
                row = ds.Tables["Sellers"].Rows[0];


                if (!((ArrayList)Session["IngameName"]).Contains(row["IngameName"].ToString()))
                    ((ArrayList)Session["IngameName"]).Add(row["IngameName"].ToString());

                if (client.InsertTransactionBuy(userid, price, detail, row["SellerID"].ToString()))
                {
                    client.DeleteByID("Accounts", "AccountID", arr[i].ToString());
                }

            }

            client.UpdateWithField("Users", "Amount", Session["left"].ToString(), "UserID",
                            Session["userid"].ToString());
            Session["UserAmount"] = Session["left"];
            Session["PaymentCompleted"] = "true";
            Response.Redirect("ThankYouPage.aspx");
        }

        private void currencyPurchase()
        {
            ArrayList arr = (ArrayList)Session["currencycart"];
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

            Session["IngameName"] = new ArrayList();
            
            for(int i = 0; i < arr.Count; i++)
            {
                string cName = arr[i].ToString().Split(' ')[2];
                string amountString = arr[i].ToString().Split(' ')[1];
                string priceString = arr[i].ToString().Split(' ')[0];
                double price = Convert.ToDouble(priceString);
                string detail = amountString + " " + cName;

                DataSet ds = client.SelectWithString("Currency", "CurrencyName", cName);
                DataRow row = ds.Tables["Currency"].Rows[0];

                double amountInStock = Convert.ToDouble(row["Amount"].ToString());
                double newAmount = amountInStock - Convert.ToDouble(amountString);
                client.UpdateWithField("Currency", "CurrencyName", cName, "Amount", newAmount.ToString());

                DataSet dsSeller = client.SelectWithString("Sellers", "GameID", row["GameID"].ToString());
                row = dsSeller.Tables["Sellers"].Rows[0];

                if (!((ArrayList)Session["IngameName"]).Contains(row["IngameName"].ToString()))
                    ((ArrayList)Session["IngameName"]).Add(row["IngameName"].ToString());

                string userid = Session["userid"].ToString();
                client.InsertTransactionBuy(userid, price.ToString(), detail, row["SellerID"].ToString());
            }
            client.UpdateWithDouble("Users", "Amount", Convert.ToDouble(Session["left"].ToString()), "UserID",
                            Session["userid"].ToString());
            Session["UserAmount"] = Session["left"];
            Session["PaymentCompleted"] = "true";
            Response.Redirect("ThankYouPage.aspx");
        }

        private void itemsPurchase()
        {
            ArrayList arr = (ArrayList)Session["itemcart"];
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            Session["IngameName"] = new ArrayList();
            for (int i = 0; i < arr.Count; i++)
            {
                DataSet ds = client.SelectWithString("Items", "ItemID", arr[i].ToString());
                DataRow row = ds.Tables["Items"].Rows[0];



                string userid = Session["userid"].ToString();
                string detail = row["ItemName"].ToString();
                string price = row["Price"].ToString();

                ds = client.SelectWithString("Games", "GameID", row["GameID"].ToString());
                row = ds.Tables["Games"].Rows[0];


                string game = row["GameName"].ToString();

                detail += " " + game;



                ds = client.SelectWithString("Sellers", "GameID", row["GameID"].ToString());
                row = ds.Tables["Sellers"].Rows[0];


                if (!((ArrayList)Session["IngameName"]).Contains(row["IngameName"].ToString()))
                    ((ArrayList)Session["IngameName"]).Add(row["IngameName"].ToString());

                if (client.InsertTransactionBuy(userid, price, detail, row["SellerID"].ToString()))
                {
                    client.DeleteByID("Items", "ItemID", arr[i].ToString());
                }
                
            }

            client.UpdateWithField("Users", "Amount", Session["left"].ToString(), "UserID",
                            Session["userid"].ToString());
            Session["UserAmount"] = Session["left"];
            Session["PaymentCompleted"] = "true";
            Response.Redirect("ThankYouPage.aspx");

        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuyItems.aspx");
        }
    }
}