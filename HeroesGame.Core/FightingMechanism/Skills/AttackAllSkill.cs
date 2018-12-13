using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HeroesGame.Characters;

namespace HeroesGame.FightMechanizm
{
    public class AttackAllSkill : Skill
    {
        public List<ICharacterInTeam> GetTargets(List<ICharacterInTeam> liveCharacters)
        {
            return liveCharacters;
        }
    }
}
