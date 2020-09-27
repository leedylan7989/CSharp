using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FinalProject_RMTApp
{
    public partial class Buy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usertype"] == null || !Session["usertype"].Equals("User"))
            {
                Response.Redirect("LoginPage.aspx");
            }
            if (!Session["transactiontype"].Equals("buy"))
            {
                Response.Redirect("WelcomePage.aspx");
            }
            if (Session["itemtype"]==null)
            {
                Response.Redirect("Selection.aspx");
            }

            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            DataSet ds = client.Connect("Games");
            DataTable table = ds.Tables["Games"];

            foreach (DataRow row in table.Rows)
            {
                if (!ddlSelection.Items.Contains(new ListItem(row["GameName"].ToString())))
                    ddlSelection.Items.Add(row["GameName"].ToString());
            }
            labelRMT.Text = Session["UserAmount"].ToString();

            if (Session["itemtype"].Equals("accounts"))
            {
                labelTitle.Text = "ACCOUNT PURCHASE";
            } else if (Session["itemtype"].Equals("currency"))
            {
                labelTitle.Text = "INGAME CURRENCY PURCHASE";
            }

        }

        protected void ddlSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            DataSet ds = new DataSet();
            string id = "0";
            if (ddlSelection.SelectedValue.Equals("Please select a game"))
            {
                GridView1.Visible = false;
                ddlItems.Visible = false;
                btnCart.Visible = false;
                btnPurchase.Visible = false;
                txtCart.Visible = false;
                btnRemove.Visible = false;
                btnClear.Visible = false;
                ddlRemove.Visible = false;
            }
            else
            {
                ds = client.SelectWithString("Games", "GameName", ddlSelection.SelectedValue);
                id = ds.Tables["Games"].Rows[0]["GameID"].ToString();
            }

            DataTable dt = new DataTable();
            if (ds != null && Session["itemType"].Equals("items"))
            {
                //Items
                dt = itemsGridView(client, ds, id);
            }
            else if (ds != null && Session["itemType"].Equals("currency"))
            {
                //Currency
                ds = client.SelectWithString("Currency", "GameID", id);
                //There will be only one row in the returned datatable
                DataRow row = ds.Tables["Currency"].Rows[0];
                string amount = row["Amount"].ToString() + " " + row["CurrencyName"].ToString();
                string rate = "Price per " + row["CurrencyName"].ToString();

                dt.Columns.Add("Amount we have", typeof(string));
                dt.Columns.Add(rate, typeof(string));

                DataRow currency = dt.NewRow();
                currency["Amount we have"] = amount;
                currency[rate] = "$" + row["PricePerUnit"].ToString();
                dt.Rows.Add(currency);

                //Add currency items to ddlItems
                ddlItems.Items.Clear();

                double numrate = Convert.ToDouble(row["PricePerUnit"].ToString());
                ddlItems.Items.Add("$5.00:" + ((100.00 * 5.0) / numrate) + " " + row["CurrencyName"].ToString());
                ddlItems.Items.Add("$10.00:" + ((100.00 * 10.0) / numrate) + " " + row["CurrencyName"].ToString());
                ddlItems.Items.Add("$20.00:" + ((100.00 * 20.0) / numrate) + " " + row["CurrencyName"].ToString());
                ddlItems.Items.Add("$25.00:" + ((100.00 * 25.0) / numrate) + " " + row["CurrencyName"].ToString());
                ddlItems.Items.Add("$50.00:" + ((100.00 * 50.0) / numrate) + " " + row["CurrencyName"].ToString());
                ddlItems.Items.Add("$100.00:" + ((100.00 * 100.0) / numrate) + " " + row["CurrencyName"].ToString());
            }
            else if (ds != null && Session["itemType"].Equals("accounts"))
            {
                //Accounts
                ds = client.SelectWithString("Accounts", "GameID", id);

                dt = ds.Tables["Accounts"];

                ddlItems.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    ddlItems.Items.Add(row["AccountID"].ToString() + "|" + row["Username"].ToString() + "|$"
                        + row["Price"].ToString());
                }

                //Columns must be deleted from the back.
                //Deleting a colum  changes the indexes of columns
                //Remove ID column
                dt.Columns.RemoveAt(4);
                //Remove the password column
                dt.Columns.RemoveAt(2);
                //Remove ID column
                dt.Columns.RemoveAt(0);
            }

            //Show the grid view and a drop down list of items
            if (ds != null && !ddlSelection.SelectedValue.Equals("Please select a game"))
            {
                GridView1.Visible = true;
                GridView1.DataSource = dt;
                GridView1.DataBind();

                ddlItems.Visible = true;

                btnCart.Visible = true;
            }


        }

        private DataTable itemsGridView(ServiceReference1.Service1Client client, DataSet ds, string id)
        {
            ds = client.SelectWithString("Items", "GameID", id);

            DataTable dt = ds.Tables["Items"];

            ddlItems.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                ddlItems.Items.Add(row["ItemID"].ToString() + "|" + row["ItemName"].ToString() + "|$"
                    + row["Price"].ToString());
            }

            dt.Columns.RemoveAt(3);
            dt.Columns.RemoveAt(0);
            return dt;
        }

        protected void ddlItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelInCart.Visible = false;
            if (ddlItems.SelectedValue.Equals("Please select an item"))
            {
                btnCart.Visible = false;
                btnPurchase.Visible = false;
            }
            else
            {
                btnCart.Visible = true;
                btnPurchase.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["itemcart"] != null && ((ArrayList)Session["itemcart"]).Count > 0 ||
                Session["currencycart"] != null && ((ArrayList)Session["currencycart"]).Count > 0 ||
                Session["accountcart"] != null && ((ArrayList)Session["accountcart"]).Count > 0)
            {
                if (Convert.ToDouble(labelRMT.Text) < Convert.ToDouble(labelTotal.Text))
                {
                    Label3.Visible = true;
                }
                else
                {
                    Session["totalamount"] = Convert.ToDouble(labelTotal.Text.ToString());
                    Response.Redirect("PaymentPage.aspx");
                }
            }
            else
                Label2.Visible = true;
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {
            Label2.Visible = false;
            btnPurchase.Visible = true;
            //If a user added an item to the cart
            if (Session["itemtype"].Equals("items"))
            {
                string id = ddlItems.SelectedValue.Split('|')[0];
                string name = ddlItems.SelectedValue.Split('|')[1];
                string p = ddlItems.SelectedValue.Split('|')[2];
                double price = Convert.ToDouble(p.Substring(1, p.Length - 1));
                if (Session["itemcart"] != null && ((ArrayList)Session["itemcart"]).Contains(id))
                {
                    labelInCart.Text = "Item #" + id + " is already in your cart!";
                    labelInCart.Visible = true;
                }
                else
                {
                    if (Session["itemcart"] == null)
                    {
                        ArrayList list = new ArrayList();
                        list.Add(id);
                        Session["itemcart"] = list;
                        txtCart.Text = "Item #" + id + " " + name;
                        ddlRemove.Items.Add(id);
                        labelTotal.Text = (Convert.ToDouble(labelTotal.Text) + price).ToString();
                    }
                    else
                    {
                        ArrayList list = (ArrayList)Session["itemcart"];
                        list.Add(id);
                        Session["itemcart"] = list;
                        txtCart.Text += ", Item #" + id + " " + name;
                        ddlRemove.Items.Add(id);
                        labelTotal.Text = (Convert.ToDouble(labelTotal.Text) + price).ToString();
                    }
                }
            }else if (Session["itemtype"].Equals("currency"))
            {
                string[] arr1 = ddlItems.SelectedValue.Split(':');
                string priceString = arr1[0].Substring(1, arr1[0].Length-1);
                double price = Convert.ToDouble(priceString);
                string amount = arr1[1].Split(' ')[0];
                string currencyname = arr1[1].Split(' ')[1];

                ArrayList list = new ArrayList();
                if (Session["currencycart"] != null)
                {
                    list = (ArrayList)Session["currencycart"];
                }

                list.Add(priceString + " " + amount + " " + currencyname);
                if (Session["currencycart"] == null)
                    txtCart.Text = ddlItems.SelectedValue;
                else
                {
                    txtCart.Text += Environment.NewLine;
                    txtCart.Text += ddlItems.SelectedValue;
                }
                Session["currencycart"] = list;
                ddlRemove.Items.Add(amount + " " + arr1[1].Split(' ')[1]);
                labelTotal.Text = (Convert.ToDouble(labelTotal.Text) + price).ToString();
            }
            else if (Session["itemtype"].Equals("accounts"))
            {
                string id = ddlItems.SelectedValue.Split('|')[0];
                string username = ddlItems.SelectedValue.Split('|')[1];
                string p = ddlItems.SelectedValue.Split('|')[2];
                double price = Convert.ToDouble(p.Substring(1, p.Length - 1));

                if (Session["accountcart"] != null && ((ArrayList)Session["accountcart"]).Contains(id))
                {
                    labelInCart.Text = "Account #" + id + " is already in your cart!";
                    labelInCart.Visible = true;
                }
                else
                {
                    ArrayList list = new ArrayList();
                    if (Session["accountcart"] != null)
                    {
                        list = (ArrayList)Session["accountcart"];
                    }
                    list.Add(id);
                    if(Session["accountcart"] != null)
                        txtCart.Text += Environment.NewLine;
                    txtCart.Text += "Account #" + id + " " + username;

                    Session["accountcart"] = list;
                    ddlRemove.Items.Add(id);
                    labelTotal.Text = (Convert.ToDouble(labelTotal.Text) + price).ToString();
                }
            }

            txtCart.Visible = true;
            btnRemove.Visible = true;
            btnClear.Visible = true;
            ddlRemove.Visible = true;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtCart.Text = "";
            if (Session["itemcart"] != null)
            {
                ArrayList arr = (ArrayList)Session["itemcart"];
                for (int i = 0; i < arr.Count; i++)
                {
                    ddlRemove.Items.Remove(arr[i].ToString());
                }
                Session.Remove("itemcart");
            } else if(Session["currencycart"] != null)
            {
                ddlRemove.Items.Clear();
                ddlRemove.Items.Add("Select an item ID to remove");
                Session.Remove("currencycart");
            }
            else if (Session["accountcart"] != null)
            {
                ddlRemove.Items.Clear();
                ddlRemove.Items.Add("Select an item ID to remove");
                Session.Remove("accountcart");
            }
            Label3.Visible = false;
            labelTotal.Text = "0.00";

        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            if (!ddlRemove.SelectedValue.Equals("Select an item ID to remove"))
            {
                if(Session["itemcart"] != null)
                {
                    removeItems();
                } else if (Session["currencycart"] != null)
                {
                    removeCurrencyItems();
                } else if (Session["accountcart"] != null)
                {
                    removeAccounts();
                }
            }
        }

        private void removeAccounts()
        {
            txtCart.Text = "";
            string id = ddlRemove.SelectedValue;
            ArrayList arr = ((ArrayList)Session["accountcart"]);
            //Remove ID
            arr.Remove(id);
            //Remove ID from the drop down list
            ddlRemove.Items.Remove(id);
            //Remove the arraylist if it is empty
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            DataSet ds = client.SelectWithString("Accounts", "AccountID", id.ToString());
            DataRow row = ds.Tables["Accounts"].Rows[0];
            double price = Convert.ToDouble(row["Price"].ToString());
            labelTotal.Text = (Convert.ToDouble(labelTotal.Text) - price).ToString();
            if (arr.Count <= 0)
            {
                Session.Remove("accountcart");
            }
            else
            {
                for (int i = 0; i < arr.Count; i++)
                {
                    ds = client.SelectWithString("Accounts", "AccountID", arr[i].ToString());
                    row = ds.Tables["Accounts"].Rows[0];
                    if (i == 0)
                        txtCart.Text += "Account #" + row["AccountID"].ToString() + " " + row["Username"].ToString();
                    else
                    {
                        txtCart.Text += "Account #" + row["AccountID"].ToString() + " " + row["Username"].ToString();
                    }
                }
            }
            if (Convert.ToDouble(labelRMT.Text) >= Convert.ToDouble(labelTotal.Text))
            {
                Label3.Visible = false;
            }
        }

        private void removeCurrencyItems()
        {
            //Reference: StackOverflow
            //URL: https://stackoverflow.com/questions/1547476/easiest-way-to-split-a-string-on-newlines-in-net
            string[] arr = txtCart.Text.Split(
                new[] {
                            Environment.NewLine
                },
                StringSplitOptions.None
                );
            txtCart.Text = "";
            string currecyName = ddlRemove.SelectedValue.Split(' ')[1];
            string amount = ddlRemove.SelectedValue.Split(' ')[0];

            bool first = false;
            ArrayList list = (ArrayList)Session["currencycart"];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Length > 1)
                {
                    //An arraylist with duplicate values remove only 
                    //one occurence of a value
                    string[] arr1 = arr[i].Split(':');
                    string targetAmount = arr1[1].Split(' ')[0];
                    string currencyname = arr1[1].Split(' ')[1];
                    string priceString = arr1[0].Substring(1, arr1[0].Length - 1);
                    double price = Convert.ToDouble(priceString);

                    if (!first && targetAmount.Equals(amount))
                    {
                        list.Remove(priceString + " " + targetAmount + " " + currencyname);

                        double currentTotal = Convert.ToDouble(labelTotal.Text);
                        labelTotal.Text = (currentTotal - price).ToString();

                        ddlRemove.Items.Remove(targetAmount + " " + currecyName);
                        //Only the first occurence from the list should be removed
                        first = true;
                    }
                    else
                    {
                        txtCart.Text += price.ToString("C") + ":" + amount + " " + currecyName;
                        txtCart.Text += Environment.NewLine;
                    }
                }

            }
            if (list.Count <= 0)
            {
                Session.Remove("currencycart");
            }
            else
            {
                Session["currencycart"] = list;
            }
        }
        private void removeItems()
        {
            txtCart.Text = "";
            string id = ddlRemove.SelectedValue;
            ArrayList arr = ((ArrayList)Session["itemcart"]);
            //Remove ID
            arr.Remove(id);
            //Remove ID from the drop down list
            ddlRemove.Items.Remove(id);
            //Remove the arraylist if it is empty
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            DataSet ds = client.SelectWithString("Items", "ItemID", id.ToString());
            DataRow row = ds.Tables["Items"].Rows[0];
            double price = Convert.ToDouble(row["Price"]);
            labelTotal.Text = (Convert.ToDouble(labelTotal.Text) - price).ToString();
            if (arr.Count <= 0)
            {
                Session.Remove("itemcart");
            }
            else
            {
                for (int i = 0; i < arr.Count; i++)
                {
                    ds = client.SelectWithString("Items", "ItemID", arr[i].ToString());
                    row = ds.Tables["Items"].Rows[0];
                    if (i == 0)
                        txtCart.Text += "Item #" + row["ItemID"].ToString() + " " + row["ItemName"].ToString();
                    else
                    {
                        txtCart.Text += ", Item #" + row["ItemID"].ToString() + " " + row["ItemName"].ToString();
                    }
                }
            }
            if (Convert.ToDouble(labelRMT.Text) >= Convert.ToDouble(labelTotal.Text))
            {
                Label3.Visible = false;
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Session.Remove("itemtype");
            Response.Redirect("Selection.aspx");
        }
    }
}