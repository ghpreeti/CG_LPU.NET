using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinDisconArchDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ProductUtility prodObj = new ProductUtility();
            dataGridView1.DataSource = prodObj.ShowAll();

            DataTable myDt = prodObj.GetAllData();
            //binding Ui Elements with table columns

            txt_prodId.DataBindings.Add("Text", myDt, myDt.Columns[0].ColumnName);
            txt_prodName.DataBindings.Add("Text", myDt, myDt.Columns[1].ColumnName);
            txt_price.DataBindings.Add("Text", myDt, myDt.Columns[3].ColumnName);
            txt_description.DataBindings.Add("Text", myDt, myDt.Columns[4].ColumnName);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
