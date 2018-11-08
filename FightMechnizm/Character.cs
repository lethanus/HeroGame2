using System;

namespace HeroGame.Characters
{
    public class Character : ICharacterInTeam
    {
        private string _team = "";
        private TeamPosition _teamPosition;
        public string ID { get; set; }
        public string Name { get; set; }
        public int MaxHp { get; set; }
        public int Hp { get; set; }
        public int Att { get; set; }
        public int Def { get; set; }
        public int Speed { get; set; }
        

        public Character() {}
        public Character(string name, int maxHp, int attack, int defence, int speed)
        {
            Name = name;
            MaxHp = maxHp;
            Hp = maxHp;
            Att = attack;
            Def = defence;
            Speed = speed;
            ID = Guid.NewGuid().ToString();
        }

        public Character CreateCopy()
        {
            return new Character(Name, MaxHp, Att, Def, Speed);
        }

        public override bool Equals(object obj)
        {
            var toCompare = obj as Character;

            if (ID == toCompare.ID &&
                Name == toCompare.Name &&
                MaxHp == toCompare.MaxHp &&
                Hp == toCompare.Hp &&
                Att == toCompare.Att &&
                Def == toCompare.Def &&
                Speed == toCompare.Speed)
                return true;
            var nl = System.Environment.NewLine;
            throw new System.Exception($"There are some diffs:{nl} Expected: {ToString()}{nl} Actual: {toCompare.ToString()}");
        }

        public Character GetCharacter()
        {
            return this;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string GetTeam()
        {
            return _team;
        }

        public void SetTeam(string team)
        {
            _team = team;
        }

        public override string ToString()
        {
            return $"ID:{ID} Name:{Name} MaxHp:{MaxHp} Hp:{Hp} Att:{Att} Def:{Def} Speed:{Speed}";
        }

        public void SetPosition(TeamPosition position)
        {
            _teamPosition = position;
        }

        public TeamPosition GetPosition()
        {
            return _teamPosition;
        }
    }
}
