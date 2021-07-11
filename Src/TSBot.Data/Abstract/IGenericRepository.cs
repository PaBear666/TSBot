using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSBot.Entities.Abstract;

namespace TSBot.Data.Abstract
{
    interface IGenericRepository<TEntity>
        where TEntity : IBaseEntity
    {
        Task AddAsync(TEntity entity);
        Task<TEntity> FindByIdAsync(int id);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task<TEntity> Update(TEntity entity);
        Task<IEnumerable<TEntity>> Get();
        Task<IEnumerable<TEntity>> Get(Func<TEntity, bool> func);
        Task<bool> Remove(TEntity entity);



        
    }
}
