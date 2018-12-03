using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.Quests
{
    public class RewardTemplatesCollectionGenerator
    {
        public static List<RewardTemplate> Generate()
        {
            var tempaltes = new List<RewardTemplate>();
            tempaltes.Add(new RewardTemplate
            {
                ID = "R_1",
                Level = "1",
                Rewards = "1_Beer"
            });
            tempaltes.Add(new RewardTemplate
            {
                ID = "R_2",
                Level = "2",
                Rewards = "2_Beer"
            });
            tempaltes.Add(new RewardTemplate
            {
                ID = "R_3",
                Level = "3",
                Rewards = "3_Beer"
            });
            tempaltes.Add(new RewardTemplate
            {
                ID = "R_4",
                Level = "4",
                Rewards = "4_Beer"
            });
            tempaltes.Add(new RewardTemplate
            {
                ID = "R_5",
                Level = "1",
                Rewards = "1_Wine"
            });
            tempaltes.Add(new RewardTemplate
            {
                ID = "R_6",
                Level = "2",
                Rewards = "2_Wine"
            });
            tempaltes.Add(new RewardTemplate
            {
                ID = "R_7",
                Level = "3",
                Rewards = "3_Wine"
            });
            tempaltes.Add(new RewardTemplate
            {
                ID = "R_8",
                Level = "4",
                Rewards = "4_Wine"
            });
            return tempaltes;
        }
    }
}
