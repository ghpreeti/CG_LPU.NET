using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_TenantReportGenerator
{
    public class TenantReport
    {
        public string TenantId { get; set; }
        public double TotalCredits { get; set; }
        public double TotalDebits { get; set; }
        public int PeakHour { get; set; }
        public bool IsSuspicious { get; set; }
    }
}
