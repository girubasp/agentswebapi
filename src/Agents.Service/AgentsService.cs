using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agents.Data;
using Agents.Data.Model;

namespace Agents.Service
{
    public class AgentsService : IAgentsService
    {
        private readonly IAgentsDB _db;

        public AgentsService(IAgentsDB db)
        {
            _db = db;
        }
        public bool CheckNameExists(string agentName)
        {
            return _db.Get().Any(a => a.Name == agentName);
        }

        public void Upsert(Agent agent)
        {
            if (_db.Get(agent.Id) != null)
                _db.Update(agent);
            else
                _db.Insert(agent);
        }

        public async Task<List<Agent>> Get()
        {
            return _db.Get();
        }
    }
}