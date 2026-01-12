using System;
using System.Collections.Generic;
using System.Text;

namespace BroadbandPlan
{
    internal class Black : IBroadbandPlan
    {
        private bool _isSubscriptionValid;
        private int PlanAmount = 3000;
        private int _discountPercentage;
        
        public Black() { }
        
        public Black(bool isSusbcriptionValid,int discountPercentage)
        {
            _isSubscriptionValid = isSusbcriptionValid;
            _discountPercentage = discountPercentage;

            if(discountPercentage<0 || discountPercentage > 50)
            {
                throw new ArgumentOutOfRangeException("Discount percentage should be between 0 to 50");
            }
        }

        public int GetBroadbandPlanAmount() 
        {
            int amount = PlanAmount;
            if (_isSubscriptionValid)
            {
                int discount = (PlanAmount * _discountPercentage)/100;
                amount = PlanAmount - discount;
            }
            return amount;
        }
    }
}
