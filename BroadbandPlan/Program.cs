// See https://aka.ms/new-console-template for more information
using System;
using BroadbandPlan;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var plans = new List<IBroadbandPlan>
            {
                new Black(true, 50),
                new Black(false, 10),
                new Gold(true, 30),
                new Black(true, 20),
                new Gold(false, 20),

            };

            var subscriptionPlans = new SubscribePlan(plans);

            var result = subscriptionPlans.GetSubscriptionPlan();
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Item1},{item.Item2}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
