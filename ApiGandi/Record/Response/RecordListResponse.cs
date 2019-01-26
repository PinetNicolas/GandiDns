using Api.Gandi.Base;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Api.Gandi.Record.Response
{
    /// <summary>
    /// Response from archive list request
    /// </summary>
    public class RecordListResponse : Response<RecordListResponseData>
    {
        /// <summary>
        /// Function to parse json response
        /// </summary>
        /// <param name="json">String containing json</param>
        public override void parseJson(string json)
        {
            Data = new RecordListResponseData(json);
        }
    }

    /// <summary>
    /// Response data structure
    /// </summary>
    public class RecordListResponseData
    {
        /// <summary>
        /// Section data
        /// </summary>
        private string _dataBrute;

        /// <summary>
        /// Constructor to parse json
        /// </summary>
        /// <param name="json">json string of response</param>
        public RecordListResponseData(string json)
        {
            _dataBrute = json;
            Records = JsonConvert.DeserializeObject<List<RecordDto>>(json);
        }

        public List<RecordDto> Records { get; private set; }
    }

}
