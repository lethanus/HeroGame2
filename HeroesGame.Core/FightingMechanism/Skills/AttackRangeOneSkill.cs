using System.Collections.Generic;
using System.Linq;
using HeroesGame.Characters;

namespace HeroesGame.FightMechanizm
{
    public class AttackRangeOneSkill : Skill
    {
        public List<ICharacterInTeam> GetTargets(List<ICharacterInTeam> liveCharacters)
        {
            var targets = new List<ICharacterInTeam>();
            var target = liveCharacters.FirstOrDefault(x => TeamPositionHelper.MiddleLane.Contains(x.GetPosition()));
            if (target == null)
            {
                target = liveCharacters.FirstOrDefault(x => TeamPositionHelper.RearLane.Contains(x.GetPosition()));
                if (target == null)
                {
                    target = liveCharacters.FirstOrDefault(x => TeamPositionHelper.FrontLane.Contains(x.GetPosition()));
                }
            }
            if (target != null) targets.Add(target);
            return targets;
        }
    }
}
