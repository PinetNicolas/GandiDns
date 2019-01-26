using System.Xml;

namespace ApiCdc
{
    /// <summary>
    /// Response from archive list request
    /// </summary>
    public class ArchiveResponse : Response<ArchiveResponseData>
    {
        public override void LoadXmlData(XmlDocument doc)
        {
            Data = new ArchiveResponseData(doc.InnerXml);
        }
    }

    /// <summary>
    /// Response data structure
    /// </summary>
    public class ArchiveResponseData
    {
        /// <summary>
        /// Section data
        /// </summary>
        private ArchiveResponseInfo _dataBrute;

        /// <summary>
        /// Constructor to parse xml
        /// </summary>
        /// <param name="xmlData">xmlstring of response</param>
        public ArchiveResponseData(string xmlData)
        {
            _dataBrute = Tools.DeserializeXmlString(typeof(ArchiveResponseInfo), xmlData) as ArchiveResponseInfo;
        }

        /// <summary>
        /// Archive List
        /// </summary>
        //public ArchiveElement[] Archives { get { return _dataBrute.ArchiveElement; } }
    }
}