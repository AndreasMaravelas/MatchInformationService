using MediatR;
using System;

namespace MatchInformation.Application.Features.Match.Commands.DeleteMatchOdds
{
    public class DeleteMatchOddsCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
