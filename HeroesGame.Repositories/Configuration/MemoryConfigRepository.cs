using System.Collections.Generic;
using HeroesGame.Configuration;

namespace HeroesGame.Repositories
{
    public class MemoryConfigRepository : IConfigRepository
    {
        private Dictionary<string, string> _configValues = new Dictionary<string, string>();

        public string GetParameterValue(string parameterName)
        {
            return _configValues[parameterName];
        }

        public void SetConfigParameter(string parameter, string value)
        {
            _configValues.Add(parameter, value);
        }
    }
}
