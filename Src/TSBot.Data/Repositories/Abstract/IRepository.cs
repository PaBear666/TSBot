using System.Collections.Generic;
using System.Threading.Tasks;
using TSBot.Data.Entity.Abstract;

namespace TSBot.Data.Repositories.Abstract
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<TEntity> Get(long id);
        Task<IEnumerable<TEntity>> GetAll();
        abstract Task<long> GetId(TEntity entity);
        Task<TEntity> Add(TEntity entity);
        Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> entities);
        Task<bool> Remove(TEntity entity);
        Task<bool> RemoveRange(IEnumerable<TEntity> entities);
    }
}
