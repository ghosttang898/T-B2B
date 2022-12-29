using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
            // Criteria = null!;
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; } = null!;

        public List<Expression<Func<T, object>>> Includes { get; } =
            new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; } = null!;

        public Expression<Func<T, object>> OrderByDescending { get; private set; } = null!;

        public int Task { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        protected void AddInclude(Expression<Func<T, object>> IncludeExpression)
        {
            Includes.Add(IncludeExpression);
        }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpressipon)
        {
            OrderBy = orderByExpressipon;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpressipon)
        {
            OrderByDescending = orderByDescExpressipon;
        }

        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Task = take;
            IsPagingEnabled = true;
        }
    }
}