using E_Commerce.Doamin.Common;
using E_Commerce.Doamin.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Specification
{
    public class BaseSpecification<TEntity, TKey> : ISpecification<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public ICollection<Expression<Func<TEntity,object>>>IncludeExpressions{ get; set; } = [];

        public Expression<Func<TEntity, bool>> Criteria { get; private set; }

        public Expression<Func<TEntity, object>>? orderBy  { get; private set; }

        public Expression<Func<TEntity, object>>? orderByDescending { get; private set; }

        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPaginated { get; private set; }
        public BaseSpecification(Expression<Func<TEntity, bool>> expression)
        {
            Criteria = expression;
        }
        protected void AddInclude(Expression<Func<TEntity, object>> expression)
        { 
            IncludeExpressions.Add(expression); 
        }

        protected void AddCriteria(Expression<Func<TEntity, bool>> expression)
        {
            Criteria = expression;
        }

        protected void AddOrderBy(Expression<Func<TEntity, object>> expression)
        {
            orderBy=expression;
        }
        protected void AddOrderByDescending(Expression<Func<TEntity, object>> expression)
        {
            orderByDescending = expression;
        }

        protected void ApplyPagination (int pageIndex, int pageSize )
        {
            Take =  pageSize ;
            Skip = (pageIndex-1)*pageSize;
            IsPaginated = true ;
        }

    }
}

