using Api.Gandi.Base;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Api.Gandi.Domain.Response
{
    /// <summary>
    /// Response from archive list request
    /// </summary>
    public class DomainListResponse : Response<DomainListResponseData>
    {
        /// <summary>
        /// Function to parse json response
        /// </summary>
        /// <param name="json">String containing json</param>
        public override void parseJson(string json)
        {
            Data = new DomainListResponseData(json);
        }
    }

    /// <summary>
    /// Response data structure
    /// </summary>
    public class DomainListResponseData
    {
        /// <summary>
        /// Section data
        /// </summary>
        private string _dataBrute;

        /// <summary>
        /// Constructor to parse json
        /// </summary>
        /// <param name="json">json string of response</param>
        public DomainListResponseData(string json)
        {
            _dataBrute = json;
            Domains = JsonConvert.DeserializeObject<List<DomainDto>>(json);
        }

        public List<DomainDto> Domains { get; private set; }
    }

}
