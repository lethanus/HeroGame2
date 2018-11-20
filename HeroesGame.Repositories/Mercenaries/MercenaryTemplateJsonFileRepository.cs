using System.Collections.Generic;
using HeroesGame.Mercenaries;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace HeroesGame.Repositories
{
    public class MercenaryTemplateJsonFileRepository : IMercenaryTemplateRepository
    {
        private string _pathToRepoFile;
        private List<MercenaryTemplate> _mercenaryTemplates = new List<MercenaryTemplate>();

        public MercenaryTemplateJsonFileRepository (string pathToRepoFile)
        {
            _pathToRepoFile = pathToRepoFile;
        }
        public void AddMercenaryTemplate(MercenaryTemplate mercenaryTemplate)
        {
            MercenaryTemplatesCollection mercenaryTemplates = new MercenaryTemplatesCollection();
            foreach (var template in GetMercenaryTemplates())
            {
                mercenaryTemplates.Templates.Add(template);
            }
            mercenaryTemplates.Templates.Add(mercenaryTemplate);

            File.WriteAllText(_pathToRepoFile, JsonConvert.SerializeObject(mercenaryTemplates, Formatting.Indented));
        }

        public List<MercenaryTemplate> GetMercenaryTemplates()
        {
            if (!File.Exists(_pathToRepoFile))
            {
                return new List<MercenaryTemplate>();
            }
            var json = File.ReadAllText(_pathToRepoFile);
            return JsonConvert.DeserializeObject<MercenaryTemplatesCollection>(json).Templates.ToList();
        }
    }

    public class MercenaryTemplatesCollection
    {
        public IList<MercenaryTemplate> Templates { get; set; }
        public MercenaryTemplatesCollection()
        {
            Templates = new List<MercenaryTemplate>();
        }
    }

}
