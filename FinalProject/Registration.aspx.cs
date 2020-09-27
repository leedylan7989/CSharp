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
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using(SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = "server=(local);Database=FinalProjectDB;Integrated Security=SSPI";
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, Password, Firstname, Lastname," +
                    "Email, Usertype, Amount) VALUES (@Username, @Password, @Firstname, @Lastname, " +
                    "@Email, @Usertype, @Amount)", con);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text.ToString());
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text.ToString());
                cmd.Parameters.AddWithValue("@Firstname", txtFirstname.Text.ToString());
                cmd.Parameters.AddWithValue("@Lastname", txtLastname.Text.ToString());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.ToString());
                cmd.Parameters.AddWithValue("@Usertype", "User");
                cmd.Parameters.AddWithValue("@Amount", "10.00");

                cmd.ExecuteNonQuery();
            }

            Response.Redirect("LoginPage.aspx");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
    }
}