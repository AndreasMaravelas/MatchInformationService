using System;
using System.Collections.Generic;

namespace MatchInformation.Application.Models
{
    public class MatchDto
    {
        public Guid ID { get; set; }
        public string Description { get; set; }
        public DateTime MatchDateTime { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public Sport Sport { get; set; }
        public IEnumerable<MatchOddsDto> Odds { get; set; }
    }
}

