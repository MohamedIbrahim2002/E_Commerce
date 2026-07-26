using E_Commerce.Doamin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Doamin.Specification
{
    public interface ISpecification<TEntity ,TKey> where TEntity : BaseEntity<TKey>
    {
        // include related data list of include 0 to ....
        ICollection<Expression<Func<TEntity, object>>> IncludeExpressions { get; }
        //include and filteraing
        Expression<Func<TEntity,bool>> Criteria { get; }
        Expression<Func<TEntity,object>>? orderBy { get; }
        Expression<Func<TEntity,object>>? orderByDescending { get; }
        int Take { get; }
        int Skip { get; }
        bool IsPaginated { get; }
    }
}
