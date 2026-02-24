using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    internal class EmployeeDAL
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader sdr = null;

        public EmployeeDAL()
        {
            conn = new SqlConnection();
            conn.ConnectionString =
                "Server=.\\SQLEXPRESS;Integrated Security=SSPI;Database=LPU_DB;TrustServerCertificate=true";
        }

        public bool InsertEmployee(Employee emp)
        {
            bool isInserted = false;
            try
            {
                conn.Open();
                cmd = new SqlCommand();
                cmd.CommandText =
                    $"Insert into Employee values({emp.Id},'{emp.Name}','{emp.Department}','{emp.Salary}')";
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    isInserted = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isInserted;
        }

        public List<Employee> ShowEmployee()
        {
            List<Employee> empList = null;
            try
            {
                conn.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "Select * from Employee";
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    empList = new List<Employee>();
                    while (sdr.Read())
                    {
                        Employee emp = new Employee();
                        emp.Id = Convert.ToInt32(sdr["Id"]);
                        emp.Name = sdr["Name"].ToString();
                        emp.Department = sdr["Department"].ToString();
                        emp.Salary = Convert.ToInt32(sdr["Salary"]);
                        empList.Add(emp);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();

            }
            return empList;

        }

        public bool UpdateEmployee(int id)
        {
            bool isUpdated = false;
            try
            {
                conn.Open();
                cmd = new SqlCommand();
                cmd.CommandText = $"Update Employee set Salary=Salary+1000 where Id={id}";
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                int res = cmd.ExecuteNonQuery();
                if ((res > 0))
                {
                    isUpdated = true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isUpdated;

        }

        public bool DeleteEmployee(int id)
        {
            bool isDeleted = false;
            try
            {
                conn.Open();
                cmd = new SqlCommand();
                cmd.CommandText = $"Delete from Employee where Id={id}";
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                int res = cmd.ExecuteNonQuery();
                if ((res > 0))
                {
                    isDeleted = true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isDeleted;

        }
    }
}
