using Api.Gandi.Base;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Api.Gandi.Domain.Response
{
    /// <summary>
    /// Response from archive list request
    /// </summary>
    public class DomainCreateResponse : Response<DomainCreateResponseData>
    {
        /// <summary>
        /// Function to parse json response
        /// </summary>
        /// <param name="json">String containing json</param>
        public override void parseJson(string json)
        {
            Data = new DomainCreateResponseData(json);
        }
    }

    /// <summary>
    /// Response data structure
    /// </summary>
    public class DomainCreateResponseData
    {
        /// <summary>
        /// Section data
        /// </summary>
        private string _dataBrute;

        /// <summary>
        /// Constructor to parse json
        /// </summary>
        /// <param name="json">json string of response</param>
        public DomainCreateResponseData(string json)
        {
            _dataBrute = json;
            DomainCreateResponseData data = JsonConvert.DeserializeObject<DomainCreateResponseData>(json);
            this.Message = data.Message;
            this.Uuid = data.Uuid;
        }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }
    }

}
