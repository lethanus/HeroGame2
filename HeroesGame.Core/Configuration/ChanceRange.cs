using System.Linq;
using System;

namespace HeroesGame.Configuration
{
    public class ChanceRange
    {
        public int Value { get; private set; }
        public int MaxValue { get; private set; }
        public ChanceRange(string rangeString)
        {
            if (rangeString == "")
            {
                Value = 0;
                MaxValue = 10000;
            }
            else
            {
                var values = rangeString.Split('_').Select(x => Int32.Parse(x)).ToArray();
                Value = values[0];
                MaxValue = values[1];
            }
        }

    }


}
