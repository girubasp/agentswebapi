using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        private List<Agent> data
        {
            get
            {
                if (_data == null)
                    Get();
                return _data;
            }

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
        public Agent Get(int agentId)
        {
            return data.FirstOrDefault(a => a.Id == agentId);
        }
        public void Insert(Agent agent)
        {
            data.Add(agent);
        }
        public void Update(Agent agent)
        {
            var index = data.FindIndex(a => a.Id == agent.Id);
            data[index] = agent;
        }
    }

    public interface IAgentsDB
    {
        List<Agent> Get();
        Agent Get(int agentId);
        void Insert(Agent agent);
        void Update(Agent agent);
    }
}
