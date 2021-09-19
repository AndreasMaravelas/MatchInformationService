using MatchInformation.Application.Models;
using MediatR;
using System;

namespace MatchInformation.Application.Features.Match.Commands.UpdateMatch
{
    public class UpdateMatchCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime MatchDate { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public Sport Sport { get; set; }
    }
}
