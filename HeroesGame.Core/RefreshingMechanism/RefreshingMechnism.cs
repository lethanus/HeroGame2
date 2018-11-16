using System;
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

        public string GetRefreshStatus(string option, DateTime currentTime)
        {
            var parameterName = $"Delay_for_option_{option}_in_sec";
            return _refreshRepository.GetRefreshStatus(option, _accountManagement.GetLoggedAccount().ID, _configRepository.GetParameterValue(parameterName), currentTime);
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
