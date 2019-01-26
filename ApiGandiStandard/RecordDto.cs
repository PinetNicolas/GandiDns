using Newtonsoft.Json;
using System.Collections.Generic;

namespace Api.Gandi
{
    public class RecordDto
    {
        [JsonProperty(PropertyName = "rrset_type")]
        public string RrsetType { get; set; }
        [JsonProperty(PropertyName = "rrset_ttl")]
        public int RrsetTtl { get; set; }
        [JsonProperty(PropertyName = "rrset_name")]
        public string RrsetName { get; set; }
        [JsonProperty(PropertyName = "rrset_values")]
        public List<string> RrsetValues { get; set; }
    }
}
