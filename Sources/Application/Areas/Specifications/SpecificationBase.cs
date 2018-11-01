using System;
using System.Linq.Expressions;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.DomainExtensions.Areas.Specifications.Core;

namespace Mmu.Mlh.DomainExtensions.Areas.Specifications
{
    public abstract class SpecificationBase<T, TId> : ISpecification<T, TId>
        where T : AggregateRoot<TId>
    {
        public SpecificationBase<T, TId> And(SpecificationBase<T, TId> specification)
        {
            return new AndSpecification<T, TId>(this, specification);
        }

        public bool IsSatisfiedBy(T aggregateRoot)
        {
            var predicate = ToExpression().Compile();
            var result = predicate(aggregateRoot);

            return result;
        }

        public SpecificationBase<T, TId> Not()
        {
            return new NotSpecification<T, TId>(this);
        }

        public SpecificationBase<T, TId> Or(SpecificationBase<T, TId> specification)
        {
            return new OrSpecification<T, TId>(this, specification);
        }

        public abstract Expression<Func<T, bool>> ToExpression();
    }
}