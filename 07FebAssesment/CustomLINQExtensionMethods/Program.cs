using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLINQExtensionMethods
{
   public class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 2, 3, 4, 4, 5 };

            // WhereEx
            var even = numbers.WhereEx(n => n % 2 == 0);
            Console.WriteLine("Even numbers:");
            foreach (var n in even)
                Console.WriteLine(n);

            // SelectEx
            var squares = numbers.SelectEx(n => n * n);
            Console.WriteLine("\nSquares:");
            foreach (var n in squares)
                Console.WriteLine(n);

            // DistinctEx
            var distinct = numbers.DistinctEx();
            Console.WriteLine("\nDistinct:");
            foreach (var n in distinct)
                Console.WriteLine(n);
        }
    }
}
