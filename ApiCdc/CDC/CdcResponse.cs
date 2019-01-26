using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ApiCdc
{
    /// <summary>
    /// Class for cdc response
    /// Since call is ascync we need a structure with 
    ///     Response
    ///     ErrorCode
    /// </summary>
    public class CdcResponse
    {
        /// <summary>
        /// Error Code of resquest. If None response contains data
        /// </summary>
        public CdcRequestCode ReturnCode { get; set; }

        /// <summary>
        /// Response of request if everything is ok.
        /// ReturnCode == ErrorCode.None
        /// </summary>
        public XmlDocument Response { get; set; }
    }
}
