namespace Mmu.Mlh.DomainExtensions.Areas.DomainModeling
{
    public abstract class AggregateRoot : Entity<object>
    {
        protected AggregateRoot(object id) : base(id)
        {
        }
    }

    public abstract class AggregateRoot<TId> : Entity<TId>
    {
        protected AggregateRoot(TId id) : base(id)
        {
        }
    }
}