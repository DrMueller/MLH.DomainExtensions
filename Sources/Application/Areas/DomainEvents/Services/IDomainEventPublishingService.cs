using Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Models;

namespace Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Services
{
    public interface IDomainEventPublishingService
    {
        void Publish<T>(T domainEvent)
            where T : DomainEvent;
    }
}