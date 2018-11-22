using HeroesGame.Characters;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using HeroesGame.Mercenaries;

namespace HeroesGame.Repositories
{
    public class MercenaryJsonFileRepository : AccountJsonListRepository<Character>, IMercenaryRepository
    {

        public MercenaryJsonFileRepository(string directoryPath) : base(directoryPath, "Mercenaries") { }


        public void Add(Character mercenary, string accountID)
        {
            var marcenaries = GetAll(accountID);
            marcenaries.Add(mercenary);
            SaveAll(marcenaries, accountID, _directoryPath);
        }


    }


}
