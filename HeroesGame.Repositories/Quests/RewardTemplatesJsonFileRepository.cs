using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesGame.Quests;

namespace HeroesGame.Repositories
{
    public class RewardTemplatesJsonFileRepository : JsonListRepository<RewardTemplate>, IRewardTemplatesRepository
    {
        public RewardTemplatesJsonFileRepository(string pathToRepoFile) : base(pathToRepoFile) { }
    }
}
