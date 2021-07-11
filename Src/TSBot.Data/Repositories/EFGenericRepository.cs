using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSBot.Data.Abstract;
using TSBot.Entities.Abstract;

namespace TSBot.Data.Repositories
{
    class EFGenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity:class,IBaseEntity
    {
        readonly ApplicationContext _context;
        readonly DbSet<TEntity> _dbSet;

        public EFGenericRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException();
            _dbSet = context.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException();
            }
           await _dbSet.AddAsync(entity);
           await _context.SaveChangesAsync();
        }
        
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            if(entities == null)
            {
                throw new ArgumentNullException();
            }
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            if(id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return await Task.Run(() => _dbSet.Where(entity => entity.Id == id).FirstOrDefault());
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            return await Task.Run(() => _dbSet.ToList());
        }

        public async Task<IEnumerable<TEntity>> Get(Func<TEntity, bool> func)
        {
            return await Task.Run(() => _dbSet.Where(func));
        }

        public async Task<bool> Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            if(_dbSet.Where(e => e.Equals(entity)).FirstOrDefault() == null)
            {
                return await Task.Run(() => false);
            }
            else
            {
                entity.IsDelete = true;
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                return await Task.Run(() => true);
            }
            

        }

        public Task<TEntity> Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            if (_dbSet.Where(e => e.Equals(entity)).FirstOrDefault() == null)
            {
                throw new DbUpdateException();
            }
            else
            {
                _dbSet.Update(entity);
                return Task.Run(() => entity);
            }
        }
    }
}
