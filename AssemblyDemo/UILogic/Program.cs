using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary;

namespace UILogic
{
    [Doctor(Name = "Riyaa",CheckedOnDate = "12/02/2020")]
    [Doctor(Name = "Ravi", CheckedOnDate = "13/03/2020")]
    [Doctor(Name = "Ritu", CheckedOnDate = "12/10/2024")]
    [Serializable]

    internal class Program
    {
        static void Main(string[] args)
        {
            int num1;
            int num2;

            Console.Write("Enter First Number:");
            num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Second Number:");
            num2 = Convert.ToInt32(Console.ReadLine());

            SomeLogic logic = new SomeLogic();

            int numResult = logic.AddMe(num1, num2);
            Console.WriteLine($"\nThe sum of {num1} and {num2} is {numResult}");

            Console.ReadLine();
        }
    }
}
