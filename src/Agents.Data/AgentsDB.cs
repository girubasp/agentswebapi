using System;
using System.Collections.Generic;
using System.IO;
using Agents.Data.Model;
using Newtonsoft.Json;

namespace Agents.Data
{
    public class AgentsDB : IAgentsDB
    {
        private static List<Agent> _data;
        private static string GetMockData(string jsonFileName)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var jsonPath = Path.Combine(basePath, $"MockData/{jsonFileName}");
            return jsonPath;
        }

        public List<Agent> Get()
        {
            if (_data == null || _data.Count == 0)
                using (StreamReader file = File.OpenText(GetMockData("agents.json")))
                {
                    _data = JsonConvert.DeserializeObject<List<Agent>>(file.ReadToEnd());
                }

            return _data;
        }

        public void Update(List<Agent> agent)
        {
            _data = agent;
        }
    }

    public interface IAgentsDB
    {
        List<Agent> Get();
        void Update(List<Agent> agent);
    }
}
