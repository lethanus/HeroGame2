using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.PackBuilding
{
    public class FormationTemplatesCollectionGenerator
    {
        public static List<FormationTemplate> Generate()
        {
            var tempaltes = new List<FormationTemplate>();

            tempaltes.Add(new FormationTemplate
            {
                ID = "goblin_1",
                Name = "Goblin easy",
                Level = 1,
                F1 = "Goblin@1",
                F2 = "Goblin@2",
                F3 = "Goblin@1",
                M1 = "Goblin@1",
                M2 = "Goblin@1",
                M3 = "Goblin@2",
                M4 = "Goblin@1"
            });
            tempaltes.Add(new FormationTemplate
            {
                ID = "goblin_2",
                Name = "Goblin normal",
                Level = 2,
                F1 = "Goblin@2",
                F2 = "Goblin@2",
                F3 = "Goblin@2",
                M1 = "Goblin@2",
                M2 = "Goblin@3",
                M3 = "Goblin@2",
                M4 = "Goblin@3",
                R1 = "Goblin@2",
                R2 = "Goblin@2",
                R3 = "Goblin@2"
            });
            tempaltes.Add(new FormationTemplate
            {
                ID = "goblin_3",
                Name = "Goblin hard",
                Level = 3,
                F1 = "Goblin@3",
                F2 = "Goblin@3",
                F3 = "Goblin@3",
                M1 = "Goblin@3",
                M2 = "Goblin@3",
                M3 = "Goblin@3",
                M4 = "Goblin@3",
                R1 = "Goblin@3",
                R2 = "Goblin@3",
                R3 = "Goblin@3"
            });

            return tempaltes;

        }
    }
}
