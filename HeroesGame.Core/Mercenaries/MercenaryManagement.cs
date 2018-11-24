using HeroesGame.Characters;
using System.Collections.Generic;
using HeroesGame.Accounts;
using System.Linq;
using System;
using HeroesGame.Core.Randomizers;
using HeroesGame.Configuration;
using HeroesGame.Inventory;

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

        public MercenaryManagement(IMercenaryRepository mercenaryRepository, IAccountManagement accountManagement,
            IMercenaryTemplateRepository mercenaryTemplateRepository, IValueRandomizer randomizer,
            IConfigRepository configRepository, IRecruitsRepository recruitsRepository, IInventoryManagement inventoryManagement)
        {
            _mercenaryRepository = mercenaryRepository;
            _accountManagement = accountManagement;
            _mercenaryTemplateRepository = mercenaryTemplateRepository;
            _randomizer = randomizer;
            _configRepository = configRepository;
            _recruitsRepository = recruitsRepository;
            _inventoryManagement = inventoryManagement;
        }

        public void AddNewMercenary(Character mercenary)
        {
            _mercenaryRepository.Add(mercenary, _accountManagement.GetLoggedAccount().ID);
        }

        public bool ConvinceRecruit(Mercenary recruit)
        {
            var convinceChances = new Dictionary<int, ChanceRange>();
            convinceChances.Add(1, new ChanceRange(_configRepository.GetParameterValue("ConvinceLevel_1_recruit")));
            convinceChances.Add(2, new ChanceRange(_configRepository.GetParameterValue("ConvinceLevel_2_recruit")));
            convinceChances.Add(3, new ChanceRange(_configRepository.GetParameterValue("ConvinceLevel_3_recruit")));
            convinceChances.Add(4, new ChanceRange(_configRepository.GetParameterValue("ConvinceLevel_4_recruit")));
            var randomValue = _randomizer.GetRandomValueInRange(1, convinceChances[1].MaxValue, "Recruits_convincing");


            int randomValueModyficationPercent = 0;
            foreach (var item in _gifts.Values)
            {
                var percentage = 0;
                if(Int32.TryParse(item.Effects.Replace("Mercenary_Convince_Chance_(+", "").Replace("%)", "").Trim(), out percentage))
                {
                    randomValueModyficationPercent += percentage * item.Amount;
                }
            }
            var toAdd = (randomValueModyficationPercent / 100.0) * convinceChances[recruit.Level].MaxValue;

            var convinced = randomValue <= convinceChances[recruit.Level].Value + toAdd;
            if (convinced)
            { 
                AddNewMercenary(recruit.CreateCharacter());
                foreach (var item in _gifts.Values)
                {
                    _inventoryManagement.RemoveItems(item.ID, item.Amount);
                }
            }
            _recruitsRepository.Remove(recruit, _accountManagement.GetLoggedAccount().ID);
            return convinced;
        }

        public double GetConvinceChance(int level)
        {
            var convinceChances = new Dictionary<int, ChanceRange>();
            convinceChances.Add(1, new ChanceRange(_configRepository.GetParameterValue("ConvinceLevel_1_recruit")));
            convinceChances.Add(2, new ChanceRange(_configRepository.GetParameterValue("ConvinceLevel_2_recruit")));
            convinceChances.Add(3, new ChanceRange(_configRepository.GetParameterValue("ConvinceLevel_3_recruit")));
            convinceChances.Add(4, new ChanceRange(_configRepository.GetParameterValue("ConvinceLevel_4_recruit")));

            return (convinceChances[level].Value / (convinceChances[level].MaxValue * 1.0)) * 100;
        }

        public void GenerateMercenaries()
        {
            _recruitsRepository.Clear(_accountManagement.GetLoggedAccount().ID);
            var count = Int32.Parse(_configRepository.GetParameterValue("NumberOfRecruits"));
            var mercenaryChances = new Dictionary<int, ChanceRange>();
            mercenaryChances.Add(1, new ChanceRange(_configRepository.GetParameterValue("ChanceForLevel_1_mercenary")));
            mercenaryChances.Add(2, new ChanceRange(_configRepository.GetParameterValue("ChanceForLevel_2_mercenary")));
            mercenaryChances.Add(3, new ChanceRange(_configRepository.GetParameterValue("ChanceForLevel_3_mercenary")));
            mercenaryChances.Add(4, new ChanceRange(_configRepository.GetParameterValue("ChanceForLevel_4_mercenary")));

            List<Mercenary> mercenaries = new List<Mercenary>();

            for(int i = 1; i<= count; i++)
            {
                var level = 1;
                var randomValue = _randomizer.GetRandomValueInRange(1, mercenaryChances[1].MaxValue, "Mercenary_level_chance");

                for (int j = 1; j<=4; j++)
                {
                    if (randomValue < mercenaryChances[j].Value) level = j;
                }

                var mercenariesOnLevel = _mercenaryTemplateRepository.GetAll().Where(x => x.Level == level.ToString());

                int counter = 1;
                var names = new Dictionary<int, string>();
                foreach(var name in mercenariesOnLevel.Select(x=>x.Name).Distinct())
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
            return _inventoryManagement.GetAvailableGiftItems();
        }

        public void AddGifts(string itemID, int amount)
        {
            var item = _inventoryManagement.GetAvailableGiftItems().First(x => x.ID == itemID);
            item.Amount = amount;
            _gifts.Add(item.ID, item);
        }

        public void RemoveGifts(string itemID, int amount)
        {
            
        }

        public List<PositionInInventory> GetCurrentGifts()
        {
            return new List<PositionInInventory>();
        }
    }

    public class ChanceRange
    {
        public int Value { get; private set; }
        public int MaxValue { get; private set; }
        public ChanceRange(string rangeString)
        {
            if (rangeString == "")
            {
                Value = 0;
                MaxValue = 10000;
            }
            else
            {
                var values = rangeString.Split('_').Select(x => Int32.Parse(x)).ToArray();
                Value = values[0];
                MaxValue = values[1];
            }
        }

    }


}
