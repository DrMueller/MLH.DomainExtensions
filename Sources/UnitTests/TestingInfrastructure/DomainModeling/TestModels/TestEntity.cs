using JetBrains.Annotations;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;

namespace Mmu.Mlh.DomainExtensions.UnitTests.TestingInfrastructure.DomainModeling.TestModels
{
    [PublicAPI]
    public class TestEntity : Entity<string>
    {
        public string StringProperty1 { get; set; }

        public TestEntity(string id) : base(id)
        {
        }
    }
}