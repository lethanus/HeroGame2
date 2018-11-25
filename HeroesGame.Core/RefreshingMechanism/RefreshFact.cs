using System;
using HeroesGame.Common;

namespace HeroesGame.RefresingMechanism
{
    public enum RefreshOption { Mercenaries, Quests }
    public class RefreshFact : ObjectWithID
    {
        public RefreshOption Option { get; set; }
        public DateTime LastAction { get; set; }

    }
}
