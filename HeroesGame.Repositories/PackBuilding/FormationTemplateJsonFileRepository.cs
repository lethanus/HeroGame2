using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesGame.PackBuilding;

namespace HeroesGame.Repositories
{
    public class FormationTemplateJsonFileRepository : JsonListRepository<FormationTemplate>, IFormationTemplateRepository
    {
        public FormationTemplateJsonFileRepository(string pathToRepoFile) : base(pathToRepoFile) { }
    }
}
