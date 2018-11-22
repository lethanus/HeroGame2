using System.Collections.Generic;


namespace HeroesGame.Inventory
{
    public interface IItemTemplateRepository
    {
        void AddTemplate(ItemTemplate template);
        List<ItemTemplate> GetAllTemplates();
    }
}
