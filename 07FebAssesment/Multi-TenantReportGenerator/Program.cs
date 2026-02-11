using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_TenantReportGenerator
{
    internal class Program
    {
        static void Main()
        {
            List<Transaction> transactions = new List<Transaction>
        {
            new Transaction { TenantId="T1", Type="Credit", Amount=500, Timestamp=DateTime.Now.AddMinutes(-50)},
            new Transaction { TenantId="T1", Type="Debit", Amount=100, Timestamp=DateTime.Now.AddMinutes(-10)},
            new Transaction { TenantId="T1", Type="Debit", Amount=150, Timestamp=DateTime.Now.AddMinutes(-8)},
            new Transaction { TenantId="T1", Type="Debit", Amount=200, Timestamp=DateTime.Now.AddMinutes(-6)},
            new Transaction { TenantId="T1", Type="Debit", Amount=250, Timestamp=DateTime.Now.AddMinutes(-4)},

            new Transaction { TenantId="T2", Type="Credit", Amount=1000, Timestamp=DateTime.Now.AddHours(-1)},
            new Transaction { TenantId="T2", Type="Debit", Amount=200, Timestamp=DateTime.Now.AddMinutes(-30)}
        };

            ReportService service = new ReportService();
            var reports = service.GenerateReports(transactions);

            foreach (var r in reports)
            {
                Console.WriteLine($"Tenant: {r.TenantId}");
                Console.WriteLine($"Credits: {r.TotalCredits}");
                Console.WriteLine($"Debits: {r.TotalDebits}");
                Console.WriteLine($"Peak Hour: {r.PeakHour}");
                Console.WriteLine($"Suspicious: {r.IsSuspicious}");
                Console.WriteLine();
            }
        }
    }
}
