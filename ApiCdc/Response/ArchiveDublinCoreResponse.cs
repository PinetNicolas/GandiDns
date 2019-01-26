using System.Xml;

namespace ApiCdc
{
    /// <summary>
    /// Response from archive list request
    /// </summary>
    public class ArchiveDublinCoreResponse : Response<ArchiveDublinCoreResponseData>
    {
        public override void LoadXmlData(XmlDocument doc)
        {
            Data = new ArchiveDublinCoreResponseData(doc.InnerXml);
        }
    }

    /// <summary>
    /// Response data structure
    /// </summary>
    public class ArchiveDublinCoreResponseData
    {
        /// <summary>
        /// Section data
        /// </summary>
        private ArchiveDublinCoreResponseInfo _dataBrute;

        /// <summary>
        /// Constructor to parse xml
        /// </summary>
        /// <param name="xmlData">xmlstring of response</param>
        public ArchiveDublinCoreResponseData(string xmlData)
        {
            _dataBrute = Tools.DeserializeXmlString(typeof(ArchiveDublinCoreResponseInfo), xmlData) as ArchiveDublinCoreResponseInfo;
        }

        /// <summary>
        /// Archive List
        /// </summary>
        //public ArchiveElement[] Archives { get { return _dataBrute.ArchiveElement; } }
    }
}
