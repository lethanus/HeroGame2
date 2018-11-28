namespace HeroesGame.RefresingMechanism
{
    public enum RefresStatus { Ready, NotReady }

    public class RefreshResults
    {
        public RefresStatus Status { get; set; }
        public int SecondsLeft { get; set; }
    }
}