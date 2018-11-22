using System.Collections.Generic;
using HeroesGame.Inventory;
using System.Linq;
using Newtonsoft.Json;
using System.IO;


namespace HeroesGame.Repositories
{
    public class PositionInInventoryJsonFileRepository : IPositionInInventoryRepository
    {

        private string _directoryPath;
        public PositionInInventoryJsonFileRepository(string directoryPath)
        {
            _directoryPath = directoryPath;
        }

        public void AddForAccount(PositionInInventory newItem, string accountID)
        {
            var positions = GetPositionInInventoryForAccount(accountID);
            positions.Add(newItem);
            SavePositionInInventoryForAccount(positions, accountID, _directoryPath);
        }

        public List<PositionInInventory> GetAllForAcount(string accountID)
        {
            return GetPositionInInventoryForAccount(accountID);
        }

        public void ChangeAmountForAccount(string itemID, int newAmount, string accountID)
        {
            var positions = GetPositionInInventoryForAccount(accountID);
            positions.First(x => x.ID == itemID).Amount = newAmount;
            SavePositionInInventoryForAccount(positions, accountID, _directoryPath);
        }


        private void SavePositionInInventoryForAccount(List<PositionInInventory> positions, string accountID, string directoryPath)
        {
            string pathToFile = $"{directoryPath}\\Inventory_{accountID}.json";
            string json = JsonConvert.SerializeObject(positions, Formatting.Indented);
            File.WriteAllText(pathToFile, json);
        }

        public List<PositionInInventory> GetPositionInInventoryForAccount(string accountID)
        {
            string pathToFile = $"{_directoryPath}\\Inventory_{accountID}.json";
            if (!File.Exists(pathToFile))
            {
                return new List<PositionInInventory>();
            }
            var json = File.ReadAllText(pathToFile);
            return JsonConvert.DeserializeObject<List<PositionInInventory>>(json);
        }

        public void RemovePositionWithID(string itemID, string accountID)
        {
            
        }
    }
}
