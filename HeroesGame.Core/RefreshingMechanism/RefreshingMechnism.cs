using System;
using System.Linq;
using HeroesGame.Configuration;
using HeroesGame.RefresingMechanism;
using HeroesGame.Accounts;

namespace HeroesGame.RefresingMechanism
{
    public class RefreshingMechnism : IRefreshingMechnism
    {
        private IRefreshRepository _refreshRepository;
        private IConfigRepository _configRepository;
        private IAccountManagement _accountManagement;

        public RefreshingMechnism(IRefreshRepository refreshRepository, IConfigRepository configRepository, IAccountManagement accountManagement)
        {
            _refreshRepository = refreshRepository;
            _configRepository = configRepository;
            _accountManagement = accountManagement;
        }

        public RefresStatus GetRefreshStatus(string option, DateTime currentTime)
        {
            var refreshFacts = _refreshRepository.GetRefreshesForAccount(_accountManagement.GetLoggedAccount().ID);
            var parameterName = $"Delay_for_option_{option}_in_sec";

            int secondesToAdd = Int32.Parse(_configRepository.GetParameterValue(parameterName));
            var notPassedRefreshes = refreshFacts
                    .Where(x => x.Option == option && x.LastAction.AddSeconds(secondesToAdd) > currentTime);
            return notPassedRefreshes.Count() == 0 ? RefresStatus.Enabled : RefresStatus.Disabled;
        }

        public void AddRefreshFact(string option, string accountID, DateTime actionTime)
        {
            _refreshRepository.AddRefreshFact(accountID, option, actionTime);
        }

        public void AddRefreshFactForLoggedAccount(string option, DateTime actionTime)
        {
            _refreshRepository.AddRefreshFact(_accountManagement.GetLoggedAccount().ID, option, actionTime);
        }
    }
}
