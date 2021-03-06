﻿using System;
using HeroesGame.Common;
using HeroesGame.FightMechanizm;

namespace HeroesGame.Characters
{
    public class Character : ObjectWithID, ICharacterInTeam
    {
        private string _team = "";
        private TeamPosition _teamPosition;
        public string Name { get; set; }
        public int MaxHp { get; set; }
        public int Hp { get; set; }
        public int Min_Att { get; set; }
        public int Max_Att { get; set; }
        public int Def { get; set; }
        public int Speed { get; set; }
        public string Skills { get; set; }
        public string Hp_range { get; set; }
        public int Level { get; set; }


        public Character()
        {
            Level = 1;
        }
        public Character(string name, int maxHp, int min_attack, int max_attack, int defence, int speed, string skills)
        {
            Name = name;
            MaxHp = maxHp;
            Hp = maxHp;
            Min_Att = min_attack;
            Max_Att = max_attack;
            Def = defence;
            Speed = speed;
            Skills = skills;
            Level = 1;
            ID = Guid.NewGuid().ToString();
        }

        public Character CreateCopy(bool keepOldID = true)
        {
            var newChar = new Character(Name, MaxHp, Min_Att, Max_Att, Def, Speed, Skills);
            newChar._team = _team;
            newChar._teamPosition = _teamPosition;
            newChar.Level = Level;
            if (keepOldID) newChar.ID = ID;
            return newChar;
        }

        public override bool Equals(object obj)
        {
            var toCompare = obj as Character;
            var hpRange = Hp_range == null ? new string[] { Hp.ToString() } : Hp_range.Split('-');
            var minHp = Int32.Parse(hpRange[0]);
            var maxHp = hpRange.Length > 1 ? Int32.Parse(hpRange[1]) : Int32.Parse(hpRange[0]);
            if (ID == toCompare.ID &&
                minHp <= toCompare.Hp && toCompare.Hp <= maxHp)
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
            return $"ID:{ID} Hp:{Hp} Hp_range:{Hp_range}";
        }

        public string ToCharacterString()
        {
            return $"{Name} [{MaxHp}/{Hp}]";
        }

        public string ToPositionFormatString()
        {
            return $"{Level} - {Name}";
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

        public int getMin_Att()
        {
            return Min_Att;
        }

        public int getMax_Att()
        {
            return Max_Att;
        }

        public string getSkills()
        {
            return Skills;
        }
    }
}
