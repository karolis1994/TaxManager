using System.Threading;
using System.Threading.Tasks;

namespace TaxManager.Domain.Core
{
    /// <summary>
    /// Unit of work
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Saves changes
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
