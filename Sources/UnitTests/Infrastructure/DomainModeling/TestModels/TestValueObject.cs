using System;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;

namespace Mmu.Mlh.DomainExtensions.UnitTests.Infrastructure.DomainModeling.TestModels
{
    public class TestValueObject : ValueObject<TestValueObject>
    {
        public TestValueObject(string property1, int property2, DateTime property3)
        {
            Property1 = property1;
            Property2 = property2;
            Property3 = property3;
        }

        public string Property1 { get; }
        public int Property2 { get; }
        public DateTime Property3 { get; }
    }
}