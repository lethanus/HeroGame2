using System.Collections.Generic;

namespace HeroesGame.Mercenaries
{
    public interface IMercenaryTemplateRepository
    {
        void Add(MercenaryTemplate mercenaryTemplate);
        List<MercenaryTemplate> GetAll();
    }


}
