using HeroesGame.Characters;
using HeroesGame.Common;

namespace HeroesGame.Mercenaries
{
    public class Mercenary : ObjectWithID
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Attack_Min { get; set; }
        public int Attack_Max { get; set; }
        public int Defence { get; set; }
        public int Speed { get; set; }

        public Character CreateCharacter()
        {
            var character = new Character();
            character.Name = Name;
            character.MaxHp = Hp;
            character.Hp = Hp;
            character.ID = ID;
            character.Max_Att = Attack_Max;
            character.Min_Att = Attack_Min;
            character.Def = Defence;
            character.Speed = Speed;
            character.Level = Level;

            return character;
        }
    }
}
