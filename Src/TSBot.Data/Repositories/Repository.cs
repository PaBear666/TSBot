using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSBot.Data.Repositories.Abstract;
using TSBot.Data.Entity.Abstract;
using System;
using System.Linq;

namespace TSBot.Data.Repositories
{
    abstract public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly ApplicationContext _context;
        public Repository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        public async Task<TEntity> Get(long id)
        {
            return await _context.Set<TEntity>().Where(x => x.Id == id).LastAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public abstract Task<long> GetId(TEntity entity);

        public async Task<bool> Remove(TEntity entity)
        {
            await Task.Run(()=>_context.Set<TEntity>().Remove(entity));
            await _context.SaveChangesAsync();
            return false;
            
        }

        public Task<bool> RemoveRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
