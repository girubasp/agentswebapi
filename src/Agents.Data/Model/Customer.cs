using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Agents.Data.Model
{
    public class Customer : EntityBase
    {
        [JsonProperty("agent_id")]
        public int AgentId { get; set; }
        public Guid Guid { get; set; }
        public bool IsActive { get; set; }
        public string Balance { get; set; }
        public int Age { get; set; }
        public string EyeColor { get; set; }
    }
}