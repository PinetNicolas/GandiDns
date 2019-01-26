using Api.Gandi.Base;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Api.Gandi.Snapshot.Response
{
    /// <summary>
    /// Response from archive list request
    /// </summary>
    public class SnapshotListResponse : Response<SnapshotListResponseData>
    {
        /// <summary>
        /// Function to parse json response
        /// </summary>
        /// <param name="json">String containing json</param>
        public override void parseJson(string json)
        {
            Data = new SnapshotListResponseData(json);
        }
    }

    /// <summary>
    /// Response data structure
    /// </summary>
    public class SnapshotListResponseData
    {
        /// <summary>
        /// Section data
        /// </summary>
        private string _dataBrute;

        /// <summary>
        /// Constructor to parse json
        /// </summary>
        /// <param name="json">json string of response</param>
        public SnapshotListResponseData(string json)
        {
            _dataBrute = json;
            Snapshots = JsonConvert.DeserializeObject<List<SnapshotDto>>(json);
        }

        public List<SnapshotDto> Snapshots { get; private set; }
    }

}
