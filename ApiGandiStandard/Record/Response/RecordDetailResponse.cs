using Api.Gandi.Base;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Api.Gandi.Record.Response
{
    /// <summary>
    /// Response from archive list request
    /// </summary>
    public class RecordDetailResponse : Response<RecordDetailResponseData>
    {
        /// <summary>
        /// Function to parse json response
        /// </summary>
        /// <param name="json">String containing json</param>
        public override void parseJson(string json)
        {
            Data = new RecordDetailResponseData(json);
        }
    }

    /// <summary>
    /// Response data structure
    /// </summary>
    public class RecordDetailResponseData
    {
        /// <summary>
        /// Section data
        /// </summary>
        private string _dataBrute;

        /// <summary>
        /// Constructor to parse json
        /// </summary>
        /// <param name="json">json string of response</param>
        public RecordDetailResponseData(string json)
        {
            _dataBrute = json;
            Record = JsonConvert.DeserializeObject<RecordDto>(json);
        }

        public RecordDto Record { get; private set; }
    }

}
