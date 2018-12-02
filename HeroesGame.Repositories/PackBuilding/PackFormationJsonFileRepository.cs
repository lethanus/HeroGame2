using System.Collections.Generic;
using System.Collections;
using HeroesGame.Characters;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using HeroesGame.PackBuilding;

namespace HeroesGame.Repositories
{
    public class PackFormationJsonFileRepository : JsonListRepositoryForAccounts<CharacterInThePack>, IPackFormationRepository
    {
        public PackFormationJsonFileRepository(string directoryPath) : base(directoryPath, "PackFormation") { }


        public string GetCharacterIdOnPosition(TeamPosition position, string accountID)
        {
            return GetAll(accountID).First(x => x.Position == position).Character_ID;
        }

        public void SetCharacterToPosition(string characterID, TeamPosition position, string accountID)
        {
            var positions = GetAll(accountID);
            positions.First(x => x.Position == position).Character_ID = characterID;
            SaveAll(positions, accountID, _directoryPath);
        }

        public List<CharacterInThePack> GetAll(string accountID)
        {
            var positions = GetAllFacts(accountID);
            if (positions.Count == 0)
                positions.AddRange(CreateDefaultPositions());
            return positions;
        }

        private List<CharacterInThePack> CreateDefaultPositions()
        {
            List<CharacterInThePack> positions = new List<CharacterInThePack>();
            positions.Add(new CharacterInThePack { Position = TeamPosition.Front_1, Character_ID = "" });
            positions.Add(new CharacterInThePack { Position = TeamPosition.Front_2, Character_ID = "" });
            positions.Add(new CharacterInThePack { Position = TeamPosition.Front_3, Character_ID = "" });
            positions.Add(new CharacterInThePack { Position = TeamPosition.Middle_1, Character_ID = "" });
            positions.Add(new CharacterInThePack { Position = TeamPosition.Middle_2, Character_ID = "" });
            positions.Add(new CharacterInThePack { Position = TeamPosition.Middle_3, Character_ID = "" });
            positions.Add(new CharacterInThePack { Position = TeamPosition.Middle_4, Character_ID = "" });
            positions.Add(new CharacterInThePack { Position = TeamPosition.Rear_1, Character_ID = "" });
            positions.Add(new CharacterInThePack { Position = TeamPosition.Rear_2, Character_ID = "" });
            positions.Add(new CharacterInThePack { Position = TeamPosition.Rear_3, Character_ID = "" });
            positions.Add(new CharacterInThePack { Position = TeamPosition.None, Character_ID = "" });
            return positions;

        }
    }

}
