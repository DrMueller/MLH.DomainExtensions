using Lamar;
using Microsoft.Extensions.DependencyInjection;
using Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Models;
using Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Services;

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
                    scanner.AddAllTypesOf<IDomainEventPublishingService>(ServiceLifetime.Singleton);
                    scanner.AddAllTypesOf<IDomainEventSubscriptionService>(ServiceLifetime.Singleton);
                    scanner.WithDefaultConventions();
                });
        }
    }
}