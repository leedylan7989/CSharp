using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace FinalProject_RMTApp
{
    public partial class ManageRequestsaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usertype"] == null || !Session["usertype"].Equals("Administrator"))
            {
                Response.Redirect("LoginPage.aspx");
            }


            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

            DataSet ds = client.Connect("ItemSellRequest");
            
            foreach(DataRow row in ds.Tables["ItemSellRequest"].Rows)
            {
                HtmlTableRow tablerow = new HtmlTableRow();
                HtmlTableCell cell = new HtmlTableCell();

                cell.InnerText = row["SellRequestID"].ToString();
                tablerow.Cells.Add(cell);

                cell = new HtmlTableCell();

                DataSet user = client.SelectWithString("Users", "UserID", row["UserID"].ToString());
                cell.InnerText = user.Tables["Users"].Rows[0]["Username"].ToString();
                tablerow.Cells.Add(cell);

                cell = new HtmlTableCell();

                cell.InnerText = row["ItemName"].ToString();

                tablerow.Cells.Add(cell);

                cell = new HtmlTableCell();

                cell.InnerText = row["DesiredPrice"].ToString();
                tablerow.Cells.Add(cell);

                cell = new HtmlTableCell();
                DataSet game = client.SelectWithString("Games", "GameID", row["GameID"].ToString());

                cell.InnerText = game.Tables["Games"].Rows[0]["GameName"].ToString();
                tablerow.Cells.Add(cell);

                cell = new HtmlTableCell();
                LinkButton link = new LinkButton();
                link.Text = "Click to move";
                link.Click += new EventHandler(linkButton_Click);

                DataSet discussion = client.Connect("Discussions");

                foreach(DataRow discussionRow in discussion.Tables["Discussions"].Rows)
                {
                    if (discussionRow["Detail"].ToString().Contains(row["ItemName"].ToString()))
                    {
                        link.ID = discussionRow["DiscussionID"].ToString();
                    }
                }

                cell.Controls.Add(link);
                tablerow.Cells.Add(cell);

                itemstable.Rows.Add(tablerow);


            }

            ds = client.Connect("AccountsSellRequest");

            foreach (DataRow row in ds.Tables["AccountsSellRequest"].Rows)
            {
                HtmlTableRow tablerow = new HtmlTableRow();
                HtmlTableCell cell = new HtmlTableCell();

                cell.InnerText = row["SellRequestID"].ToString();
                tablerow.Cells.Add(cell);

                cell = new HtmlTableCell();

                DataSet user = client.SelectWithString("Users", "UserID", row["UserID"].ToString());
                cell.InnerText = user.Tables["Users"].Rows[0]["Username"].ToString();
                tablerow.Cells.Add(cell);

                cell = new HtmlTableCell();

                cell.InnerText = row["Username"].ToString();

                tablerow.Cells.Add(cell);

                cell = new HtmlTableCell();

                cell.InnerText = row["DesiredPrice"].ToString();
                tablerow.Cells.Add(cell);

                cell = new HtmlTableCell();
                DataSet game = client.SelectWithString("Games", "GameID", row["GameID"].ToString());

                cell.InnerText = game.Tables["Games"].Rows[0]["GameName"].ToString();
                tablerow.Cells.Add(cell);

                cell = new HtmlTableCell();
                LinkButton link = new LinkButton();
                link.Text = "Click to move";
                link.Click += new EventHandler(linkButton_Click);

                DataSet discussion = client.Connect("Discussions");

                foreach (DataRow discussionRow in discussion.Tables["Discussions"].Rows)
                {
                    if (discussionRow["Detail"].ToString().Contains(row["Username"].ToString()))
                    {
                        link.ID = discussionRow["DiscussionID"].ToString();
                    }
                }

                cell.Controls.Add(link);
                tablerow.Cells.Add(cell);

                accountstable.Rows.Add(tablerow);


            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Session.Remove("ManageRequests");
            Response.Redirect("AdministratorWelcome.aspx");
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            if (((Control)sender).ID != null)
            {
                labelError.Visible = false;
                Session["DiscussionID"] = ((Control)sender).ID.ToString();
                Session["ManageRequests"] = true;
                Response.Redirect("Discussion.aspx");
            }
            else
                labelError.Visible = true;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!ddlType.SelectedValue.Equals("Please select an item type"))
            {
                ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
                price.Visible = true;
                ddlList.Items.Clear();
                if (ddlType.SelectedValue.Equals("Items"))
                {
                    DataSet ds = client.Connect("ItemSellRequest");
                    foreach(DataRow row in ds.Tables["ItemSellRequest"].Rows)
                    {
                        ddlList.Items.Add(row["SellRequestID"].ToString());
                    }
                }
                else
                {
                    DataSet ds = client.Connect("AccountsSellRequest");
                    foreach (DataRow row in ds.Tables["AccountsSellRequest"].Rows)
                    {
                        ddlList.Items.Add(row["SellRequestID"].ToString());
                    }
                }
            }
            else
            {
                price.Visible = false;
            }
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            using(SqlConnection con = new SqlConnection())
            {
                ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
                con.ConnectionString = "server=(local);Database=FinalProjectDB;Integrated Security=SSPI";
                con.Open();
                if (ddlType.SelectedValue.Equals("Items"))
                {

                    SqlCommand cmd = new SqlCommand("INSERT INTO Items (ItemName, Price, GameID) VALUES " +
                        "(@ItemName, @Price, @GameID)", con);

                    DataSet request = client.SelectWithString("ItemSellRequest", "SellRequestID", ddlList.SelectedValue);
                    cmd.Parameters.AddWithValue("@ItemName", request.Tables["ItemSellRequest"].Rows[0]["ItemName"].ToString());
                    cmd.Parameters.AddWithValue("@Price", Convert.ToDouble(txtPrice.Text).ToString());
                    cmd.Parameters.AddWithValue("@GameID", request.Tables["ItemSellRequest"].Rows[0]["GameID"].ToString());

                    cmd.ExecuteNonQuery();

                    DataSet user = client.SelectWithString("Users", "UserID",
                        request.Tables["ItemSellRequest"].Rows[0]["UserID"].ToString());

                    double amount = Convert.ToDouble(user.Tables["Users"].Rows[0]["Amount"].ToString());
                    double newAmount = amount + Convert.ToDouble(ddlList.SelectedValue);

                    client.UpdateWithDouble("Users", "Amount", newAmount, "UserID",
                        user.Tables["Users"].Rows[0]["UserID"].ToString());

                    client.DeleteByID("ItemSellRequest", "SellRequestID", ddlList.SelectedValue);
                    
                }
                else
                {

                    SqlCommand cmd = new SqlCommand("INSERT INTO Accounts (Username, Password, Price, GameID, Detail) VALUES " +
                        "(@Username, @Password, @Price, @GameID, @Detail)", con);

                    DataSet request = client.SelectWithString("AccountsSellRequest", "SellRequestID", ddlList.SelectedValue);
                    DataRow row = request.Tables["AccountsSellRequest"].Rows[0];

                    cmd.Parameters.AddWithValue("@Username", row["Username"].ToString());
                    cmd.Parameters.AddWithValue("@Password", row["Password"].ToString());
                    cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@GameID", row["GameID"].ToString());
                    cmd.Parameters.AddWithValue("@Detail", row["Detail"].ToString());

                    cmd.ExecuteNonQuery();


                    DataSet user = client.SelectWithString("Users", "UserID",
                        request.Tables["AccountsSellRequest"].Rows[0]["UserID"].ToString());

                    double amount = Convert.ToDouble(user.Tables["Users"].Rows[0]["Amount"].ToString());
                    double newAmount = amount + Convert.ToDouble(ddlList.SelectedValue);

                    client.UpdateWithDouble("Users", "Amount", newAmount, "UserID",
                        user.Tables["Users"].Rows[0]["UserID"].ToString());

                    client.DeleteByID("AccountsSellRequest", "SellRequestID", ddlList.SelectedValue);
                }
            }

            Response.Redirect("ManageRequests.aspx");
        }
    }
}