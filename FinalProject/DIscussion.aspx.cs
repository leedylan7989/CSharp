using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;


namespace FinalProject_RMTApp
{
    public partial class DIscussion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usertype"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }

            if(Session["DiscussionID"] == null)
            {
                Response.Redirect("DiscussionList.aspx");
            }

            Label1.Text = "Discussion #" + Session["DiscussionID"].ToString();

            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            DataSet ds = client.SelectWithString("Discussions", "DiscussionID", 
                Session["DiscussionID"].ToString());

            DataRow row = ds.Tables["Discussions"].Rows[0];

            DataSet user = client.SelectWithString("Users", "UserID", row["UserID"].ToString());
            DataRow userinfo = user.Tables["Users"].Rows[0];
            
            string a = "";
            a += "<h2>" + row["Title"].ToString() + "<h2>";
            a += "<h3>" + userinfo["Username"] + "</h3>";

            string[] detail = row["Detail"].ToString().Split('|');

            for(int i = 0; i < detail.Length; i++) {
                a += "<h3>" + detail[i] + "</h3>";
            }

            LiteralControl discussion = new LiteralControl(a);

            discussionDiv.Controls.Add(discussion);

            if (row["UserID"].ToString().Equals(Session["userid"].ToString()) || 
                Session["usertype"].ToString().Equals("Administrator"))
            {
                Button deletebutton = new Button();
                deletebutton.Text = "Delete this discussion";
                deletebutton.Click += new EventHandler(deleteButton_Click);
                discussionDiv.Controls.Add(deletebutton);
            }

            if (row["UserID"].ToString().Equals(Session["userid"].ToString()))
            {
                Button editbutton = new Button();
                editbutton.Text = "Edit this discussion";
                editbutton.Click += new EventHandler(editButton_Click);
                discussionDiv.Controls.Add(editbutton);
            }

            ds = client.SelectWithString("Reply", "DiscussionID", Session["DiscussionID"].ToString());

            string replyString = "";

            foreach(DataRow reply in ds.Tables["Reply"].Rows)
            {
                DataSet replyUser = client.SelectWithString("Users", "UserID", reply["UserID"].ToString());
                string replyusername = replyUser.Tables["Users"].Rows[0]["Username"].ToString();
                replyString += "<h3>" + replyusername + "</h3>";

                detail = reply["Detail"].ToString().Split('|');

                for (int i = 0; i < detail.Length; i++)
                {

                    replyString += "<h3>" + detail[i] + "</h3>";
                }
                replyString += "<hr/>";
            }

            LiteralControl b = new LiteralControl(replyString);

            replyList.Controls.Add(b);

            TextBox tb = new TextBox();
            tb.ForeColor = System.Drawing.Color.White;
            tb.BackColor = Color.FromArgb(60, 60, 60);
            tb.ReadOnly = false;
            tb.Visible = false;
            tb.TextMode = TextBoxMode.MultiLine;
            tb.ID = "editDiscussion";

            tb.Text = "";

            ds = client.SelectWithString("Discussions", "DiscussionID",
                Session["DiscussionID"].ToString());

            row = ds.Tables["Discussions"].Rows[0];

            detail = row["Detail"].ToString().Split('|');

            for (int i = 0; i < detail.Length; i++)
            {
                if (i != 0)
                    tb.Text += Environment.NewLine;
                tb.Text += detail[i];
            }

            LiteralControl lb = new LiteralControl("<br/>");


            discussionDiv.Controls.Add(lb);
            discussionDiv.Controls.Add(tb);

        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            //Deleting a discussion
            string did = Session["DiscussionID"].ToString();

            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

            client.execute("DELETE FROM Reply WHERE DiscussionID='" + did + "'");
            client.execute("DELETE FROM Discussions WHERE DiscussionID='" + did + "'");

            Session.Remove("DiscussionID");

            Response.Redirect("DiscussionList.aspx");
        }

        protected void editButton_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            if (((Button)sender).Text.Equals("Edit this discussion"))
            {
                ((Button)sender).Text = "Edit Complete";
                Control tb = discussionDiv.FindControl("editDiscussion");
                tb.Visible = true;
            }
            else
            {
                string newDetail = "";

                Control tb = discussionDiv.FindControl("editDiscussion");
                string[] detail = ((TextBox)tb).Text.Split(
                    new[] {
                            Environment.NewLine
                    },
                    StringSplitOptions.None
                    );

                for (int i = 0; i < detail.Length; i++)
                {
                    if (i != 0)
                    {
                        newDetail += "|";
                    }
                    newDetail += detail[i];
                }

                //SQL injection validation
                string modifiedDetail = newDetail.Replace("\"", "\\\"");
                modifiedDetail = modifiedDetail.Replace("'", "\\'");


                client.UpdateWithField("Discussions", "Detail", modifiedDetail, "DiscussionID",
                    Session["DiscussionID"].ToString());

                Response.Redirect("Discussion.aspx");

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(TextBox1.Text.Length > 0)
            {
                string[] arr = TextBox1.Text.Split(new[] {
                            Environment.NewLine
                },
                StringSplitOptions.None
                );

                string detail = "";

                for(int i = 0; i < arr.Length; i++)
                {
                    
                    detail += arr[i] + "|";
                }

                ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

                string userid = Session["userid"].ToString();
                string did = Session["DiscussionID"].ToString();
                using(SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = "server=(local);Database=FinalProjectDB;Integrated Security=SSPI";
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Reply (DiscussionID, UserID, Detail) VALUES" +
                        "(@DiscussionID, @UserID, @Detail)", con);
                    cmd.Parameters.AddWithValue("@DiscussionID",did);
                    cmd.Parameters.AddWithValue("@UserID", userid);
                    cmd.Parameters.AddWithValue("@Detail", detail);

                    cmd.ExecuteNonQuery();
                }

                Response.Redirect("Discussion.aspx");
                
                    
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Remove("DiscussionID");
            if (Session["SellConfirmationPage"] != null)
                Response.Redirect("SellConfirmationPage.aspx");
            else if(Session["ManageRequests"] != null)
                Response.Redirect("ManageRequests.aspx");
            else
                Response.Redirect("DiscussionList.aspx");
        }
    }
}