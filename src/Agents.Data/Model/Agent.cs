﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Agents.Data.Model
{
    public class Agent :EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int Tier { get; set; }
        public Phone Phone { get; set; }
    }
}
