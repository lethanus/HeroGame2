using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.Inventory
{
    public class ItemTemplatesCollectionGenerator
    {
        public static List<ItemTemplate> Generate()
        {
            var tempaltes = new List<ItemTemplate>();
            tempaltes.Add(new ItemTemplate
            {
                ID = "TR_1",
                Name = "Rat tail",
                Category = ItemCategory.Trophy,
                Effects = "Mercenary_Convince_Chance_(+1%)"
            });
            tempaltes.Add(new ItemTemplate
            {
                ID = "TR_2",
                Name = "Wolf pelt",
                Category = ItemCategory.Trophy,
                Effects = "Mercenary_Convince_Chance_(+1%)"
            });
            tempaltes.Add(new ItemTemplate
            {
                ID = "TR_3",
                Name = "Spider jaws",
                Category = ItemCategory.Trophy,
                Effects = "Mercenary_Convince_Chance_(+1%)"
            });

            tempaltes.Add(new ItemTemplate
            {
                ID = "TR_4",
                Name = "Trolls head",
                Category = ItemCategory.Trophy,
                Effects = "Mercenary_Convince_Chance_(+3%)"
            });

            return tempaltes;
        }
    }
}
