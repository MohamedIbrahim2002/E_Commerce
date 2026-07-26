using E_Commerce.Doamin.Common;
using E_Commerce.Doamin.Contracts.Repositories;
using E_Commerce.Doamin.Specification;
using E_Commerce.Infrastructure.Data;
using E_Commerce.Infrastructure.Specification;
using Microsoft.EntityFrameworkCore; 

namespace E_Commerce.Infrastructure.Repositories
{
    public class GenaricRepository<TEntity, TKey>(StoreDbContext context) : IGenaricRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>

    {
        public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken ct = default)
        {

              return await context.Set<TEntity>().ToListAsync(ct);

        }

        public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken ct = default)
             => await context.Set<TEntity>().FindAsync(id, ct);
        public void Add(TEntity entity)
             =>context.Set<TEntity>().Add(entity);
        public void Update(TEntity entity)
            =>context.Set<TEntity>().Update(entity);
            
        public void Delete(TEntity entity)
            =>context.Set<TEntity>().Remove(entity);

        public async Task<IReadOnlyList<TEntity>>GetAllAsync(ISpecification<TEntity,TKey> specs,CancellationToken ct=default)
        {
          return await SpecificationEvaluator.CreateQuery(context.Set<TEntity>(),specs).ToListAsync(ct);


        }

        public async Task<TEntity?> GetByIdAsync(ISpecification<TEntity, TKey> specs, CancellationToken ct = default)
        {
            return await SpecificationEvaluator.CreateQuery(context.Set<TEntity>(),specs).FirstOrDefaultAsync(ct);
        }

        public async Task<int> CountAsync(ISpecification<TEntity, TKey> specs, CancellationToken ct = default)
        {
            return await SpecificationEvaluator.CreateQuery(context.Set<TEntity>(),specs).CountAsync(ct);

        }
    }
}
