using System.Collections.Generic;
using System.Linq;
using HeroesGame.Characters;

namespace HeroesGame.FightMechanizm
{
    public class AttackRangeOneWithLowestHpSkill : Skill
    {
        public List<ICharacterInTeam> GetTargets(List<ICharacterInTeam> liveCharacters)
        {
            var targets = new List<ICharacterInTeam>();
            var sortedByHp = liveCharacters.OrderBy(x => x.getHp());
            var target = sortedByHp.FirstOrDefault(x => TeamPositionHelper.MiddleLane.Contains(x.GetPosition()));
            if (target == null)
            {
                target = sortedByHp.FirstOrDefault(x => TeamPositionHelper.RearLane.Contains(x.GetPosition()));
                if (target == null)
                {
                    target = sortedByHp.FirstOrDefault(x => TeamPositionHelper.FrontLane.Contains(x.GetPosition()));
                }
            }
            if (target != null) targets.Add(target);
            return targets;
        }
    }
}
