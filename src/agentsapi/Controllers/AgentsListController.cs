using System.Collections.Generic;
using System.Threading.Tasks;
using Agents.Data.Model;
using Agents.Service;
using Microsoft.AspNetCore.Mvc;

namespace agentsapi.Controllers
{
    //[Authorize]
    [Microsoft.AspNetCore.Mvc.Route("api/agents")]
    [ApiController]
    public class AgentsListController : ControllerBase
    {
        private readonly IAgentsService _agentsService;

        public AgentsListController(IAgentsService agentsService)
        {
            _agentsService = agentsService;
        }
        // GET api/agents
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<List<Agent>> Get()
        {
            return await _agentsService.Get();
        }

        [Microsoft.AspNetCore.Mvc.HttpPut]
        public async Task<IActionResult> Put(Agent agent)
        {
            _agentsService.Upsert(agent);
            return Ok();
        }
    }
}
