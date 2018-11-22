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
                Category = "Trophy"
            });
            tempaltes.Add(new ItemTemplate
            {
                ID = "TR_2",
                Name = "Wolf pelt",
                Category = "Trophy"
            });
            tempaltes.Add(new ItemTemplate
            {
                ID = "TR_3",
                Name = "Spider jaws",
                Category = "Trophy"
            });

            return tempaltes;
        }
    }
}
