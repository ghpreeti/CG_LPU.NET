using System;
using System.Collections.Generic;
using System.Text;

namespace BroadbandPlan
{
    internal class Gold : IBroadbandPlan
    {
        private readonly bool _isSubscriptionValid;
        private readonly int _discountPercentage;
        private const int PlanAmount = 1500;

        public Gold(){}
        public Gold(bool isSubscriptionValid,int discountPercentage)
        {
            _isSubscriptionValid = isSubscriptionValid;
            _discountPercentage = discountPercentage;
            if(discountPercentage<0 || discountPercentage > 30)
            {
                throw new ArgumentOutOfRangeException("Discount percentage should be between 0 to 30");
            }
        }


        public int GetBroadbandPlanAmount()
        {
            int amount = PlanAmount;
            if (_isSubscriptionValid)
            {
                int discount = (PlanAmount * _discountPercentage) / 100;
                amount = PlanAmount - discount;
            }
            return amount;
        }
    }
}
