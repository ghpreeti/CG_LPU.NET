using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatternMiniFramework
{
    public class ApplyDiscountCommand : ICommand
    {
        private Cart _cart;
        private double _discount;

        public ApplyDiscountCommand(Cart cart, double discount)
        {
            _cart = cart;
            _discount = discount;
        }

        public void Execute()
        {
            _cart.ApplyDiscount(_discount);
        }

        public void Undo()
        {
            _cart.RemoveDiscount(_discount);
        }
    }

}
