using Newtonsoft.Json;
using System;

namespace Api.Gandi
{
    public class SnapshotDto
    {
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }
        [JsonProperty(PropertyName = "date_created")]
        public DateTime DateCreated { get; set; }
    }
}
