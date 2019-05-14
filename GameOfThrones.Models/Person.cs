using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfThrones.Models
{
    public class Person
    {
        public List<string> Culture { get; set; }
        public List<string> Religion { get; set; }
        public List<string> Allegiances { get; set; }
        public List<string> Seasons { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Gender { get; set; }
        public bool Alive { get; set; }
        public string Father { get; set; }
        public string House { get; set; }
        [JsonProperty("first_seen")]
        public string FirstSeen { get; set; }
        public string Actor { get; set; }
        public string Mother { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
