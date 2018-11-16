using System;


namespace HeroesGame.RefresingMechanism
{
    public interface IRefreshingMechnism
    {
        string GetRefreshStatus(string option, DateTime currentTime);
        void AddRefreshFact(string option, string accountID, DateTime actionTime);
        void AddRefreshFactForLoggedAccount(string option, DateTime actionTime);
    }
}