using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MatchInformation.Application.Contracts.Persistence
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity, CancellationToken token = default);
        Task UpdateAsync(T entity, CancellationToken token = default);
        Task DeleteAsync(T entity, CancellationToken token = default);
        Task<T> GetByIdAsync(Guid id, CancellationToken token = default);
        Task<IReadOnlyList<T>> ListAllAsync(CancellationToken token = default);
        Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size, CancellationToken token = default);
    }
}
