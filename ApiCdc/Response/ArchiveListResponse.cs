using System.Xml;

namespace ApiCdc
{
    /// <summary>
    /// Response from archive list request
    /// </summary>
    public class ArchiveListResponse : Response<ArchiveListResponseData>
    {
        public override void LoadXmlData(XmlDocument doc)
        {
            Data = new ArchiveListResponseData(doc.InnerXml);
        }
    }

    /// <summary>
    /// Response data structure
    /// </summary>
    public class ArchiveListResponseData
    {
        /// <summary>
        /// Section data
        /// </summary>
        private ArchiveListResponseInfo _dataBrute;

        /// <summary>
        /// Constructor to parse xml
        /// </summary>
        /// <param name="xmlData">xmlstring of response</param>
        public ArchiveListResponseData(string xmlData)
        {
            _dataBrute = Tools.DeserializeXmlString(typeof(ArchiveListResponseInfo), xmlData) as ArchiveListResponseInfo;
        }

        /// <summary>
        /// Archive List
        /// </summary>
        public ArchiveElement[] Archives { get { return _dataBrute.ArchiveElement; } }
    }
}