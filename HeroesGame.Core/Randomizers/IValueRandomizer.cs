using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.Core.Randomizers
{
    public interface IValueRandomizer
    {
        int GetRandomValueInRange(int min, int max, string subject);
        void SetReturnValue(string subject, int fixedValue);
    }
}
