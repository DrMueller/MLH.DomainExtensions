namespace Mmu.Mlh.DomainExtensions.Areas.Factories
{
    public interface IEntityIdFactory<TId>
    {
        TId CreateEntityId();
    }
}