using MatchInformation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MatchInformation.Application.Contracts.Persistence
{
    public interface IMatchRepository : IRepository<MatchEntity>
    {
        Task<MatchEntity> GetWithOddsAsync(Guid id, bool? withOdds, CancellationToken token = default);
        Task<List<MatchEntity>> GetPagedMatchesForPeriod(DateTime startDate, DateTime endDate, int page, int size, CancellationToken token = default);
    }
}
