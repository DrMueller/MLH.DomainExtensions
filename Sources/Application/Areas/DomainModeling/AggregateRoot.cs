namespace Mmu.Mlh.DomainExtensions.Areas.DomainModeling
{
    public abstract class AggregateRoot : Entity
    {
        protected AggregateRoot(string id) : base(id)
        {
        }
    }
}