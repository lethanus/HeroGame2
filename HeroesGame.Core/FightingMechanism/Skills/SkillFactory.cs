using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.FightMechanizm
{
    public enum SkillType { Mass_All, Mass_Front, Range_One_LowHp, Range_One_First }
    public class SkillFactory
    {
        public static Skill CreateSkill(string skillTypeString)
        {
            var skillType = Convert(skillTypeString);
            Skill skill = null;
            switch(skillType)
            {
                case  SkillType.Mass_All:
                    skill = new AttackAllSkill();
                    break;
                case SkillType.Mass_Front:
                    skill = new AttackFrontLineSkill();
                    break;
                case SkillType.Range_One_First:
                    skill = new AttackRangeOneSkill();
                    break;
                case SkillType.Range_One_LowHp:
                    skill = new AttackRangeOneWithLowestHpSkill();
                    break;

            }


            return skill; 
        }

        private static SkillType? Convert(string skillTypeString)
        {
            SkillType? skillType = null; 
            switch (skillTypeString)
            {
                case "Range_One_First":
                    skillType = SkillType.Range_One_First;
                    break;
                case "Range_One_LowHp":
                    skillType = SkillType.Range_One_LowHp;
                    break;
                case "Mass_All":
                    skillType = SkillType.Mass_All;
                    break;
                case "Mass_Front":
                    skillType = SkillType.Mass_Front;
                    break;
            }

            return skillType;
        }

    }
}
