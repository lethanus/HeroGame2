using HeroesGame.Characters;
using System.Collections.Generic;
using HeroesGame.Accounts;
using System.Linq;
using System;
using HeroesGame.Core.Randomizers;

namespace HeroesGame.Mercenaries
{
    public class MercenaryManagement : IMercenaryManagement
    {
        private IMercenaryRepository _mercenaryRepository;
        private IMercenaryTemplateRepository _mercenaryTemplateRepository;
        private IAccountManagement _accountManagement;
        public MercenaryManagement(IMercenaryRepository mercenaryRepository, IAccountManagement accountManagement, IMercenaryTemplateRepository mercenaryTemplateRepository)
        {
            _mercenaryRepository = mercenaryRepository;
            _accountManagement = accountManagement;
            _mercenaryTemplateRepository = mercenaryTemplateRepository;
        }

        public void AddNewMercenary(Character mercenary)
        {
            _mercenaryRepository.Add(mercenary, _accountManagement.GetLoggedAccount().ID);
        }

        public List<Character> GetAllMercenariesForLoggedUser()
        {
            return _mercenaryRepository.GetAllMercenariesForUser(_accountManagement.GetLoggedAccount().ID);
        }

        public Mercenary GetMercenaryBaseOnTemplate(string mercenaryName, int mercenaryLevel)
        {
            var newMercenary = new Mercenary();
            var mercenaryTemplate = _mercenaryTemplateRepository.GetMercenaryTemplates().First(x => x.Level == mercenaryLevel.ToString() && x.Name == mercenaryName);
            var hpRange = mercenaryTemplate.HP_range.Split('-').Select(x => Int32.Parse(x)).ToArray();
            var attackRange = mercenaryTemplate.Attack_range.Split('-').Select(x => Int32.Parse(x)).ToArray();
            var defenceRange = mercenaryTemplate.Defence_range.Split('-').Select(x => Int32.Parse(x)).ToArray();
            var speedRange = mercenaryTemplate.Speed_range.Split('-').Select(x => Int32.Parse(x)).ToArray();

            newMercenary.Hp = ValueRandomizer.GetRandomValueInRange(hpRange[0], hpRange[1]);
            newMercenary.Attack = ValueRandomizer.GetRandomValueInRange(attackRange[0], attackRange[1]);
            newMercenary.Defence = ValueRandomizer.GetRandomValueInRange(defenceRange[0], defenceRange[1]);
            newMercenary.Speed = ValueRandomizer.GetRandomValueInRange(speedRange[0], speedRange[1]);

            return newMercenary;
        }
    }


}
