using E_Commerce.Doamin.Common;
using E_Commerce.Doamin.Specification;
using Microsoft.EntityFrameworkCore;
namespace E_Commerce.Infrastructure.Specification
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>
            (IQueryable<TEntity> inputQuery , ISpecification<TEntity, TKey> specs)
            where TEntity :BaseEntity<TKey>
        {
            // context.set<TEntity>

            var query = inputQuery;

            if(specs.Criteria is not null)
            {
                query = query.Where(specs.Criteria);
            }

            if(specs.IncludeExpressions.Any())
            {
                //query = specs.IncludeExpressions.Aggregate(query, (currentQuerry, includeQuerry) => currentQuerry.Include(includeQuerry));

                foreach (var expression in specs.IncludeExpressions)
                {
                    query = query.Include(expression);
                }
            }

            if(specs.orderBy is not null)
            {
                query=query.OrderBy(specs.orderBy);

            }else if(specs.orderByDescending is not null)

            {
                query=query.OrderByDescending(specs.orderByDescending);

            }
            if(specs.IsPaginated)
            {
                query=query.Skip(specs.Skip).Take(specs.Take);
            }

            return query;

        }
    }
}
