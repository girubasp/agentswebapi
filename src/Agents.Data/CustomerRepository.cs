using System.Collections.Generic;
using System.Linq;
using Agents.Data.Model;

namespace Agents.Data
{
    public class CustomerRepository  : Repository<Customer>, ICustomerRepository<Customer>
    {
        public List<Customer> GetByAgentId(int id)
        {
            return Data.Where(f => f.AgentId == id).ToList();
        }
    }
}