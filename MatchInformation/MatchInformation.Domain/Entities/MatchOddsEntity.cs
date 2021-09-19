using MatchInformation.Domain.Common;
using System;

namespace MatchInformation.Domain.Entities
{
    public class MatchOddsEntity : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid MatchId { get; set; }
        public string Specifier { get; set; }
        public string Odd { get; set; }
        public MatchEntity Match { get; set; }
    }
}
