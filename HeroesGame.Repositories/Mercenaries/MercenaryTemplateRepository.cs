using System.Collections.Generic;
using HeroesGame.Mercenaries;

namespace HeroesGame.Repositories
{
    public class MercenaryTemplateRepository : IMercenaryTemplateRepository
    {
        private List<MercenaryTemplate> _mercenaryTemplates = new List<MercenaryTemplate>();
        public void AddMercenaryTemplate(MercenaryTemplate mercenary)
        {
            _mercenaryTemplates.Add(mercenary);
        }

        public List<MercenaryTemplate> GetMercenaryTemplates()
        {
            return _mercenaryTemplates;
        }
    }


}
