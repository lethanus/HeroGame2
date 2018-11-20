using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.Core.Randomizers
{
    public class ValueRandomizer : IValueRandomizer
    {
        Dictionary<string, int> _fixedValues = new Dictionary<string, int>();

        public int GetRandomValueInRange(int min, int max, string subject)
        {
            if (_fixedValues.ContainsKey(subject)) return _fixedValues[subject];
            var bytes = Guid.NewGuid().ToByteArray();
            int seed = 0;
            foreach (var byte_value in bytes)
            {
                seed += Convert.ToInt32(byte_value);
            }
            var randomizer = new Random(seed);
            return randomizer.Next(min, max);
        }

        public void SetReturnValue(string subject, int fixedValue)
        {
            _fixedValues.Add(subject, fixedValue);
        }
    }
}
