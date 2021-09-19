using MediatR;
using System;

namespace MatchInformation.Application.Features.Match.Commands.DeleteMatch
{
    public class DeleteMatchCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
