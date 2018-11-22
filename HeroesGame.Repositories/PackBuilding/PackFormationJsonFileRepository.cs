using System.Collections.Generic;
using System.Collections;
using HeroesGame.Characters;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using HeroesGame.PackBuilding;

namespace HeroesGame.Repositories
{
    public class PackFormationJsonFileRepository : IPackFormationRepository
    {
        private string _directoryPath;

        public PackFormationJsonFileRepository(string directoryPath)
        {
            _directoryPath = directoryPath;
        }

        public string GetCharacterIdOnPosition(TeamPosition position, string accountID)
        {
            var positions = GetAll(accountID);
            return positions.ToDictionary(x => x.Position, x => x.Character_ID)[position];
        }

        public void SetCharacterToPosition(string characterID, TeamPosition position, string accountID)
        {
            var positions = GetAll(accountID);
            positions.First(x => x.Position == position).Character_ID = characterID;
            SaveFormationForAccount(positions, accountID, _directoryPath);
        }

        private void SaveFormationForAccount(List<CharacterInThePack> formation, string accountID, string directoryPath)
        {
            string pathToFile = $"{directoryPath}\\PackFormation_{accountID}.json";
            string json = JsonConvert.SerializeObject(formation, Formatting.Indented);
            File.WriteAllText(pathToFile, json);
        }

        public List<CharacterInThePack> GetAll(string accountID)
        {
            string pathToFile = $"{_directoryPath}\\PackFormation_{accountID}.json";
            if (!File.Exists(pathToFile))
            {
                return CreateDefaultPositions();
            }
            var json = File.ReadAllText(pathToFile);
            var positions = JsonConvert.DeserializeObject<List<CharacterInThePack>>(json);
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
