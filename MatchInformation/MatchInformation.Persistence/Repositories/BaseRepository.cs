using MatchInformation.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MatchInformation.Persistence.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly MatchInformationDbContext _dbContext;
        protected DbSet<T> DbSet { get; }

        public BaseRepository(MatchInformationDbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = dbContext.Set<T>();
        }

        public virtual async Task<T> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken token = default)
        {
            return await _dbContext.Set<T>().ToListAsync(token);
        }

        public async virtual Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size, CancellationToken token = default)
        {
            return await _dbContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync(token);
        }

        public async Task<T> AddAsync(T entity, CancellationToken token = default)
        {
            await _dbContext.Set<T>().AddAsync(entity, token);
            await _dbContext.SaveChangesAsync(token);

            return entity;
        }

        public async Task UpdateAsync(T entity, CancellationToken token = default)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task DeleteAsync(T entity, CancellationToken token = default)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync(token);
        }
    }
}
