using System;
using System.Linq.Expressions;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.DomainExtensions.Areas.Specifications.Core.Servants;

namespace Mmu.Mlh.DomainExtensions.Areas.Specifications.Core
{
    public class OrSpecification<T, TId> : SpecificationBase<T, TId>
        where T : AggregateRoot<TId>
    {
        private readonly SpecificationBase<T, TId> _left;
        private readonly SpecificationBase<T, TId> _right;

        public OrSpecification(SpecificationBase<T, TId> left, SpecificationBase<T, TId> right)
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = _left.ToExpression();
            var rightExpression = _right.ToExpression();
            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.OrElse(leftExpression.Body, rightExpression.Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            
            if (exprBody == null)
            {
                throw new NotSupportedException("ExprBody null");
            }

            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

            return finalExpr;
        }
    }
}