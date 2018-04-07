using System;
using System.Linq.Expressions;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;

namespace Mmu.Mlh.DomainExtensions.Areas.Specifications
{
    public interface ISpecification<T>
        where T : AggregateRoot
    {
        bool IsSatisfiedBy(T aggregateRoot);

        Expression<Func<T, bool>> ToExpression();
    }
}