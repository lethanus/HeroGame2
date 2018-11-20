using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesGame.Mercenaries;

namespace HeroesGame.Mercenaries
{
    public class MercenaryTemplatesCollectionGenerator
    {
        public static List<MercenaryTemplate> Generate()
        {
            var tempaltes = new List<MercenaryTemplate>();
            tempaltes.Add(new MercenaryTemplate
            {
                Level = "1",
                Name = "Goblin",
                HP_range = "18-22",
                Min_Attack_range = "8-12",
                Attack_add_for_max = "4",
                Defence_range = "8-12",
                Speed_range = "8-10"
            });
            tempaltes.Add(new MercenaryTemplate
            {
                Level = "2",
                Name = "Goblin",
                HP_range = "22-26",
                Min_Attack_range = "12-16",
                Attack_add_for_max = "4",
                Defence_range = "10-14",
                Speed_range = "9-11"
            });
            tempaltes.Add(new MercenaryTemplate
            {
                Level = "3",
                Name = "Goblin",
                HP_range = "26-34",
                Min_Attack_range = "16-24",
                Attack_add_for_max = "4",
                Defence_range = "10-12",
                Speed_range = "9-11"
            });
            tempaltes.Add(new MercenaryTemplate
            {
                Level = "4",
                Name = "Goblin",
                HP_range = "40-55",
                Min_Attack_range = "30-40",
                Attack_add_for_max = "4",
                Defence_range = "18-22",
                Speed_range = "11-13"
            });
            tempaltes.Add(new MercenaryTemplate
            {
                Level = "1",
                Name = "Elf",
                HP_range = "18-22",
                Min_Attack_range = "8-12",
                Attack_add_for_max = "4",
                Defence_range = "8-12",
                Speed_range = "8-10"
            });
            tempaltes.Add(new MercenaryTemplate
            {
                Level = "1",
                Name = "Ork",
                HP_range = "18-22",
                Min_Attack_range = "8-12",
                Attack_add_for_max = "4",
                Defence_range = "8-12",
                Speed_range = "8-10"
            });
            tempaltes.Add(new MercenaryTemplate
            {
                Level = "2",
                Name = "Ork",
                HP_range = "22-26",
                Min_Attack_range = "12-16",
                Attack_add_for_max = "4",
                Defence_range = "10-14",
                Speed_range = "9-11"
            });
            tempaltes.Add(new MercenaryTemplate
            {
                Level = "2",
                Name = "Elf",
                HP_range = "22-26",
                Min_Attack_range = "12-16",
                Attack_add_for_max = "4",
                Defence_range = "10-14",
                Speed_range = "9-11"
            });


            return tempaltes;
        }
    }
}

