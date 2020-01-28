using System.Collections.Generic;
using System.Threading.Tasks;
using Agents.Data;
using Agents.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace agentsapi.Controllers
{
    //[Authorize]
    [Microsoft.AspNetCore.Mvc.Route("api/agents")]
    [ApiController]
    public class AgentsListController : ControllerBase
    {
        private readonly IAgentRepository<Agent> _agentsService;

        public AgentsListController(IAgentRepository<Agent> agentsService)
        {
            _agentsService = agentsService;
        }
        // GET api/agents
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public List<Agent> Get()
        {
            return _agentsService.GetAll();
        }

        [Microsoft.AspNetCore.Mvc.HttpPut]
        public async Task<IActionResult> Put(Agent agent)
        {
            _agentsService.Upsert(agent);
            return Ok();
        }
    }
}
