using MatchInformation.Application.Contracts.Persistence;
using MatchInformation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MatchInformation.Persistence.Repositories
{
    public class MatchRepository : BaseRepository<MatchEntity>, IMatchRepository
    {
        public MatchRepository(MatchInformationDbContext context) : base(context)
        {
        }

        public async Task<List<MatchEntity>> GetPagedMatchesForPeriod(DateTime startDate, DateTime endDate, int page, int size, CancellationToken token = default)
        {
            return await _dbContext.Matches
                .Where(x => x.CreatedDate >= startDate && x.CreatedDate <= endDate)
                .Skip((page - 1) * size)
                .Take(size)
                .AsNoTracking()
                .ToListAsync(token);
        }
    }
}
