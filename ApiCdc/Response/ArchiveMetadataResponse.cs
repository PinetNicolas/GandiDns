using System.Xml;

namespace ApiCdc
{
    /// <summary>
    /// Response from archive list request
    /// </summary>
    public class ArchiveMetadataResponse : Response<ArchiveMetadataResponseData>
    {
        public override void LoadXmlData(XmlDocument doc)
        {
            Data = new ArchiveMetadataResponseData(doc.InnerXml);
        }
    }

    /// <summary>
    /// Response data structure
    /// </summary>
    public class ArchiveMetadataResponseData
    {
        /// <summary>
        /// Section data
        /// </summary>
        private ArchiveMetadataResponseInfo _dataBrute;

        /// <summary>
        /// Constructor to parse xml
        /// </summary>
        /// <param name="xmlData">xmlstring of response</param>
        public ArchiveMetadataResponseData(string xmlData)
        {
            _dataBrute = Tools.DeserializeXmlString(typeof(ArchiveMetadataResponseInfo), xmlData) as ArchiveMetadataResponseInfo;
        }

        /// <summary>
        /// Archive List
        /// </summary>
        //public ArchiveElement[] Archives { get { return _dataBrute.ArchiveElement; } }
    }
}
