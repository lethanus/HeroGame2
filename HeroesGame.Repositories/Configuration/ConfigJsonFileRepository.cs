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
            var configValues = GetAllParameters(_pathToRepoFile);
            if (configValues.Count(x=>x.Name == parameterName) == 0 ) return "";
            return configValues.First(x=>x.Name == parameterName).Value;
        }

        public void SetConfigParameter(string parameter, string value)
        {
            var configValues = GetAllParameters(_pathToRepoFile);
            configValues.Add(new ConfigurationParameter { Name = parameter, Value = value });
            SaveAllParameters(configValues, _pathToRepoFile);
        }

        public List<ConfigurationParameter> GetAll()
        {
            return GetAllParameters(_pathToRepoFile);
        }

        private List<ConfigurationParameter> GetAllParameters(string pathToFile)
        {
            if (!File.Exists(pathToFile))
            {
                return new List<ConfigurationParameter>();
            }
            var json = File.ReadAllText(pathToFile);
            return JsonConvert.DeserializeObject<List<ConfigurationParameter>>(json);
        }

        private void SaveAllParameters(List<ConfigurationParameter> configurationParameters, string pathToFile)
        {
            string json = JsonConvert.SerializeObject(configurationParameters, Formatting.Indented);
            File.WriteAllText(pathToFile, json);
        }
    }
}
