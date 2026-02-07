using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_TenantReportGenerator
{
    public class Transaction
    {
        public string TenantId { get; set; }
        public string Type { get; set; } // "Credit" or "Debit"
        public double Amount { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
