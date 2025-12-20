using Day3Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {

        public static void SwapMe(ref int x, ref int y)//pass by reference(by default pass by value)
        {
            int temp = x;
            x = y;
            y = temp;
            Console.WriteLine("Inside swap func\nvalue for num1 :{0} num2 :{1}", x, y);
        }

        public int AddToCart(params int[] prices)
        {
            int total = 0;
            foreach(int i in prices)
            {
                total += i;
            }
            return total;
        }
        //public int AddToCart(int p1, int p2)
        //{
        //    return p1 + p2;
        //}
        //public int AddToCart(int p1, int p2, int p3)
        //{
        //    return p1 + p2 + p3;
        //}


        public static void Main(string[] args)
        {
            //Person p1 = new Person();
            //p1.Display(100);
            //p1.Display(100.25f);
            //p1.Display("LPU");
            //p1.Display(new Employee());


            //Casting demo Below
            //typecasting refrece to refrece or value to value
            int x = 100;
            long z = x; //Implicit Casting
                        // short y = x; // -32768 to -32768
            short y = (short)x; //Explicit Casting  


            // Boxing and Unboxing
            //Boxing = converting value type to reference type
            //unboxing = converting reference type to value type

            int num1 = 120;
            object op = num1; //Boxing

            int num2 = (int)op; //Unboxing

            //int x1 = 100;
            //int y1 = 200;
            //Console.WriteLine("Inside Swap func\nvalue for x1 :{0} y1 :{1}", x1, y1);
            //SwapMe(ref x1, ref y1);
            //Console.WriteLine("Outside Swap func\nvalue for x1 :{0} y1 :{1}", x1, y1);

            Program pObj = new Program();
            pObj.AddToCart(10,20);
            pObj.AddToCart(10,20,30,40,50);






        }
    }
}
