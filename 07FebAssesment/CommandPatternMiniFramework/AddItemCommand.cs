using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatternMiniFramework
{
    public class AddItemCommand : ICommand
    {
        private Cart _cart;
        private string _item;
        private double _price;

        public AddItemCommand(Cart cart, string item, double price)
        {
            _cart = cart;
            _item = item;
            _price = price;
        }

        public void Execute()
        {
            _cart.AddItem(_item, _price);
        }

        public void Undo()
        {
            _cart.RemoveItem(_item, _price);
        }
    }

}
