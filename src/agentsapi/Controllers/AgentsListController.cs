using System.Collections.Generic;
using Agents.Data;
using Agents.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace agentsapi.Controllers
{
    //[Authorize]
    [Route("api/agents")]
    [ApiController]
    public class AgentsListController : ControllerBase
    {
        private readonly IAgentsService _agentsService;

        public AgentsListController(IAgentsService agentsService)
        {
            _agentsService = agentsService;
        }
        // GET api/agents
        [HttpGet]
        public List<Agent> Get()
        {
            return _agentsService.Get(); 
        }
    }
}
