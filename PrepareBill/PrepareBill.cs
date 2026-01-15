using System;
using System.Collections.Generic;
using System.Text;

namespace PrepareBill
{
    internal class PrepareBill
    {
        
        private readonly IDictionary<CommodityCategory, double> _taxRates = null;
        public PrepareBill()
        {
            _taxRates = new Dictionary<CommodityCategory, double>();
        }

        public void SetTaxRates(CommodityCategory category, double taxRate)
        {
            if (_taxRates.ContainsKey(category))
            {
                _taxRates[category] = taxRate;
            }
            else
            {
                _taxRates.Add(category, taxRate);
            }
            

        }

        public double CalculateBillAmount(IList<Commodity> items)
        {
            double total = 0;

            foreach (Commodity item in items)
            {
                double baseAmount = item.CommodityPrice * item.CommodityQuantity;
                double taxRate = 0;
                if (_taxRates.ContainsKey(item.Category))
                {
                    taxRate = _taxRates[item.Category];
                }
                else
                {
                    taxRate = 0;
                }
                    double taxAmount = baseAmount * taxRate / 100;
                total += baseAmount + taxAmount;

            }
            return total;
        }
    }
}
