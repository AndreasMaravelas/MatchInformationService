using MatchInformation.Application.Models;
using MatchInformation.Application.Responses;

namespace MatchInformation.Application.Features.MatchOdds.Commands.CreateMatchOdds
{
    public class CreateMatchOddsResponse : BaseResponse
    {
        public MatchOddsDto MatchOdds { get; set; }
    }
}
