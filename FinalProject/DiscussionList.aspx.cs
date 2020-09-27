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
    public partial class DiscussionList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usertype"] == null)
            {
                Response.Redirect("LoginPage.aspx");

            }
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            DataSet ds = client.Connect("Discussions");

            foreach (DataRow row in ds.Tables["Discussions"].Rows)
            {
                if (row["Private"].ToString().Equals("No"))
                {
                    HtmlTableRow tablerow = new HtmlTableRow();
                    HtmlTableCell cell = new HtmlTableCell();

                    cell.InnerText = row["DiscussionID"].ToString();
                    tablerow.Cells.Add(cell);

                    cell = new HtmlTableCell();
                    LinkButton link = new LinkButton();
                    link.Text = row["Title"].ToString();
                    link.ID = row["DiscussionID"].ToString();
                    link.Click += new EventHandler(LinkButton_Click);
                    cell.Controls.Add(link);

                    tablerow.Cells.Add(cell);

                    DataSet ds1 = client.SelectWithString("Users", "UserID", row["UserID"].ToString());
                    string username = ds1.Tables["Users"].Rows[0]["Username"].ToString();

                    cell = new HtmlTableCell();
                    cell.InnerText = username;
                    tablerow.Cells.Add(cell);

                    listTable.Rows.Add(tablerow);
                }
            }


        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {
            string id = ((Control)sender).ID.ToString();
            Session["DiscussionID"] = id;
            Response.Redirect("Discussion.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            labelAdd.Visible = false;
            TextBox1.Visible = false;
            btnAdd.Visible = false;
            btnCancel.Visible = false;
            txtTitle.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            btnAddDiscussion.Visible = true;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Length > 0)
            {
                string[] arr = TextBox1.Text.Split(new[] {
                            Environment.NewLine
                },
                StringSplitOptions.None
                );

                string detail = "";

                for (int i = 0; i < arr.Length; i++)
                {
                    if (i != 0)
                        detail += "|";
                    detail += arr[i];
                }

                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = "server=(local);Database=FinalProjectDB;Integrated Security=SSPI";
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Discussions (UserID, Title, Detail, Private)" +
                        "VALUES (@UserID, @Title, @Detail, @Private)", con);

                    cmd.Parameters.AddWithValue("@UserID", Session["userid"].ToString());
                    cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@Detail", detail);
                    cmd.Parameters.AddWithValue("@Private", "No");


                    cmd.ExecuteNonQuery();
                }
                Response.Redirect("DiscussionList.aspx");
            }
        }


        protected void btnAddDiscussion_Click(object sender, EventArgs e)
        {
            labelAdd.Visible = true;
            TextBox1.Visible = true;
            btnAdd.Visible = true;
            btnCancel.Visible = true;
            txtTitle.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            btnAddDiscussion.Visible = false;
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (Session["usertype"].Equals("User"))
                Response.Redirect("WelcomePage.aspx");
            else
                Response.Redirect("AdministratorWelcome.aspx");
        }
    }
}