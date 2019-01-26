using Api.Gandi.Base;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Api.Gandi.Domain.Response
{
    /// <summary>
    /// Response from archive list request
    /// </summary>
    public class DomainUpdateResponse : Response<DomainUpdateResponseData>
    {
        /// <summary>
        /// Function to parse json response
        /// </summary>
        /// <param name="json">String containing json</param>
        public override void parseJson(string json)
        {
            Data = new DomainUpdateResponseData(json);
        }
    }

    /// <summary>
    /// Response data structure
    /// </summary>
    public class DomainUpdateResponseData
    {
        /// <summary>
        /// Section data
        /// </summary>
        private string _dataBrute;

        /// <summary>
        /// Constructor to parse json
        /// </summary>
        /// <param name="json">json string of response</param>
        public DomainUpdateResponseData(string json)
        {
            _dataBrute = json;
            Domain = JsonConvert.DeserializeObject<DomainDto>(json);
        }

        public DomainDto Domain { get; private set; }
    }

}
