using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;

namespace Mmu.Mlh.DomainExtensions.Areas.Repositories
{
    public interface IRepository<T, TId>
        where T : AggregateRoot<TId>
    {
        Task DeleteAsync(TId id);

        Task<IReadOnlyCollection<T>> LoadAllAsync();

        Task<T> LoadByIdAsync(TId id);

        Task<T> SaveAsync(T aggregateRoot);
    }
}