namespace Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Models
{
    public interface IDomainEventSubscription
    {
        void ExecuteCallback(DomainEvent domainEvent);
    }
}