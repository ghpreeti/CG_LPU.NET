using System;
namespace MediSure
{
    public class PatientBill
    {
        public string BillID{ get; set; }
        public string? PatientName { get; set; }
        public bool HasInsurance { get; set; }
        public decimal ConsultationFee { get; set; }
        public decimal LabCharges { get; set; }
        public decimal MedicineCharges { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalPayable { get; set; }

        
        public void CalculateBill()
        {
            GrossAmount = ConsultationFee + LabCharges + MedicineCharges;

            if (HasInsurance)
            {
                DiscountAmount = GrossAmount * (decimal)0.10;
            }
            else
            {
                DiscountAmount = 0;
            }

            FinalPayable = GrossAmount - DiscountAmount;
        }

    }
}