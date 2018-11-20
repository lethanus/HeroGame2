using System.Collections.Generic;

namespace HeroesGame.Mercenaries
{
    public interface IMercenaryTemplateRepository
    {
        void AddMercenaryTemplate(MercenaryTemplate mercenary);
        List<MercenaryTemplate> GetMercenaryTemplates();
    }


}
