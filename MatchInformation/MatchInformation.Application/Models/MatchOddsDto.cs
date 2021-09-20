using System;

namespace MatchInformation.Application.Models
{
    public class MatchOddsDto
    {
        public Guid ID { get; set; }
        public Guid MatchId { get; set; }
        public Specifier Specifier { get; set; }
        public double Odd { get; set; }
    }
}
