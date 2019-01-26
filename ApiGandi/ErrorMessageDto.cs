
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Api.Gandi
{
    public class ErrorMessageDto
    {
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
        [JsonProperty(PropertyName = "object")]
        public string ObjectInfo { get; set; }
        [JsonProperty(PropertyName = "cause")]
        public string Cause { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "errors")]
        public List<ErrorDetailDto> Errors { get; set; }

    }

    public class ErrorDetailDto
    {
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "line")]
        public string Line { get; set; }
        [JsonProperty(PropertyName = "cause")]
        public string Cause { get; set; }
    }
}
