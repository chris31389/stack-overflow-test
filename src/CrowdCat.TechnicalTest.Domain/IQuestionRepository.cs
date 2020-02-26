using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdCat.TechnicalTest.Domain
{
    /// <summary>
    /// A Question Repository
    /// </summary>
    public interface IQuestionRepository
    {
        /// <summary>
        /// Gets all question items for a date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<IEnumerable<Question>> GetAllForDate(DateTime date);
    }
}