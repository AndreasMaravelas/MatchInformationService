using MatchInformation.Domain.Common;
using System;
using System.Collections.Generic;

namespace MatchInformation.Domain.Entities
{
    public class MatchEntity : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime MatchDateTime { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public Sport Sport { get; set; }
        public IEnumerable<MatchOddsEntity> Odds { get; set; }
    }
}
