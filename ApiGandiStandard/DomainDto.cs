using Newtonsoft.Json;

namespace Api.Gandi
{
    public class DomainDto
    {
        [JsonProperty(PropertyName = "fqdn")]
        public string FQDN { get; set; }
        [JsonProperty(PropertyName = "zone_uuid")]
        public string ZoneUuid { get; set; }
        [JsonProperty(PropertyName = "domain_keys_href")]
        public string DomainKeysHref { get; set; }
        [JsonProperty(PropertyName = "zone_href")]
        public string ZoneHref { get; set; }
        [JsonProperty(PropertyName = "zone_records_href")]
        public string ZoneRecordsHref { get; set; }
        [JsonProperty(PropertyName = "domain_records_href")]
        public string DomainRecordsHref { get; set; }
        [JsonProperty(PropertyName = "domain_href")]
        public string DomainHref { get; set; }
    }
}
