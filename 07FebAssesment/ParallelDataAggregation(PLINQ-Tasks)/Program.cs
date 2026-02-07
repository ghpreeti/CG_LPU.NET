using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ParallelDataAggregation_PLINQ_Tasks_
{
    public class Program
    {
        public static List<Sale> salesLi = new List<Sale>();
        
        public List<Sale> TotalSalesByRegion(string region)
        {
            return Task.Run(() =>
            salesLi.AsParallel()
            .GroupBy(x => x.Region)
            .Select(r => new
            {
                Region = r.Key,
                Total = r.Sum(s => s.Amount),
            }).ToList();
            

        }

        public List<Sale> TopCategoryPerRegion(string region) {

            return Task.Run(() =>
            salesLi.AsParallel().GroupBy(x => x.Region)
            .Select(r => new
            {
                Region = r.Key,
                TopCat = r.Select(x=>
                {
                    Category = x.Key,
                    Total = cg.Sum(a => a.Amount);

                }),
                

            })
            );

        }
        static void Main(string[] args)
        {

        }
    }
}
