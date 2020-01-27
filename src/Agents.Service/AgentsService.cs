using System.Collections.Generic;
using System.Linq;
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

        public void Add(Agent agent)
        {
            var dbAgents = _db.Get();
            dbAgents.Add(agent);
            _db.Update(dbAgents);
        }

        public void Update(Agent agent)
        {
            var dbAgents = _db.Get();
            dbAgents[dbAgents.FindIndex(a => a.Id == agent.Id)] = agent;
            _db.Update(dbAgents);
        }

        public List<Agent> Get()
        {
            return _db.Get();
        }
    }
}