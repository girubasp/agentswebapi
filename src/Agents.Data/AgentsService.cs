using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Agents.Data.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Agents.Data
{
    public class AgentsService : IAgentsService
    {
        private static string GetMockData(string jsonFileName)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var jsonPath = Path.Combine(basePath, $"MockData/{jsonFileName}");
            return jsonPath;
        }

        public List<Agent> Get()
        {
            using (StreamReader file = File.OpenText(GetMockData("agents.json")))
            {
                return JsonConvert.DeserializeObject<List<Agent>>(file.ReadToEnd());
            }
        }

       
    }

    public interface IAgentsService
    {
        List<Agent> Get();
    }
}
