using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.Quests
{
    public interface IQuestRepository
    {
        void Clear(string iD);
        void Add(Quest quest, string iD);
        List<Quest> GetAll(string accountID);
    }
}
