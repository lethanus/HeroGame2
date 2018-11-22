using System;


namespace HeroesGame.RefresingMechanism
{
    public enum RefresStatus { Enabled, Disabled }
    public interface IRefreshingMechnism
    {
        RefresStatus GetRefreshStatus(string option, DateTime currentTime);
        void AddRefreshFactForLoggedAccount(string option, DateTime actionTime);
        int GetDelayValue(string option);
        RefreshFact GetLastRefresh(string option);
    }
}