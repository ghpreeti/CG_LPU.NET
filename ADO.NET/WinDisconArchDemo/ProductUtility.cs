using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinDisconArchDemo
{
    public class ProductUtility : IProductRepo
    {
        IDbConnection conn;
        SqlDataAdapter adapter;
        DataSet ds;
        SqlCommandBuilder bldr;

        public ProductUtility()
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Server=.\\Sqlexpress;Integrated Security = SSPI;Database = LPU_DB;TrustServerCertificate=true";
           
        }


        public bool AddData(Product item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteData(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetTop3BudgetProduct()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetTop3CostlyProduct()
        {
            throw new NotImplementedException();
        }

        public List<Product> ShowAll()
        {
            adapter = new SqlDataAdapter("Select * from Products", (SqlConnection)conn);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            ds = new DataSet();
            adapter.Fill(ds, "Products");

            List<Product> prodList = new List<Product>();
            if (ds.Tables["Products"].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables["Products"].Rows)
                {
                    Product p1 = new Product()
                    {
                        ProdId = Convert.ToInt32(dr[0].ToString()),
                        ProdName = dr[1].ToString(),
                        Category = dr[2].ToString(),
                        Price = Single.Parse(dr[3].ToString()),
                        Desc = dr[4].ToString()
                    };

                    prodList.Add(p1);
                }
            }
            return prodList;
            //throw new NotImplementedException();
        }

        public List<Product> ShowAllProductByCategory(int catId)
        {
            throw new NotImplementedException();
        }

        public List<Product> SortProductByPriceAsc()
        {
            throw new NotImplementedException();
        }

        public List<Product> SortProductByPriceDesc()
        {
            throw new NotImplementedException();
        }

        public bool UpdateData(int id, Product obj)
        {
            SqlCommand updateCmd = new SqlCommand();
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@name", obj.ProdName),
                new SqlParameter("@cat", obj.Category),
                new SqlParameter("@price", obj.Price),
                new SqlParameter("@desc", obj.Desc),
                new SqlParameter("@id", id)
            };

            updateCmd.CommandText = "Update Products set ProdName=@name, Category=@cat, Price=@price, Desc=@desc where ProdId=@id";
            updateCmd.Connection = (SqlConnection)conn;
            updateCmd.CommandType = CommandType.Text;
            updateCmd.Parameters.AddRange(param);

            adapter.UpdateCommand = updateCmd;
            bldr.DataAdapter = adapter;
            adapter.Update(ds);
            return true;
        }

        public DataTable GetAllData()
        {
            adapter = new SqlDataAdapter("Select * from Products", (SqlConnection)conn);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            bldr = new SqlCommandBuilder(adapter);

            ds = new DataSet();
            adapter.Fill(ds, "Products");
            return ds.Tables[0];

        }
    }
}
