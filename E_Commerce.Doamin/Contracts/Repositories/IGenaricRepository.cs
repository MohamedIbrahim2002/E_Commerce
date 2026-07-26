using E_Commerce.Doamin.Common;
using E_Commerce.Doamin.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Doamin.Contracts.Repositories
{
    public interface IGenaricRepository<TEntity , TKey> where TEntity : BaseEntity<TKey>

    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void  Delete(TEntity entity);
        Task<TEntity?> GetByIdAsync(TKey id , CancellationToken ct = default);
        Task<TEntity?> GetByIdAsync(ISpecification<TEntity, TKey> specs, CancellationToken ct = default);
        Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken ct = default);
        Task<IReadOnlyList<TEntity>> GetAllAsync(ISpecification<TEntity,TKey> specs ,CancellationToken ct = default);
        Task<int> CountAsync(ISpecification<TEntity,TKey> specs,CancellationToken ct = default);
    }
}
