using Newtonsoft.Json;
using System.Collections.Generic;

namespace RestSharpTest.DataEntities
{
    class Breeds
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public List<string> Message { get; set; }
    }
}
