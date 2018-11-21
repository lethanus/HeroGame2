using System.Collections.Generic;
using HeroesGame.Characters;
using System.IO;
using Newtonsoft.Json;
using HeroesGame.PackBuilding;

namespace HeroesGame.Repositories
{
    public class PackFormationJsonFileRepository : IPackFormationRepository
    {
        private string _directoryPath;
        private Dictionary<TeamPosition, string> _packFormation = new Dictionary<TeamPosition, string>();

        public PackFormationJsonFileRepository(string directoryPath)
        {
            _directoryPath = directoryPath;
            _packFormation.Add(TeamPosition.Front_1, "");
            _packFormation.Add(TeamPosition.Front_2, "");
            _packFormation.Add(TeamPosition.Front_3, "");
            _packFormation.Add(TeamPosition.Middle_1, "");
            _packFormation.Add(TeamPosition.Middle_2, "");
            _packFormation.Add(TeamPosition.Middle_3, "");
            _packFormation.Add(TeamPosition.Middle_4, "");
            _packFormation.Add(TeamPosition.Rear_1, "");
            _packFormation.Add(TeamPosition.Rear_2, "");
            _packFormation.Add(TeamPosition.Rear_3, "");
            _packFormation.Add(TeamPosition.None, "");
        }

        public List<CharacterInThePack> GetAll()
        {
            List<CharacterInThePack> charactersInThePack = new List<CharacterInThePack>();
            foreach(var row in _packFormation)
            {
                charactersInThePack.Add(new CharacterInThePack { Character_ID = row.Value, Position = row.Key });
            }
            return charactersInThePack;
        }

        public string GetCharacterIdOnPosition(TeamPosition position, string accountID)
        {
            return _packFormation[position];
        }

        public void SetCharacterToPosition(string characterID, TeamPosition position, string iD)
        {
            _packFormation[position] = characterID;
        }
    }

}
