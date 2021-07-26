using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSBot.Entities.Abstract;

namespace TSBot.Data.Abstract
{
    public interface IGenericRepository<TEntity>
        where TEntity : IBaseEntity
    {
        public Task AddAsync(TEntity entity);
        public Task<TEntity> FindByIdAsync(int id);
        public Task AddRangeAsync(IEnumerable<TEntity> entities);
        public Task<TEntity> Update(TEntity entity);
        public Task<IEnumerable<TEntity>> Get();
        public Task<IEnumerable<TEntity>> Get(Func<TEntity, bool> func);
        public Task<bool> Remove(TEntity entity);



        
    }
}
