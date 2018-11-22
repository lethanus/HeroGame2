using System.Collections.Generic;
using HeroesGame.Inventory;

namespace HeroesGame.Repositories
{
    public class ItemTemplateJsonFileRepository : IItemTemplateRepository
    {
        private List<ItemTemplate> _itemTemplates = new List<ItemTemplate>();
        private string _pathToRepoFile;

        public ItemTemplateJsonFileRepository(string pathToRepoFile)
        {
            _pathToRepoFile = pathToRepoFile;
        }

        public void AddTemplate(ItemTemplate template)
        {
            _itemTemplates.Add(template);
        }

        public List<ItemTemplate> GetAllTemplates()
        {
            return _itemTemplates;
        }
    }
}
