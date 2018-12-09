using HeroesGame.Characters;
using System.Collections.Generic;
using HeroesGame.Accounts;
using System.Linq;
using System;
using HeroesGame.Core.Randomizers;
using HeroesGame.Configuration;
using HeroesGame.Inventory;
using HeroesGame.RefresingMechanism;

namespace HeroesGame.Mercenaries
{
    public class MercenaryManagement : IMercenaryManagement
    {
        private Dictionary<string, PositionInInventory> _gifts = new Dictionary<string, PositionInInventory>();
        private IMercenaryRepository _mercenaryRepository;
        private IMercenaryTemplateRepository _mercenaryTemplateRepository;
        private IAccountManagement _accountManagement;
        private IValueRandomizer _randomizer;
        private IConfigRepository _configRepository;
        private IRecruitsRepository _recruitsRepository;
        private IInventoryManagement _inventoryManagement;
        private readonly IRefreshingMechnism _refreshingMechnism;
        private ConfigurationAdapter configurationAdapter = new ConfigurationAdapter();

        public MercenaryManagement(IMercenaryRepository mercenaryRepository, IAccountManagement accountManagement,
            IMercenaryTemplateRepository mercenaryTemplateRepository, IValueRandomizer randomizer,
            IConfigRepository configRepository, IRecruitsRepository recruitsRepository, IInventoryManagement inventoryManagement,
            IRefreshingMechnism refreshingMechnism)
        {
            _mercenaryRepository = mercenaryRepository;
            _accountManagement = accountManagement;
            _mercenaryTemplateRepository = mercenaryTemplateRepository;
            _randomizer = randomizer;
            _configRepository = configRepository;
            _recruitsRepository = recruitsRepository;
            _inventoryManagement = inventoryManagement;
            _refreshingMechnism = refreshingMechnism;
        }

        public void AddNewMercenary(Character mercenary)
        {
            _mercenaryRepository.Add(mercenary, _accountManagement.GetLoggedAccount().ID);
        }

        public bool ConvinceRecruit(Mercenary recruit)
        {
            configurationAdapter.LoadConfigs(_configRepository);
            var firstLevelMax = configurationAdapter.MercenaryConvinceChances[1];
            var convinceValue = CalculateConvinceValue(recruit.Level);
            var randomValue = _randomizer.GetRandomValueInRange(1, firstLevelMax.MaxValue, "Recruits_convincing");
            var convinced = randomValue <= convinceValue;
            if (convinced)
            { 
                AddNewMercenary(recruit.CreateCharacter());
            }
            foreach (var item in _gifts.Values)
            {
                _inventoryManagement.RemoveItems(item.Identyficator, item.Amount);
            }
            _gifts.Clear();
            _recruitsRepository.Remove(recruit, _accountManagement.GetLoggedAccount().ID);
            return convinced;
        }

        private double CalculateConvinceValue(int level)
        {
            int randomValueModyficationPercent = 0;
            foreach (var item in _gifts.Values)
            {
                var percentage = 0;
                if (Int32.TryParse(item.Effects.Replace("Mercenary_Convince_Chance_(+", "").Replace("%)", "").Trim(), out percentage))
                {
                    randomValueModyficationPercent += percentage * item.Amount;
                }
            }
            var toAdd = (randomValueModyficationPercent / 100.0) * configurationAdapter.MercenaryConvinceChances[level].MaxValue;
            return configurationAdapter.MercenaryConvinceChances[level].Value + toAdd;
        }

        public double GetConvinceChance(int level)
        {
            return (CalculateConvinceValue(level) / (configurationAdapter.MercenaryConvinceChances[level].MaxValue * 1.0)) * 100;
        }

