using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToAPI.Models
{
    class SearchResult<T> //pass in the type here so that the class can handle generic types in the property!
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("results")]
        public List<T> Results { get; set; }
    }
}

