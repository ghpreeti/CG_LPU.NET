using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServiceDemo
{
    /// <summary>
    /// Summary description for LPUWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LPUWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Add(int a, int b)
        {
            return a + b;
        }

        [WebMethod]
        public Product[] GetProducts()
        {
            //Connect to database and fetch products
            SqlConnection conn = new SqlConnection("Server=.\\sqlexpress;database=LPU_DB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            conn.Open();

            //Command to fetch products
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT ProdId, Name, Category, Price, Description FROM Products";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;

            //Data reader to read data from database
            SqlDataReader sdr = cmd.ExecuteReader();
            Product[] prodList = null ;
            DataTable dt = new DataTable();
            dt.Load(sdr);

            if(dt.Rows.Count > 0)
            {
                prodList = new Product[dt.Rows.Count];
            }
            int idx = 0;
            foreach (DataRow dr in dt.Rows)
            {
                Product pObj = new Product();
                pObj.ProdId = Convert.ToInt32(dr["ProdId"]);
                pObj.Name = dr["Name"].ToString();
                pObj.Category = dr["Category"].ToString();
                pObj.Price = Convert.ToInt32(dr["Price"]);
                pObj.Description = dr["Description"].ToString();

                prodList[idx] = pObj;
                idx++;
            }
            conn.Close();
            return prodList;

        }
    }
}
