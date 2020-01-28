using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Agents.Data;
using Agents.Data.Model;
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
            if (customer.IsNew() || ValidateIfCustomerBelongsToAgent(customer))
                _db.Upsert(customer);
            return Ok();
        }

        private bool ValidateIfCustomerBelongsToAgent(Customer customer)
        {
            var dbcustomer = _db.GetById(customer.Id);
            if(dbcustomer == null)
                throw new ArgumentException("Customer not found");
            if(dbcustomer.AgentId != customer.AgentId)
                throw new ArgumentException("Customer does not belong to agent");
            return true;
        }

        [Microsoft.AspNetCore.Mvc.HttpDelete]
        public async Task<IActionResult> Delete(Customer customer)
        {
            _db.Delete(customer);
            return Ok();
        }
    }
}
