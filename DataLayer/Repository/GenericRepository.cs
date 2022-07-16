using DataLayer.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class GenericRepository : IRepository
    {
        private readonly ApplicationContext _dbContext;
        public GenericRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TEntity> Create<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task Delete<TEntity>(TEntity entity) where TEntity : class
        {
            var entit = await _dbContext.FindAsync<TEntity>();
            if(entit != null)
            {
                _dbContext.Remove(entit);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<List<TEntity>> GetAll<TEntity>() where TEntity : class
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }
        public async Task<TEntity> GetById<TEntity>(Guid guid) where TEntity : class
        {
            return await _dbContext.FindAsync<TEntity>(guid);
        }
        public async Task Update<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Update<TEntity>(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}