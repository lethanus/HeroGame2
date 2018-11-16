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
            var refreshFact = GetLastRefresh(option);
            int secondesToAdd = GetDelayValue(option);
            if (refreshFact == null) return RefresStatus.Enabled;
            return refreshFact.LastAction.AddSeconds(secondesToAdd) > currentTime ? RefresStatus.Disabled : RefresStatus.Enabled;
        }

        public void AddRefreshFact(string option, string accountID, DateTime actionTime)
        {
            _refreshRepository.AddRefreshFact(accountID, option, actionTime);
        }

        public void AddRefreshFactForLoggedAccount(string option, DateTime actionTime)
        {
            _refreshRepository.AddRefreshFact(_accountManagement.GetLoggedAccount().ID, option, actionTime);
        }

        public int GetDelayValue(string option)
        {
            var parameterName = $"Delay_for_option_{option}_in_sec";
            return Int32.Parse(_configRepository.GetParameterValue(parameterName));
        }

        public RefreshFact GetLastRefresh(string option)
        {
            var refreshFacts = _refreshRepository.GetRefreshesForAccount(_accountManagement.GetLoggedAccount().ID);
            return refreshFacts.OrderByDescending(x => x.LastAction).FirstOrDefault();
        }
    }
}
