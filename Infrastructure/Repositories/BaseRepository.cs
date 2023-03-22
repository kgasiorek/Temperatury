using Application.Interfaces.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;

        public BaseRepository(PomTempContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BaseRepository(SettingsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            var result = await _dbContext.Set<T>().ToListAsync();
            return result.AsQueryable();
        }

        public async Task<List<T>> GetAllAsyncList()
        {
            var result = await _dbContext.Set<T>().ToListAsync();
            return result;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
