using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;

namespace Mmu.Mlh.DomainExtensions.UnitTests.Infrastructure.DomainModeling.TestModels
{
    public class TestEntity : Entity
    {
        public TestEntity(string id) : base(id)
        {
        }

        public string StringProperty1 { get; set; }
    }
}