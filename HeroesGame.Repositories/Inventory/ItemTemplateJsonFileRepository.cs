using System.Collections.Generic;
using HeroesGame.Inventory;
using Newtonsoft.Json;
using System.IO;

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
            var templates = GetAllItemTemplates(_pathToRepoFile);
            templates.Add(template);
            SaveAllItemTemplates(templates, _pathToRepoFile);
        }

        public List<ItemTemplate> GetAllTemplates()
        {
            return GetAllItemTemplates(_pathToRepoFile);
        }


        private List<ItemTemplate> GetAllItemTemplates(string pathToFile)
        {
            if (!File.Exists(pathToFile))
            {
                return new List<ItemTemplate>();
            }
            var json = File.ReadAllText(pathToFile);
            return JsonConvert.DeserializeObject<List<ItemTemplate>>(json);
        }

        private void SaveAllItemTemplates(List<ItemTemplate> templates, string pathToFile)
        {
            string json = JsonConvert.SerializeObject(templates, Formatting.Indented);
            File.WriteAllText(pathToFile, json);
        }
    }
}
