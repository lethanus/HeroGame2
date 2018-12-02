using System.Collections.Generic;
using HeroesGame.Common;

namespace HeroesGame.Inventory
{
    public class PositionInInventory : ObjectWithID
    { 
        public string Name { get; set; }
        public ItemCategory Category { get; set; }
        public string Effects { get; set; }

        public override bool Equals(object obj)
        {
            var toCompare = obj as PositionInInventory;
            var result =
                Name == toCompare.Name &&
                Category == toCompare.Category &&
                Amount == toCompare.Amount &&
                Effects == toCompare.Effects;
            return result;
        }

        public override int GetHashCode()
        {
            var hashCode = 426773352;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Category.ToString());
            hashCode = hashCode * -1521134295 + Amount.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"{ID} {Name} {Category} {Amount}";
        }
    }
}
