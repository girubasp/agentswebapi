//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Agents.Data;
//using Agents.Data.Model;

//namespace Agents.Service
//{
//    public class AgentsService : IAgentsService
//    {
//        private readonly IAgentRepository<Agent> _db;

//        public AgentsService(IAgentRepository<Agent> db)
//        {
//            _db = db;
//        }
//        public bool CheckNameExists(string agentName)
//        {
//            return _db.GetAll().Any(a => a.Name == agentName);
//        }

//        public void Upsert(Agent agent)
//        {
//            if (_db.GetById(agent.Id) != null)
//                _db.Update(agent);
//            else
//                _db.Create(agent);
//        }

//        public async Task<List<Agent>> Get()
//        {
//            return _db.GetAll();
//        }
//    }
//}