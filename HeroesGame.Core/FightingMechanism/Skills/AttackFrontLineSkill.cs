using System.Collections.Generic;
using System.Linq;
using HeroesGame.Characters;

namespace HeroesGame.FightMechanizm
{
    public class AttackFrontLineSkill : Skill
    {
        public List<ICharacterInTeam> GetTargets(List<ICharacterInTeam> liveCharacters)
        {
            var targets = liveCharacters.Where(x => TeamPositionHelper.FrontLane.Contains(x.GetPosition()));
            if (targets.Count() == 0)
            {
                targets = liveCharacters.Where(x => TeamPositionHelper.MiddleLane.Contains(x.GetPosition()));
                if (targets.Count() == 0)
                {
                    targets = liveCharacters.Where(x => TeamPositionHelper.RearLane.Contains(x.GetPosition()));
                }
            }
            return targets.ToList();
        }
    }
}
