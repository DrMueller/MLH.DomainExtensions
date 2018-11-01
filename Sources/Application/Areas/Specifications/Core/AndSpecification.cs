using System;
using System.Linq.Expressions;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.DomainExtensions.Areas.Specifications.Core.Servants;

namespace Mmu.Mlh.DomainExtensions.Areas.Specifications.Core
{
    public sealed class AndSpecification<T, TId> : SpecificationBase<T, TId>
        where T : AggregateRoot<TId>
    {
        private readonly SpecificationBase<T, TId> _left;
        private readonly SpecificationBase<T, TId> _right;

        public AndSpecification(SpecificationBase<T, TId> left, SpecificationBase<T, TId> right)
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = _left.ToExpression();
            var rightExpression = _right.ToExpression();

            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.AndAlso(leftExpression.Body, rightExpression.Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

            return finalExpr;
        }
    }
}