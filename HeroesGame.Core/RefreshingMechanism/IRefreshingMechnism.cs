using System;


namespace HeroesGame.RefresingMechanism
{
    public enum RefresStatus { Enabled, Disabled }
    public interface IRefreshingMechnism
    {
        RefresStatus GetRefreshStatus(string option, DateTime currentTime);
        void AddRefreshFact(string option, string accountID, DateTime actionTime);
        void AddRefreshFactForLoggedAccount(string option, DateTime actionTime);
    }
}