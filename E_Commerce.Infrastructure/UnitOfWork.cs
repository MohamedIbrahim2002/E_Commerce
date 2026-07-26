using E_Commerce.Doamin.Common;
using E_Commerce.Doamin.Contracts;
using E_Commerce.Doamin.Contracts.Repositories;
using E_Commerce.Infrastructure.Data;
using E_Commerce.Infrastructure.Repositories;


namespace E_Commerce.Infrastructure
{
    public class UnitOfWork(StoreDbContext dbContext) : IUnitOfWork
    {
        private readonly Dictionary<string, object> _repositories = [];
        public IGenaricRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var typeName = typeof(TEntity).Name;
            if (_repositories.TryGetValue(typeName,out object? value))
              return (IGenaricRepository<TEntity,TKey>) value;
            
            var repo = new GenaricRepository<TEntity,TKey>(dbContext);
            _repositories.Add(typeName, repo);
            return repo;    

        }

        public async Task<int> SaveChangesAsync(CancellationToken ct = default)
        => await dbContext.SaveChangesAsync(ct);
    }
}
