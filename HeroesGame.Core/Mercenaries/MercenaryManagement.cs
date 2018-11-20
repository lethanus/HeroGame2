using HeroesGame.Characters;
using System.Collections.Generic;
using HeroesGame.Accounts;
using System.Linq;
using System;
using HeroesGame.Core.Randomizers;
using HeroesGame.Configuration;

namespace HeroesGame.Mercenaries
{
    public class MercenaryManagement : IMercenaryManagement
    {
        private IMercenaryRepository _mercenaryRepository;
        private IMercenaryTemplateRepository _mercenaryTemplateRepository;
        private IAccountManagement _accountManagement;
        private IValueRandomizer _randomizer;
        private IConfigRepository _configRepository;
        public MercenaryManagement(IMercenaryRepository mercenaryRepository, IAccountManagement accountManagement,
            IMercenaryTemplateRepository mercenaryTemplateRepository, IValueRandomizer randomizer,
            IConfigRepository configRepository)
        {
            _mercenaryRepository = mercenaryRepository;
            _accountManagement = accountManagement;
            _mercenaryTemplateRepository = mercenaryTemplateRepository;
            _randomizer = randomizer;
            _configRepository = configRepository;
        }

        public void AddNewMercenary(Character mercenary)
        {
            _mercenaryRepository.Add(mercenary, _accountManagement.GetLoggedAccount().ID);
        }

        public List<Mercenary> GenerateMercenaries(string accountID)
        {
            var count = Int32.Parse(_configRepository.GetParameterValue("NumberOfRecruits"));

            List<Mercenary> mercenaries = new List<Mercenary>();

            for(int i = 1; i<= count; i++)
            {
                var newMercenary = GetMercenaryBaseOnTemplate("Goblin", 1);
                mercenaries.Add(newMercenary);

            }

            return mercenaries;
        }

        public List<Character> GetAllMercenariesForLoggedUser()
        {
            return _mercenaryRepository.GetAllMercenariesForUser(_accountManagement.GetLoggedAccount().ID);
        }

        public Mercenary GetMercenaryBaseOnTemplate(string mercenaryName, int mercenaryLevel)
        {
            var newMercenary = new Mercenary();
            var mercenaryTemplate = _mercenaryTemplateRepository.GetMercenaryTemplates().First(x => x.Level == mercenaryLevel.ToString() && x.Name == mercenaryName);

            newMercenary.Hp = GetRandomValueFromTemplateRange(mercenaryTemplate.HP_range, "Mercenary_Hp");
            newMercenary.Attack = GetRandomValueFromTemplateRange(mercenaryTemplate.Attack_range, "Mercenary_Attack");
            newMercenary.Defence = GetRandomValueFromTemplateRange(mercenaryTemplate.Defence_range, "Mercenary_Defence");
            newMercenary.Speed = GetRandomValueFromTemplateRange(mercenaryTemplate.Speed_range, "Mercenary_Speed");

            newMercenary.Level = Int32.Parse(mercenaryTemplate.Level);
            newMercenary.Name = mercenaryTemplate.Name;
            newMercenary.ID = $"{Guid.NewGuid().ToString()}_{newMercenary.Level}_{newMercenary.Name}";

            return newMercenary;
        }

        private int GetRandomValueFromTemplateRange(string rangeString, string stat_name)
        {
            var range = rangeString.Split('-').Select(x => Int32.Parse(x)).ToArray();
            return _randomizer.GetRandomValueInRange(range[0], range[1], stat_name);
        }
    }


}
