using System.Collections.Generic;

namespace HeroesGame.PackBuilding
{
    public interface IFormationTemplateRepository
    {
        void Add(FormationTemplate template);
        List<FormationTemplate> GetAll();
    }

}
