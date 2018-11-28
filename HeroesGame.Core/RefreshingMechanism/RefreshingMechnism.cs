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

        public RefreshResults GetRefreshStatus(RefreshOption option, DateTime currentTime)
        {
            var refreshFact = GetLastRefresh(option);
            if (refreshFact == null) return new RefreshResults { Status = RefresStatus.Ready, SecondsLeft = 0 };
            int secondesToAdd = GetDelayValue(option);
            var left = (int)(refreshFact.LastAction.AddSeconds(secondesToAdd) - currentTime).TotalSeconds;

            return refreshFact.LastAction.AddSeconds(secondesToAdd) > currentTime ?
                new RefreshResults { Status = RefresStatus.NotReady, SecondsLeft = left } : 
                new RefreshResults { Status = RefresStatus.Ready, SecondsLeft = 0 };
        }

        public void AddRefreshFactForLoggedAccount(RefreshOption option, DateTime actionTime)
        {
            _refreshRepository.Add(new RefreshFact { Option = option, LastAction = actionTime }, _accountManagement.GetLoggedAccount().ID);
        }

        public int GetDelayValue(RefreshOption option)
        {
            var parameterName = $"Delay_for_option_{option}_in_sec";
            return Int32.Parse(_configRepository.GetParameterValue(parameterName));
        }

        public RefreshFact GetLastRefresh(RefreshOption option)
        {
            var refreshFacts = _refreshRepository.GetAll(_accountManagement.GetLoggedAccount().ID);
            return refreshFacts.OrderByDescending(x => x.LastAction).FirstOrDefault();
        }
    }
}
