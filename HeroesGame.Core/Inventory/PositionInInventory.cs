using System.Collections.Generic;

namespace HeroesGame.Inventory
{
    public class PositionInInventory
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Amount { get; set; }

        public override bool Equals(object obj)
        {
            var toCompare = obj as PositionInInventory;
            var result =
                ID == toCompare.ID &&
                Name == toCompare.Name &&
                Category == toCompare.Category &&
                Amount == toCompare.Amount;
            return result;
        }

        public override int GetHashCode()
        {
            var hashCode = 426773352;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Category);
            hashCode = hashCode * -1521134295 + Amount.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"{ID} {Name} {Category} {Amount}";
        }
    }
}
