using System;

namespace MatchInformation.Application.Models
{
    public class MatchDto
    {
        public Guid ID { get; set; }
        public string Description { get; set; }
        public DateTime MatchDate { get; set; }
        public TimeSpan MatchTime => MatchDate.TimeOfDay;
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public Sport Sport { get; set; }
    }
}

