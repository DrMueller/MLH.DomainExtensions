﻿using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;

namespace Mmu.Mlh.DomainExtensions.UnitTests.Infrastructure.DomainModeling.TestModels
{
    public class TestAggregateRoot : AggregateRoot<string>
    {
        public TestAggregateRoot(string id) : base(id)
        {
        }
    }
}