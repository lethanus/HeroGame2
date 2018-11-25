using System;


namespace HeroesGame.RefresingMechanism
{
    public enum RefresStatus { Enabled, Disabled }
    public interface IRefreshingMechnism
    {
        RefresStatus GetRefreshStatus(RefreshOption option, DateTime currentTime);
        void AddRefreshFactForLoggedAccount(RefreshOption option, DateTime actionTime);
        int GetDelayValue(RefreshOption option);
        RefreshFact GetLastRefresh(RefreshOption option);
    }
}