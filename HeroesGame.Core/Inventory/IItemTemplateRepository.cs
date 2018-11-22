using System.Collections.Generic;


namespace HeroesGame.Inventory
{
    public interface IItemTemplateRepository
    {
        void Add(ItemTemplate template);
        List<ItemTemplate> GetAll();
    }
}
