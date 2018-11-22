using System;
using HeroesGame.Common;

namespace HeroesGame.RefresingMechanism
{
    public class RefreshFact : ObjectWithID
    {
        public string Option { get; set; }
        public DateTime LastAction { get; set; }

    }
}
