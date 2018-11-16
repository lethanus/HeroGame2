using System;
using HeroesGame.Configuration;
using HeroesGame.RefresingMechanism;

namespace HeroesGame.RefresingMechanism
{
    public class RefreshingMechnism
    {
        private IRefreshRepository _refreshRepository;
        private IConfigRepository _configRepository;

        public RefreshingMechnism(IRefreshRepository refreshRepository, IConfigRepository configRepository)
        {
            _refreshRepository = refreshRepository;
            _configRepository = configRepository;
        }

        public string GetRefreshStatus(string option, string accountID, DateTime currentTime)
        {
            var parameterName = $"Delay_for_option_{option}_in_sec";
            return _refreshRepository.GetRefreshStatus(option, accountID, _configRepository.GetParameterValue(parameterName), currentTime);
        }

        public void AddRefreshFact(string option, string accountID, DateTime actionTime)
        {
            _refreshRepository.AddRefreshFact(accountID, option, actionTime);
        }
    }
}
