using System.Collections.Generic;

namespace HeroesGame.Mercenaries
{
    public interface IMercenaryTemplateRepository
    {
        void AddMercenaryTemplate(MercenaryTemplate mercenaryTemplate);
        List<MercenaryTemplate> GetMercenaryTemplates();
    }


}
