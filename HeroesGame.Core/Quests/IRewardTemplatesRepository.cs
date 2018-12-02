using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.Quests
{
    public interface IRewardTemplatesRepository
    {
        void Add(RewardTemplate template);
        List<RewardTemplate> GetAll();
    }
}
