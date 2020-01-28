using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Agents.Data.Model
{
    public abstract class EntityBase
    {
        [JsonProperty("_id")]
        public int Id { get; protected set; }
    }
}