        public bool GenerateMercenaries()
        {
            configurationAdapter.LoadConfigs(_configRepository);
            var now = DateTime.Now;
            var refreshResult = _refreshingMechnism.GetRefreshStatus(RefreshOption.Mercenaries, now);
            if (refreshResult.Status == RefresStatus.Ready)
            {
                _recruitsRepository.Clear(_accountManagement.GetLoggedAccount().ID);
                List<Mercenary> mercenaries = new List<Mercenary>();

                for (int i = 1; i <= configurationAdapter.NumberOfRecruits; i++)
                {
                    var level = GetRandomLevel(configurationAdapter.MercenaryGenerateChances);
                    var mercenariesOnLevel = _mercenaryTemplateRepository.GetAll().Where(x => x.Level == level.ToString());

                    int counter = 1;
                    var names = new Dictionary<int, string>();
                    foreach (var name in mercenariesOnLevel.Select(x => x.Name).Distinct())
                    {
                        names.Add(counter++, name);
                    }
                    var randomValueForName = _randomizer.GetRandomValueInRange(1, counter, "Mercenary_name");

                    var newMercenary = GetMercenaryBaseOnTemplate(names[randomValueForName], level);
                    mercenaries.Add(newMercenary);

                }
                foreach (var recruit in mercenaries)
                {
                    _recruitsRepository.Add(recruit, _accountManagement.GetLoggedAccount().ID);
                }
                _refreshingMechnism.AddRefreshFactForLoggedAccount(RefreshOption.Mercenaries, now);
                return true;
            }
            else return false;
        }

        private int GetRandomLevel(Dictionary<int, ChanceRange> questLevelChances)
        {
            var randomValue = _randomizer.GetRandomValueInRange(1, questLevelChances[1].MaxValue, "Mercenary_level_chance");
            int level = 1;
            for (int j = 1; j <= 4; j++)
            {
                if (randomValue < questLevelChances[j].Value) level = j;
            }
            return level;
        }

        public List<Character> GetAllMercenariesForLoggedUser()
        {
            return _mercenaryRepository.GetAll(_accountManagement.GetLoggedAccount().ID);
        }

        public Mercenary GetMercenaryBaseOnTemplate(string mercenaryName, int mercenaryLevel)
        {
            var newMercenary = new Mercenary();
            var mercenaryTemplate = _mercenaryTemplateRepository.GetAll().First(x => x.Level == mercenaryLevel.ToString() && x.Name == mercenaryName);

            newMercenary.Hp = GetRandomValueFromTemplateRange(mercenaryTemplate.HP_range, "Mercenary_Hp");
            newMercenary.Attack_Min = GetRandomValueFromTemplateRange(mercenaryTemplate.Min_Attack_range, "Mercenary_Attack");
            newMercenary.Defence = GetRandomValueFromTemplateRange(mercenaryTemplate.Defence_range, "Mercenary_Defence");
            newMercenary.Speed = GetRandomValueFromTemplateRange(mercenaryTemplate.Speed_range, "Mercenary_Speed");

            newMercenary.Attack_Max = newMercenary.Attack_Min + Int32.Parse(mercenaryTemplate.Attack_add_for_max);
            newMercenary.Level = Int32.Parse(mercenaryTemplate.Level);
            newMercenary.Name = mercenaryTemplate.Name;
            newMercenary.ID = $"{Guid.NewGuid().ToString()}_{newMercenary.Level}_{newMercenary.Name}";

            return newMercenary;
        }

        public List<Mercenary> GetRecruits()
        {
            return _recruitsRepository.GetAll(_accountManagement.GetLoggedAccount().ID);
        }

        private int GetRandomValueFromTemplateRange(string rangeString, string stat_name)
        {
            var range = rangeString.Split('-').Select(x => Int32.Parse(x)).ToArray();
            return _randomizer.GetRandomValueInRange(range[0], range[1], stat_name);
        }

        public List<PositionInInventory> GetAvailableGiftItems()
        {
            var availableGifts = _inventoryManagement.GetAvailableGiftItems();
            foreach(var gift in availableGifts)
            {
                if (_gifts.ContainsKey(gift.Name))
                {
                    gift.Amount -= _gifts[gift.Name].Amount;
                }
            }
            return availableGifts.Where(x=>x.Amount > 0).ToList();
        }

        public void AddGifts(string itemName, int amount)
        {
            var item = _inventoryManagement.GetAvailableGiftItems().First(x => x.Name == itemName);
            item.Amount = amount;
            if (_gifts.ContainsKey(item.Name))
            {
                _gifts[item.Name].Amount += amount;
            }
            else _gifts.Add(item.Name, item);
        }

        public void RemoveGifts(string itemID, int amount)
        {
            if(_gifts.ContainsKey(itemID))
            {
                if (_gifts[itemID].Amount <= amount)
                    _gifts.Remove(itemID);
                else
                    _gifts[itemID].Amount -= amount;
            }
        }

        public List<PositionInInventory> GetCurrentGifts()
        {
            return _gifts.Select(x => x.Value).ToList();
        }
    }


}
