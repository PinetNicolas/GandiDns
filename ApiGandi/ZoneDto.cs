
using Newtonsoft.Json;

namespace Api.Gandi
{
    /// <summary>
    /// Object Zone
    /// </summary>
    public class ZoneDto
    {
        [JsonProperty(PropertyName = "retry")]
        public int Retry { get; set; }
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }
        [JsonProperty(PropertyName = "zone_href")]
        public string ZoneHref { get; set; }
        [JsonProperty(PropertyName = "minimum")]
        public int Minimum { get; set; }
        [JsonProperty(PropertyName = "domains_href")]
        public string DomainsHref { get; set; }
        [JsonProperty(PropertyName = "refresh")]
        public int Refresh { get; set; }
        [JsonProperty(PropertyName = "zone_records_href")]
        public string ZoneRecordsHref { get; set; }
        [JsonProperty(PropertyName = "expire")]
        public int Expire { get; set; }
        [JsonProperty(PropertyName = "sharing_id")]
        public string SharingId { get; set; }
        [JsonProperty(PropertyName = "serial")]
        public int Serial { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "primary_ns")]
        public string PrimaryNs { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
