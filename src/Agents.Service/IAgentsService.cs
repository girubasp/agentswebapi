using System;
using System.Collections.Generic;
using Agents.Data.Model;

namespace Agents.Service
{

    public interface IAgentsService
    {
        List<Agent> Get();
        bool CheckNameExists(string agentName);
        void Add(Agent agent);
        void Update(Agent agent);
    }
}
