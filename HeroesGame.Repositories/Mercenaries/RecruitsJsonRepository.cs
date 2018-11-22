using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesGame.Mercenaries;
using System.IO;
using Newtonsoft.Json;

namespace HeroesGame.Repositories
{
    public class RecruitsJsonRepository : AccountJsonListRepository<Mercenary>, IRecruitsRepository
    {
        public RecruitsJsonRepository(string directoryPath) : base(directoryPath, "Recruits") { }
    }
}
