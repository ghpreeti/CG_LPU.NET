using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatternMiniFramework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Cart cart = new Cart();
            CommandManager manager = new CommandManager();

            // Add items
            manager.ExecuteCommand(new AddItemCommand(cart, "Laptop", 50000));
            manager.ExecuteCommand(new AddItemCommand(cart, "Mouse", 1000));
            cart.ShowCart();

            // Apply discount
            manager.ExecuteCommand(new ApplyDiscountCommand(cart, 2000));
            cart.ShowCart();

            // Undo discount
            Console.WriteLine("Undo:");
            manager.Undo();
            cart.ShowCart();

            // Undo last add
            Console.WriteLine("Undo again:");
            manager.Undo();
            cart.ShowCart();

            // Redo
            Console.WriteLine("Redo:");
            manager.Redo();
            cart.ShowCart();
        }
    }
}
