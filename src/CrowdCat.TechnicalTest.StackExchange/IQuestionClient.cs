using System.Threading.Tasks;

namespace CrowdCat.TechnicalTest.StackExchange
{
    public interface IQuestionClient
    {
        Task<string> GetAsync(double fromDate, double toDate, int page);
    }
}