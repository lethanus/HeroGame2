using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesGame.Quests;

namespace HeroesGame.Repositories
{
    public class QuestsJasonFileRepository : JsonListRepositoryForAccounts<Quest>, IQuestRepository
    {
        public QuestsJasonFileRepository(string directoryPath) : base(directoryPath, "Quests") { }
    }
}
