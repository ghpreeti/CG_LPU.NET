using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConArchDemo
{
    /// <summary>
    /// Demo for connected ARCHITECTURE in DAL class
    /// </summary>
    public class StudentDAL
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader sdr = null;

        public StudentDAL()
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Server=.\\Sqlexpress;Integrated Security = SSPI;Database = LPU_DB;TrustServerCertificate=true";
        }
        public List<Student> ShowAllStudent()
        {
            List<Student> studList = null;
            //Code for Connected Architecture below
            try
            { 
                conn.Open();

                cmd = new SqlCommand();
                cmd.CommandText = "Select * from StudentInfo";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                //holding data via reader(forward only control)
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);

                //convert Table into List
                if(dt.Rows.Count > 0)
                {
                    studList = new List<Student>();
                }
                foreach (DataRow drow in dt.Rows)
                {
                    Student student = new Student()
                    {
                        RollNo = Convert.ToInt32(drow[0].ToString()),
                        Name = drow[1].ToString(),
                        Address = drow[3].ToString(),
                        PhoneNo = drow[5].ToString(),
                    };
                    if (student != null) {
                     studList.Add(student);
                    }

                }

                ///
                //older way ---------------------
                //foreach (DataRow row in sdr)
                //{
                //    dt.Rows.Add(row);
                //}
                ///

                //while (sdr.Read())
                //{
                //    Console.WriteLine();
                //}
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return studList;
        }

        public List<Student> ShowStudentbyName(string name)
        {
            List<Student> studList = null;
            SqlParameter param1 = new SqlParameter("@Name",name);

            //Code for Connected Architecture below
            try
            {
                conn.Open();

                cmd = new SqlCommand();
                cmd.CommandText = "Select * from StudentInfo where Name = @Name";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                //Param is to be added to command
                cmd.Parameters.Add(param1);
                //holding data via reader(forward only control)
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);

                //convert Table into List
                if (dt.Rows.Count > 0)
                {
                    studList = new List<Student>();
                }
                foreach (DataRow drow in dt.Rows)
                {
                    Student student = new Student()
                    {
                        RollNo = Convert.ToInt32(drow[0].ToString()),
                        Name = drow[1].ToString(),
                        Address = drow[3].ToString(),
                        PhoneNo = drow[5].ToString(),
                    };
                    if (student != null)
                    {
                        studList.Add(student);
                    }

                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return studList;
        }

        public Student ShowStudentbyID(int rollNo)
        {
            Student temObj = null;

            return temObj;
        }

        public bool AddStudents(Student stu)
        {
            bool flag = false;
            SqlParameter[] values = new SqlParameter[5];
            values[0] = new SqlParameter("@RollNo", stu.RollNo);
            values[1] = new SqlParameter("@Name", stu.Name);
            values[2] = new SqlParameter("@Age", stu.Age);
            values[3] = new SqlParameter("@Address", stu.Address);
            values[4] = new SqlParameter("@Phone", stu.PhoneNo);

            //Code for Connected Architecture below
            try
            {
                conn.Open();

                cmd = new SqlCommand();
                cmd.CommandText = "Insert into StudentInfo(RollNo,Name,Age,LocalAddr,PermAddr,PhoneNo) values(@RollNo,@Name,@Age,@Address,@Address,@Phone)";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                

                //Param is to be added to command
                cmd.Parameters.AddRange(values);

                //holding data via reader(forward only control)
                int RowAff = cmd.ExecuteNonQuery();
                if (RowAff == 1)
                {
                    flag = true;
                }
                        
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return flag;
        }
        

    }
}
