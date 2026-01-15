using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace WinReflectionDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }

        private void btnLoadAssembly_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string filePath = openFileDialog1.FileName;

            Assembly assemblyObj = Assembly.LoadFrom(filePath);

            Type[] myTypes = assemblyObj.GetTypes();

            this.ReflectAll(myTypes[0]);
        }

        public void ReflectAll(Type typeObj)
        {
            // Getting All Methods
            MethodInfo[]  methodArr = typeObj.GetMethods();

            // Getting All Properties
            PropertyInfo[] propertyArr = typeObj.GetProperties();

            // Getting All Events
            //EventInfo[] eventArr = typeObj.GetEvents();

            // Load All Properties
            foreach(var item in propertyArr)
            {
                listBox1.Items.Add(item);
            }

            // Load All Methods
            listBox2.Items.AddRange(methodArr);

            
        }
    }
}
