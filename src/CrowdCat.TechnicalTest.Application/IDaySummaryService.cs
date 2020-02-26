using System;
using System.Threading.Tasks;

namespace CrowdCat.TechnicalTest.Application
{
    public interface IDaySummaryService
    {
        Task<DaySummaryDto> GetSummaryAsync(DateTime dateTime);
    }
}