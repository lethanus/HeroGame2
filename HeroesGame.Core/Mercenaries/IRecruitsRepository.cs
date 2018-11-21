using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.Mercenaries
{
    public interface IRecruitsRepository
    {
        void Add(Mercenary recruit, string accountID);
        List<Mercenary> GetAllRecruitsForUser(string accountID);
        void Clear(string accountID);
        void Remove(Mercenary recruit, string accountID);
    }
}
