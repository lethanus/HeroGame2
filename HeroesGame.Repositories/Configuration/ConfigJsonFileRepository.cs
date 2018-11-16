using System.Collections.Generic;
using HeroesGame.Configuration;
using Newtonsoft.Json;
using System.IO;

namespace HeroesGame.Repositories
{
    public class ConfigJsonFileRepository : IConfigRepository
    {
        private string _pathToRepoFile = "";
        private Dictionary<string, string> _configValues = new Dictionary<string, string>();

        public ConfigJsonFileRepository(string pathToRepoFile)
        {
            _pathToRepoFile = pathToRepoFile;
        }

        public string GetParameterValue(string parameterName)
        {
            _configValues = GetAllParameters(_pathToRepoFile);
            return _configValues[parameterName];
        }

        public void SetConfigParameter(string parameter, string value)
        {
            _configValues = GetAllParameters(_pathToRepoFile);
            _configValues.Add(parameter, value);
            SaveAllParameters(_configValues, _pathToRepoFile);
        }

        private Dictionary<string, string> GetAllParameters(string pathToFile)
        {
            if (!File.Exists(pathToFile))
            {
                return new Dictionary<string, string>();
            }
            var json = File.ReadAllText(pathToFile);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        private void SaveAllParameters(Dictionary<string, string> configurationParameters, string pathToFile)
        {
            string json = JsonConvert.SerializeObject(configurationParameters, Formatting.Indented);
            File.WriteAllText(pathToFile, json);
        }
    }
}
