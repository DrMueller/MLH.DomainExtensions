using Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Models;
using Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Services;
using StructureMap;

namespace Mmu.Mlh.DomainExtensions.Infrastructure.DependencyInjection
{
    public class DomainExtensionsRegistry : Registry
    {
        public DomainExtensionsRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssembliesAndExecutablesFromApplicationBaseDirectory();
                    scanner.AddAllTypesOf<DomainEvent>();
                    scanner.WithDefaultConventions();
                });

            For<IDomainEventSubscriptionService>().Singleton();
            For<IDomainEventPublishingService>().Singleton();
        }
    }
}