using System;

namespace QuickMart
{
    public class SaleTransaction
    {


// •	InvoiceNo (string) — unique identifier (example: INV1001)
// •	CustomerName (string)
// •	ItemName (string)
// •	Quantity (int)
// •	PurchaseAmount (decimal) — total purchase cost for the invoice (not per-unit)
// •	SellingAmount (decimal) — total selling amount for the invoice (not per-unit)
// •	ProfitOrLossStatus (string) — PROFIT / LOSS / BREAK-EVEN (calculated)
// •	ProfitOrLossAmount (decimal) — calculated
// •	ProfitMarginPercent (decimal) — calculated (relative to PurchaseAmount)

        public string? InvoiceNo{get;set;}
        public string? CustomerName { get; set; }
        public string? ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal PurchaseAmount { get; set; }
        public decimal SellingAmount { get; set; }
        public string? ProfitOrLossStatus { get; set; }
        public decimal ProfitOrLossAmount { get; set; }
        public decimal ProfitMarginPercent { get; set; }

        

        public void CalculateProfitLoss()
        {
            if (SellingAmount > PurchaseAmount)
            {
                ProfitOrLossStatus = "PROFIT";
                ProfitOrLossAmount = SellingAmount - PurchaseAmount;
            }
            else if (SellingAmount < PurchaseAmount)
            {
                ProfitOrLossStatus = "LOSS";
                ProfitOrLossAmount = PurchaseAmount - SellingAmount;
            }
            else
            {
                ProfitOrLossStatus = "BREAK-EVEN";
                ProfitOrLossAmount = 0;
            }

            ProfitMarginPercent = (ProfitOrLossAmount / PurchaseAmount) * 100;
        }


    }
}