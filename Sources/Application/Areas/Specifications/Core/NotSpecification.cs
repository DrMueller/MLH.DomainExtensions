using System;
using System.Linq.Expressions;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.DomainExtensions.Areas.Specifications.Core.Servants;

namespace Mmu.Mlh.DomainExtensions.Areas.Specifications.Core
{
    public class NotSpecification<T, TId> : SpecificationBase<T, TId>
        where T : AggregateRoot<TId>
    {
        private readonly SpecificationBase<T, TId> _spec;

        public NotSpecification(SpecificationBase<T, TId> spec)
        {
            _spec = spec;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var specExpression = _spec.ToExpression();

            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.Not(specExpression.Body);

            var visitedExpr = new ParameterReplacer(paramExpr).Visit(exprBody);

            if (visitedExpr == null)
            {
                throw new NotSupportedException("ExprBody null");
            }

            var finalExpr = Expression.Lambda<Func<T, bool>>(visitedExpr, paramExpr);

            return finalExpr;
        }
    }
}