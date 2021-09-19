using MatchInformation.Application.Contracts.Persistence;
using MatchInformation.Domain.Entities;

namespace MatchInformation.Persistence.Repositories
{
    public class MatchOddsRepository : BaseRepository<MatchOddsEntity>, IMatchOddsRepository
    {
        public MatchOddsRepository(MatchInformationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
