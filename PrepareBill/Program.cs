// See https://aka.ms/new-console-template for more information
using PrepareBill;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var commodities = new List<Commodity>
        {
            new Commodity(CommodityCategory.Furniture, "Table", 2, 25000),
            new Commodity(CommodityCategory.Grocery, "Flour", 5, 80),
            new Commodity(CommodityCategory.Service, "Insurance", 8, 8500)
        };

        var prepareBill = new PrepareBill.PrepareBill();

        prepareBill.SetTaxRates(CommodityCategory.Furniture, 18);
        prepareBill.SetTaxRates(CommodityCategory.Grocery, 5);
        prepareBill.SetTaxRates(CommodityCategory.Service, 12);

        var billAmount = prepareBill.CalculateBillAmount(commodities);

        Console.WriteLine(billAmount);
    }
}

