using MatchInformation.Application.Models;
using MatchInformation.Application.Responses;

namespace MatchInformation.Application.Features.Match.Commands.CreateMatch
{
    public class CreateMatchResponse : BaseResponse
    {
        public MatchDto Match { get; set; }
    }
}
