using System.Xml;

namespace ApiCdc
{
    /// <summary>
    /// Response from archive list request
    /// </summary>
    public class ArchiveStatusResponse : Response<ArchiveStatusResponseData>
    {
        public override void LoadXmlData(XmlDocument doc)
        {
            Data = new ArchiveStatusResponseData(doc.InnerXml);
        }
    }

    /// <summary>
    /// Response data structure
    /// </summary>
    public class ArchiveStatusResponseData
    {
        /// <summary>
        /// Section data
        /// </summary>
        private ArchiveStatusResponseInfo _dataBrute;

        /// <summary>
        /// Constructor to parse xml
        /// </summary>
        /// <param name="xmlData">xmlstring of response</param>
        public ArchiveStatusResponseData(string xmlData)
        {
            _dataBrute = Tools.DeserializeXmlString(typeof(ArchiveStatusResponseInfo), xmlData) as ArchiveStatusResponseInfo;
        }

        /// <summary>
        /// Archive Status List
        /// </summary>
        public Process[] Processes { get { return _dataBrute.Processes; } }
    }
}