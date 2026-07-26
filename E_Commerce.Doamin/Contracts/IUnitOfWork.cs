using E_Commerce.Doamin.Common;
using E_Commerce.Doamin.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Doamin.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken ct = default);

        IGenaricRepository<TEntity , TKey> GetRepository<TEntity , TKey>()
            where TEntity:BaseEntity<TKey> ;


    }
}
