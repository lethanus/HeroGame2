using HeroesGame.Characters;
using System.Collections.Generic;

namespace HeroesGame.Mercenaries
{
    public interface IMercenaryRepository
    {
        void Add(Character mercenary, string accountID);
        List<Character> GetAll(string accountID);
    }


}
