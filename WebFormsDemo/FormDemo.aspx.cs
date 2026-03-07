using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsDemo
{
    public partial class FormDemo : System.Web.UI.Page
    {
        string conStr = @"Server=.\SQLEXPRESS;Database=Northwind;Integrated Security=True;TrustServerCertificate=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //LoadCustomers();
            }
        }

        //private void LoadCustomers()
        //{
        //    using (SqlConnection conn = new SqlConnection(conStr))
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand("Select * from Customers");
        //        cmd.CommandText = conStr;
        //        cmd.Connection = conn;
        //        SqlDataReader sdr = cmd.ExecuteReader();
        //        gvOrders.DataSource = sdr;
        //        gvOrders.DataBind();
        //    }
            
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}