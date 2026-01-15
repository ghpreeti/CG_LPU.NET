using System;
using System.Collections.Generic;
using System.Text;

namespace BroadbandPlan
{
    internal class SubscribePlan
    {
        private readonly IList<IBroadbandPlan> _broadbandPlans;
        public SubscribePlan(){ }
        public SubscribePlan(IList<IBroadbandPlan> broadbandplans)
        {
            _broadbandPlans = broadbandplans;
            if(broadbandplans == null || broadbandplans.Count ==0)
            {
                throw new ArgumentNullException("broadbandplans cannot be null or empty");
            }
        }

        public IList<Tuple<string,int>> GetSubscriptionPlan()
        {
            IList<Tuple<string, int>> list = new List<Tuple<string, int>>();
            foreach(var plan in _broadbandPlans)
            {
                list.Add(new Tuple<string, int>(plan.GetType().Name, plan.GetBroadbandPlanAmount()));
            }
            
            return list;


        }

    }
}
