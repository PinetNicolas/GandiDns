﻿using Api.Gandi.Base;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Api.Gandi.Zone.Response
{
    /// <summary>
    /// Response from archive list request
    /// </summary>
    public class ZoneDetailResponse : Response<ZoneDetailResponseData>
    {
        /// <summary>
        /// Function to parse json response
        /// </summary>
        /// <param name="json">String containing json</param>
        public override void parseJson(string json)
        {
            Data = new ZoneDetailResponseData(json);
        }
    }

    /// <summary>
    /// Response data structure
    /// </summary>
    public class ZoneDetailResponseData
    {
        /// <summary>
        /// Section data
        /// </summary>
        private string _dataBrute;

        /// <summary>
        /// Constructor to parse json
        /// </summary>
        /// <param name="json">json string of response</param>
        public ZoneDetailResponseData(string json)
        {
            _dataBrute = json;
            Zone = JsonConvert.DeserializeObject<ZoneDto>(json);
        }

        public ZoneDto Zone { get; private set; }
    }

}
