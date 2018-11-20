using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.Core.Randomizers
{
    public class ValueRandomizer
    {

        public static int GetRandomValueInRange(int min, int max)
        {
            var bytes = Guid.NewGuid().ToByteArray();
            int seed = 0;
            foreach (var byte_value in bytes)
            {
                seed += Convert.ToInt32(byte_value);
            }
            var randomizer = new Random(seed);
            return randomizer.Next(min, max);
        }
    }
}
