using System.Diagnostics.CodeAnalysis;

namespace Mmu.Mlh.DomainExtensions.Areas.DomainModeling
{
    public abstract class AggregateRoot : Entity<object>
    {
        protected AggregateRoot(object id) : base(id)
        {
        }
    }

    [SuppressMessage("Microsoft.Maintainability", "SA1402:FileMayOnlyContainASingleType", Justification = "Makes sense to keep generic and non-generic together")]
    public abstract class AggregateRoot<TId> : Entity<TId>
    {
        protected AggregateRoot(TId id) : base(id)
        {
        }
    }
}