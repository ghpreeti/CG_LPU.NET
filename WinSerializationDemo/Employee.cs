using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinSerializationDemo
{
    [Serializable] //attribute
    public class Employee
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        [NonSerialized] // can not be applied directly into property so a local variable is needed
        int sal;
        public int Salary 
        {
            get { return sal; }

            set {  sal = value; }
        }
    }
}
