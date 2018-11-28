using System;


namespace HeroesGame.RefresingMechanism
{
    
    public interface IRefreshingMechnism
    {
        RefreshResults GetRefreshStatus(RefreshOption option, DateTime currentTime);
        void AddRefreshFactForLoggedAccount(RefreshOption option, DateTime actionTime);
        int GetDelayValue(RefreshOption option);
        RefreshFact GetLastRefresh(RefreshOption option);
    }
}