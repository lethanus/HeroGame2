using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.Characters
{
    public interface ICharacter
    {
        string getID();
        string getName();
        int getMaxHp();
        int getHp();
        int getMin_Att();
        int getMax_Att();
        int getDef();
        int getSpeed();
        void setNewHP(int hp);
        string getSkills();
    }
}
