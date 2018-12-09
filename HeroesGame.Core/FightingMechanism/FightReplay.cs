using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesGame.Characters;

namespace HeroesGame.FightMechanizm
{
    public class FightReplay
    {
        public List<ICharacterInTeam> TeamA { get; set; }
        public List<ICharacterInTeam> TeamB { get; set; }
        public Dictionary<int, FightAction> Actions { get; set; }
        public FightResult FightResult { get; set; }
    }
}
