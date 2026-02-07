using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_TenantReportGenerator
{
    internal class ReportService
    {
        public List<TenantReport> GenerateReports(List<Transaction> transactions)
        {
            List<TenantReport> reports = new List<TenantReport>();

            // Group by Tenant
            var tenantGroups = transactions.GroupBy(t => t.TenantId);

            foreach (var group in tenantGroups)
            {
                TenantReport report = new TenantReport();
                report.TenantId = group.Key;

                // Total credits and debits
                report.TotalCredits = group
                    .Where(t => t.Type == "Credit")
                    .Sum(t => t.Amount);

                report.TotalDebits = group
                    .Where(t => t.Type == "Debit")
                    .Sum(t => t.Amount);

                // Peak transaction hour
                report.PeakHour = group
                    .GroupBy(t => t.Timestamp.Hour)
                    .OrderByDescending(g => g.Count())
                    .First()
                    .Key;

                // Suspicious rule:
                // More than 3 debits within 5 minutes
                var debits = group
                    .Where(t => t.Type == "Debit")
                    .OrderBy(t => t.Timestamp)
                    .ToList();

                bool suspicious = false;

                for (int i = 0; i < debits.Count; i++)
                {
                    int count = 1;

                    for (int j = i + 1; j < debits.Count; j++)
                    {
                        var diff = debits[j].Timestamp - debits[i].Timestamp;

                        if (diff.TotalMinutes <= 5)
                            count++;
                        else
                            break;
                    }

                    if (count > 3)
                    {
                        suspicious = true;
                        break;
                    }
                }

                report.IsSuspicious = suspicious;

                reports.Add(report);
            }

            return reports;
        }
    }
}
