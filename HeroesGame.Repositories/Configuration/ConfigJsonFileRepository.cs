using System.Collections.Generic;
using HeroesGame.Configuration;
using Newtonsoft.Json;
using System.IO;
using System.Linq;


namespace HeroesGame.Repositories
{
    public class ConfigJsonFileRepository : JsonListRepository<ConfigurationParameter>,  IConfigRepository
    {
        public ConfigJsonFileRepository(string pathToRepoFile) : base(pathToRepoFile) { }

        public string GetParameterValue(string parameterName)
        {
            var configValues = GetAll();
            if (configValues.Count(x=>x.Name == parameterName) == 0 ) return "";
            return configValues.First(x=>x.Name == parameterName).Value;
        }

        public void SetConfigParameter(string parameterName, string value)
        {
            var configValues = GetAll();
            var parameter = configValues.FirstOrDefault(x => x.Name == parameterName);
            if(parameter == null)
                configValues.Add(new ConfigurationParameter { Name = parameterName, Value = value });
            else
                configValues.First(x => x.Name == parameterName).Value = value;
            SaveAll(configValues);
        }
    }
}
