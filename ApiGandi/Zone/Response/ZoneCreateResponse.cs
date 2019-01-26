using Api.Gandi.Base;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Api.Gandi.Zone.Response
{
    /// <summary>
    /// Response from archive list request
    /// </summary>
    public class ZoneCreateResponse : Response<ZoneCreateResponseData>
    {
        /// <summary>
        /// Function to parse json response
        /// </summary>
        /// <param name="json">String containing json</param>
        public override void parseJson(string json)
        {
            Data = new ZoneCreateResponseData(json);
        }
    }

    /// <summary>
    /// Response data structure
    /// </summary>
    public class ZoneCreateResponseData
    {
        /// <summary>
        /// Section data
        /// </summary>
        private string _dataBrute;

        /// <summary>
        /// Constructor to parse json
        /// </summary>
        /// <param name="json">json string of response</param>
        public ZoneCreateResponseData(string json)
        {
            _dataBrute = json;
            var data = JsonConvert.DeserializeObject<dynamic>(json);
            this.Message = data.message;
            this.Uuid = data.uuid;
        }

        public string Message { get; private set; }
        public string Uuid { get; private set; }
    }

}
