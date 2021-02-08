using SoftPlanAPI.Queries.IQueries;
using System.Threading.Tasks;

namespace SoftPlanAPI.Queries
{
    public class InterestTax : IInterestTax
    {
        /// <summary>
        /// Leitura da base
        /// </summary>
        /// <returns></returns>
        public decimal GetInterestTax()
            => 0.01M;
    }
}
