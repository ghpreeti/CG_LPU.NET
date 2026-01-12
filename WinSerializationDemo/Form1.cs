using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; // for binary serialization
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;


namespace WinSerializationDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBinSerialize_Click(object sender, EventArgs e)
        {
            Employee emp1 = new Employee();
            emp1.Id = Convert.ToInt32(txtEmpID.Text);
            emp1.Name = txtName.Text;
            emp1.Salary = Convert.ToInt32(txtSalary.Text);

            FileStream fs = new FileStream(@"E:\disk d\fullStack\trainingCapgemeni\WinSerializationDemo\BinSerialize.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, emp1);


            foreach(Control item in this.Controls)
            {
                if(item.GetType() == typeof(TextBox))
                {
                    TextBox txtBox = (TextBox)item;
                    txtBox.Clear();
                }
            }
            fs.Close();
            MessageBox.Show("Record Added....");

        }

        private void btnBinUnserialize_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"E:\disk d\fullStack\trainingCapgemeni\WinSerializationDemo\BinSerialize.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            Employee emp1 = (Employee)bf.Deserialize(fs);

            txtEmpID.Text = emp1.Id.ToString();
            txtName.Text = emp1.Name.ToString();
            txtSalary.Text = emp1.Salary.ToString();
            fs.Close();

           
        }

        /// <summary>
        /// for XML Serialization
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            Employee emp1 = new Employee();
            emp1.Id = Convert.ToInt32(txtEmpID.Text);
            emp1.Name = txtName.Text;
            emp1.Salary = Convert.ToInt32(txtSalary.Text);

            FileStream fs = new FileStream(@"E:\disk d\fullStack\trainingCapgemeni\WinSerializationDemo\XMLSerializer.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Employee));   //tag-based enduser can change it
            xs.Serialize(fs, emp1);

            foreach (Control item in this.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    TextBox txtBox = (TextBox)item;
                    txtBox.Clear();
                }
            }
            fs.Close();
            MessageBox.Show("Record Added....");


        }

        private void btnXMLDeserialize_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"E:\disk d\fullStack\trainingCapgemeni\WinSerializationDemo\XMLSerializer.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            Employee emp1 = (Employee)bf.Deserialize(fs);

            txtEmpID.Text = emp1.Id.ToString();
            txtName.Text = emp1.Name.ToString();
            txtSalary.Text = emp1.Salary.ToString();
            fs.Close();
        }

        /// <summary>
        /// SOAP Serializer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSOAPSerialize_Click(object sender, EventArgs e)
        {
            Employee emp1 = new Employee();
            emp1.Id = Convert.ToInt32(txtEmpID.Text);
            emp1.Name = txtName.Text;
            emp1.Salary = Convert.ToInt32(txtSalary.Text);

            FileStream fs = new FileStream(@"E:\disk d\fullStack\trainingCapgemeni\WinSerializationDemo\SOAPserialize.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            SoapFormatter sf = new SoapFormatter();
            sf.Serialize(fs, emp1);

            foreach (Control item in this.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    TextBox txtBox = (TextBox)item;
                    txtBox.Clear();
                }
            }
            fs.Close();
            MessageBox.Show("Record Added....");


        }

        private void btnSOAPUnserialize_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"E:\disk d\fullStack\trainingCapgemeni\WinSerializationDemo\SOAPserialize.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            SoapFormatter sf = new SoapFormatter();
            Employee emp1 = (Employee)sf.Deserialize(fs);

            txtEmpID.Text = emp1.Id.ToString();
            txtName.Text = emp1.Name.ToString();
            txtSalary.Text = emp1.Salary.ToString();
            fs.Close();


        }
    }
}
