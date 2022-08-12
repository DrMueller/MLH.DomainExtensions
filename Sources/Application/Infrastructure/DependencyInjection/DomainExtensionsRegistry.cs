using Lamar;
using Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Models;
using Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Services;
using Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Services.Implementation;

namespace Mmu.Mlh.DomainExtensions.Infrastructure.DependencyInjection
{
    public class DomainExtensionsRegistry : ServiceRegistry
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

            For<IDomainEventPublishingService>().Use<DomainEventPublishingService>().Singleton();
            For<IDomainEventSubscriptionService>().Use<DomainEventSubscriptionService>().Singleton();
        }
    }
}