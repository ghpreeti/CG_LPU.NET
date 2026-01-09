using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace events_demo
{
    delegate void mydel(int marks);

    class students
    {
        private int marks;
        public event mydel pass;
        public event mydel fail;

        public int Marks
        {
            get 
            { 
                return marks;
            }
            set 
            {
                if (value < 40)
                {
                    fail(value);
                }
                else
                {
                    pass(value);
                }
                marks = value;
            }
        }
        public void mypass(int marks)
        {
            Console.WriteLine("You are Pass");
        }
        public void myfail(int marks)
        {
            Console.WriteLine("You are fail");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            students s = new students();
            s.pass  += new mydel(s.mypass);
            s.fail  += new mydel(s.myfail);
            s.Marks = 20;
            Console.ReadLine();
        }
    }

}
