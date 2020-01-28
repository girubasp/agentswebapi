using System.Collections.Generic;
using System.Threading.Tasks;
using Agents.Data;
using Agents.Data.Model;
using Agents.Service;
using Microsoft.AspNetCore.Mvc;

namespace agentsapi.Controllers
{
    //[Authorize]
    [Microsoft.AspNetCore.Mvc.Route("api/customers")]
    [ApiController]
    public class CustomersListController : ControllerBase
    {
        private readonly ICustomerRepository<Customer> _db;

        public CustomersListController(ICustomerRepository<Customer> db)
        {
            _db = db;
        }
        public List<Customer> Get()
        {
            return _db.GetAll();
        }

        // GET api/customers
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Route("{agentId}")]
        public   List<Customer> Get(int agentId)
        {
            return  _db.GetByAgentId(agentId);
        }

        [Microsoft.AspNetCore.Mvc.HttpPut]
        public async Task<IActionResult> Put(Customer customer)
        {
            _db.Update(customer);
            return Ok();
        }
        [Microsoft.AspNetCore.Mvc.HttpDelete]
        public async Task<IActionResult> Delete(Customer customer)
        {
            _db.Delete(customer);
            return Ok();
        }
    }
}
