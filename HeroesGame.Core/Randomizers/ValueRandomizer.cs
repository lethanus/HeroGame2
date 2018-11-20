using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.Core.Randomizers
{
    public class ValueRandomizer : IValueRandomizer
    {
        private int _valueToReturn = -1;
        public int GetRandomValueInRange(int min, int max)
        {
            if (_valueToReturn > -1) return _valueToReturn;
            var bytes = Guid.NewGuid().ToByteArray();
            int seed = 0;
            foreach (var byte_value in bytes)
            {
                seed += Convert.ToInt32(byte_value);
            }
            var randomizer = new Random(seed);
            return randomizer.Next(min, max);
        }

        public void SetReturnValue(int value)
        {
            _valueToReturn = value;
        }
    }
}
