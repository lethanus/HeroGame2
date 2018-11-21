using System.Collections.Generic;

namespace HeroesGame.Configuration
{
    public interface IConfigRepository
    {
        string GetParameterValue(string parameterName);
        void SetConfigParameter(string parameter, string value);
        Dictionary<string, string> GetAll();
    }
}
