using System.Collections.Generic;
using HeroesGame.Configuration;
using Newtonsoft.Json;
using System.IO;
using System.Linq;


namespace HeroesGame.Repositories
{
    public class ConfigJsonFileRepository : IConfigRepository
    {
        private string _pathToRepoFile = "";

        public ConfigJsonFileRepository(string pathToRepoFile)
        {
            _pathToRepoFile = pathToRepoFile;
        }
        public string GetParameterValue(string parameterName)
        {
            var configValues = GetAll();
            if (configValues.Count(x=>x.Name == parameterName) == 0 ) return "";
            return configValues.First(x=>x.Name == parameterName).Value;
        }

        public void SetConfigParameter(string parameter, string value)
        {
            var configValues = GetAll();
            configValues.Add(new ConfigurationParameter { Name = parameter, Value = value });
            SaveAllParameters(configValues, _pathToRepoFile);
        }

        public List<ConfigurationParameter> GetAll()
        {
            if (!File.Exists(_pathToRepoFile))
            {
                return new List<ConfigurationParameter>();
            }
            var json = File.ReadAllText(_pathToRepoFile);
            return JsonConvert.DeserializeObject<List<ConfigurationParameter>>(json);
        }

        private void SaveAllParameters(List<ConfigurationParameter> configurationParameters, string pathToFile)
        {
            string json = JsonConvert.SerializeObject(configurationParameters, Formatting.Indented);
            File.WriteAllText(pathToFile, json);
        }
    }
}
