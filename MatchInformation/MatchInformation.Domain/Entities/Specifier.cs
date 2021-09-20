﻿using System.ComponentModel;

namespace MatchInformation.Domain.Entities
{
    public enum Specifier
    {
        [Description("1")]
        Home = 1,
        [Description("2")]
        Away = 2,
        [Description("x")]
        Draw = 3
    }
}
