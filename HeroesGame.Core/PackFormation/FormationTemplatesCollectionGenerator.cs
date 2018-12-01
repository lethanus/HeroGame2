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
                ID = "elf_1",
                Name = "Elf easy",
                Level = 1,
                F1 = "Elf@1",
                F2 = "Elf@2",
                F3 = "Elf@1",
                M1 = "Elf@1",
                M2 = "Elf@1",
                M3 = "Elf@2",
                M4 = "Elf@1"
            });
            tempaltes.Add(new FormationTemplate
            {
                ID = "ork_1",
                Name = "Ork easy",
                Level = 1,
                F1 = "Ork@1",
                F2 = "Ork@2",
                F3 = "Ork@1",
                M1 = "Ork@1",
                M2 = "Ork@1",
                M3 = "Ork@2",
                M4 = "Ork@1"
            });
            tempaltes.Add(new FormationTemplate
            {
                ID = "elf_1",
                Name = "Elf normal",
                Level = 2,
                F1 = "Elf@2",
                F2 = "Elf@2",
                F3 = "Elf@2",
                M1 = "Elf@2",
                M2 = "Elf@2",
                M3 = "Elf@2",
                M4 = "Elf@2",
                R1 = "Elf@2",
                R2 = "Elf@2",
                R3 = "Elf@2"
            });
            tempaltes.Add(new FormationTemplate
            {
                ID = "ork_1",
                Name = "Ork normal",
                Level = 2,
                F1 = "Ork@2",
                F2 = "Ork@2",
                F3 = "Ork@2",
                M1 = "Ork@2",
                M2 = "Ork@2",
                M3 = "Ork@2",
                M4 = "Ork@2",
                R1 = "Ork@2",
                R2 = "Ork@2",
                R3 = "Ork@2"
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
            tempaltes.Add(new FormationTemplate
            {
                ID = "goblin_4",
                Name = "Goblin very hard",
                Level = 4,
                F1 = "Goblin@4",
                F2 = "Goblin@4",
                F3 = "Goblin@4",
                M1 = "Goblin@4",
                M2 = "Goblin@4",
                M3 = "Goblin@4",
                M4 = "Goblin@4",
                R1 = "Goblin@4",
                R2 = "Goblin@4",
                R3 = "Goblin@4"
            });

            return tempaltes;

        }
    }
}
