using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroGame.Characters
{
    public interface ICharacter
    {
        string getID();
        string getName();
        int getMaxHp();
        int getHp();
        int getAtt();
        int getDef();
        int getSpeed();
        void setNewHP(int hp);
    }
}
