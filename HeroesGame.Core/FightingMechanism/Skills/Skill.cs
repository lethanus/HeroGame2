using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesGame.Characters;

namespace HeroesGame.FightMechanizm
{
    public interface Skill
    {
        List<ICharacterInTeam> GetTargets(List<ICharacterInTeam> liveCharacters);
    }
}
