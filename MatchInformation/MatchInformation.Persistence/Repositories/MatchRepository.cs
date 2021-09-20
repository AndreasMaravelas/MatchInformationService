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

        public async Task<MatchEntity> GetWithOddsAsync(Guid id, bool? withOdds, CancellationToken token = default)
        {
            //var result = await DbSet
            //    .Where(a => a.Id == id)
            //    .Include(d => d.Odds.Where(o => o.MatchId == id))
            //    .FirstOrDefaultAsync();

            var query = DbSet
                .Where(a => a.Id == id);

            if(withOdds.HasValue && withOdds.Value)
            {
                query = query.Include(d => d.Odds.Where(o => o.MatchId == id));
            }

            return await query.FirstOrDefaultAsync(token); ;
        }
    }
}
