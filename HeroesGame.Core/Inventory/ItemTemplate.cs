using System.Collections.Generic;

namespace HeroesGame.Inventory
{
    public enum ItemCategory { Trophy, Rewards, Other}
    public class ItemTemplate
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public ItemCategory Category { get; set; }
        public string Effects { get; set; }
        public int Level { get; set; }

        public ItemTemplate()
        {
            Level = 0;
        }

        public override bool Equals(object obj)
        {
            var toCompare = obj as ItemTemplate;
            var result =
                ID == toCompare.ID &&
                Name == toCompare.Name &&
                Category == toCompare.Category &&
                Level == toCompare.Level;
            return result;
        }

        public override int GetHashCode()
        {
            var hashCode = 1178356513;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Category.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Effects);
            hashCode = hashCode * -1521134295 + EqualityComparer<int>.Default.GetHashCode(Level);
            return hashCode;
        }
    }
}
