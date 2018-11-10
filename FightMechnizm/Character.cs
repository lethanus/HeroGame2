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
        public string Skills { get; set; }
        

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
            var newChar = new Character(Name, MaxHp, Att, Def, Speed);
            newChar._team = _team;
            newChar._teamPosition = _teamPosition;
            return newChar;
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

        public string ToCharacterString()
        {
            return $"{Name} [{MaxHp}/{Hp}]";
        }

        public void SetPosition(TeamPosition position)
        {
            _teamPosition = position;
        }

        public TeamPosition GetPosition()
        {
            return _teamPosition;
        }

        public string getID()
        {
            return ID;
        }

        public string getName()
        {
            return Name;
        }

        public int getMaxHp()
        {
            return MaxHp;
        }

        public int getHp()
        {
            return Hp;
        }

        public int getAtt()
        {
            return Att;
        }

        public int getDef()
        {
            return Def;
        }

        public int getSpeed()
        {
            return Speed;
        }

        public void setNewHP(int hp)
        {
            Hp = hp;
        }
    }
}
