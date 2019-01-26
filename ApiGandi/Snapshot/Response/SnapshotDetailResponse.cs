using Api.Gandi.Base;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Api.Gandi.Snapshot.Response
{
    /// <summary>
    /// Response from archive list request
    /// </summary>
    public class SnapshotDetailResponse : Response<SnapshotDetailResponseData>
    {
        /// <summary>
        /// Function to parse json response
        /// </summary>
        /// <param name="json">String containing json</param>
        public override void parseJson(string json)
        {
            Data = new SnapshotDetailResponseData(json);
        }
    }

    /// <summary>
    /// Response data structure
    /// </summary>
    public class SnapshotDetailResponseData
    {
        /// <summary>
        /// Section data
        /// </summary>
        private string _dataBrute;

        /// <summary>
        /// Constructor to parse json
        /// </summary>
        /// <param name="json">json string of response</param>
        public SnapshotDetailResponseData(string json)
        {
            _dataBrute = json;
            Snapshot = JsonConvert.DeserializeObject<SnapshotDto>(json);
        }

        public SnapshotDto Snapshot { get; private set; }
    }

}
