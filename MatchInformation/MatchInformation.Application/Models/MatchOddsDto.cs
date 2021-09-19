using System;

namespace MatchInformation.Application.Models
{
    public class MatchOddsDto
    {
        public Guid ID { get; set; }
        public Guid MatchId { get; set; }
        public string Specifier { get; set; }
        public string Odd { get; set; }
    }
}
