using Api.Gandi.Base;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Api.Gandi.Zone.Response
{
    /// <summary>
    /// Response from archive list request
    /// </summary>
    public class ZoneListResponse : Response<ZoneListResponseData>
    {
        /// <summary>
        /// Function to parse json response
        /// </summary>
        /// <param name="json">String containing json</param>
        public override void parseJson(string json)
        {
            Data = new ZoneListResponseData(json);
        }
    }

    /// <summary>
    /// Response data structure
    /// </summary>
    public class ZoneListResponseData
    {
        /// <summary>
        /// Section data
        /// </summary>
        private string _dataBrute;

        /// <summary>
        /// Constructor to parse json
        /// </summary>
        /// <param name="json">json string of response</param>
        public ZoneListResponseData(string json)
        {
            _dataBrute = json;
            Zones = JsonConvert.DeserializeObject<List<ZoneDto>>(json);
        }

        public List<ZoneDto> Zones { get; private set; }
    }

}
