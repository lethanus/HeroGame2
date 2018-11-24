namespace HeroesGame.Inventory
{
    public enum ItemCategory { Trophy, Other}
    public class ItemTemplate
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public ItemCategory Category { get; set; }
        public string Effects { get; set; }
    }
}
