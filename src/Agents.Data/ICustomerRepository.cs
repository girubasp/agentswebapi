using System.Collections.Generic;
using Agents.Data.Model;

namespace Agents.Data
{
    public interface ICustomerRepository<T> : IRepository<T> where T : EntityBase
    {
        List<T> GetByAgentId(int id);
    }
}