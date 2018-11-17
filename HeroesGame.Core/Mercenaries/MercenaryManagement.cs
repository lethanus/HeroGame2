using HeroesGame.Characters;
using System.Collections.Generic;
using HeroesGame.Accounts;

namespace HeroesGame.Mercenaries
{
    public class MercenaryManagement : IMercenaryManagement
    {
        private IMercenaryRepository _mercenaryRepository;
        private IAccountManagement _accountManagement;
        public MercenaryManagement(IMercenaryRepository mercenaryRepository, IAccountManagement accountManagement)
        {
            _mercenaryRepository = mercenaryRepository;
            _accountManagement = accountManagement;
        }

        public void AddNewMercenary(Character mercenary)
        {
            _mercenaryRepository.Add(mercenary, _accountManagement.GetLoggedAccount().ID);
        }

        public List<Character> GetAllMercenariesForLoggedUser()
        {
            return _mercenaryRepository.GetAllMercenariesForUser(_accountManagement.GetLoggedAccount().ID);
        }
    }


}
