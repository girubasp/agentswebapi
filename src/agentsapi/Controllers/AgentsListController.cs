using System.Collections.Generic;
using Agents.Data;
using Agents.Data.Model;
using Agents.Service;
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

        [HttpPost]
        public ActionResult Add(Agent agent)
        {
            if (agent.Id > 0)
                if (!_agentsService.CheckNameExists(agent.Name))
                    _agentsService.Add(agent);
                else
                    return BadRequest($"{agent.Name} already exists. Please choose a different name");
            else
                _agentsService.Update(agent);
            return Ok(_agentsService.Get());
        }
    }
}
