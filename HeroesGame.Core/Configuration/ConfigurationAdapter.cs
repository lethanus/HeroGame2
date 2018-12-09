using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.Configuration
{
    public class ConfigurationAdapter
    {
        public int NumberOfRecruits { get; private set; }
        public Dictionary<int, ChanceRange> MercenaryGenerateChances { get; private set; }
        public Dictionary<int, ChanceRange> MercenaryConvinceChances { get; private set; }
        private bool _alreadyLoaded = false;

        public void LoadMercenaryConfigs(IConfigRepository configRepository)
        {
            if (!_alreadyLoaded)
            {
                var value = configRepository.GetParameterValue("NumberOfRecruits");
                NumberOfRecruits = string.IsNullOrEmpty(value) ? 0 :  Int32.Parse(value);

                MercenaryGenerateChances = new Dictionary<int, ChanceRange>();
                MercenaryGenerateChances.Add(1, new ChanceRange(configRepository.GetParameterValue("ChanceForLevel_1_mercenary")));
                MercenaryGenerateChances.Add(2, new ChanceRange(configRepository.GetParameterValue("ChanceForLevel_2_mercenary")));
                MercenaryGenerateChances.Add(3, new ChanceRange(configRepository.GetParameterValue("ChanceForLevel_3_mercenary")));
                MercenaryGenerateChances.Add(4, new ChanceRange(configRepository.GetParameterValue("ChanceForLevel_4_mercenary")));

                MercenaryConvinceChances = new Dictionary<int, ChanceRange>();
                MercenaryConvinceChances.Add(1, new ChanceRange(configRepository.GetParameterValue("ConvinceLevel_1_recruit")));
                MercenaryConvinceChances.Add(2, new ChanceRange(configRepository.GetParameterValue("ConvinceLevel_2_recruit")));
                MercenaryConvinceChances.Add(3, new ChanceRange(configRepository.GetParameterValue("ConvinceLevel_3_recruit")));
                MercenaryConvinceChances.Add(4, new ChanceRange(configRepository.GetParameterValue("ConvinceLevel_4_recruit")));
                _alreadyLoaded = true;
            }
        }
    }

}
