using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SD.Transfer.Business.Models;

namespace SD.Transfer.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Add(TEntity entity);
        Task<TEntity> Get(string id);
        Task<IEnumerable<TEntity>> Get();        
        Task Update(TEntity entity);
        Task Remove(string id);
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}