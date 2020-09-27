using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace FinalProject_RMTApp
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

            DataSet ds = client.Connect("Users");
            DataTable table = ds.Tables["Users"];

            bool username = false;
            foreach(DataRow row in table.Rows)
            {
                if (row["Username"].Equals(TextBox1.Text))
                {
                    username = true;
                    if (row["Password"].Equals(TextBox2.Text))
                    {
                        Session["username"] = TextBox1.Text;
                        Session["usertype"] = row["Usertype"].ToString();
                        Session["userid"] = row["UserID"];
                        Session["UserAmount"] = row["Amount"];
                        if (row["Usertype"].Equals("User"))
                            Response.Redirect("WelcomePage.aspx");
                        else
                            Response.Redirect("AdministratorWelcome.aspx");
                    }
                }
            }

            Label2.ForeColor = System.Drawing.Color.Red;
            if (username)
            {
                Label2.Text = "Password does not match";
            }
            else
            {
                Label2.Text = "Username does not exist";
            }
        }
    }
}