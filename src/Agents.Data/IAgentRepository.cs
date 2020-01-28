using System;
using System.Collections.Generic;
using System.Text;
using Agents.Data.Model;

namespace Agents.Data
{
    public interface IAgentRepository<T>: IRepository<T> where T : EntityBase
    {
    }
}
