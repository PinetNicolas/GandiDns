using System.Xml;

namespace ApiCdc
{
    /// <summary>
    /// Response from archive list request
    /// </summary>
    public class EvaultListResponse : Response<EvaultListResponseData>
    {
        public override void LoadXmlData(XmlDocument doc)
        {
            Data = new EvaultListResponseData(doc.InnerXml);
        }
    }

    /// <summary>
    /// Response data structure
    /// </summary>
    public class EvaultListResponseData
    {
        /// <summary>
        /// Section data
        /// </summary>
        private EvaultListResponseInfo _dataBrute;

        /// <summary>
        /// Constructor to parse xml
        /// </summary>
        /// <param name="xmlData">xmlstring of response</param>
        public EvaultListResponseData(string xmlData)
        {
            _dataBrute = Tools.DeserializeXmlString(typeof(EvaultListResponseInfo), xmlData) as EvaultListResponseInfo;
        }

        /// <summary>
        /// List of evault find
        /// </summary>
        public Cfe[] EvaultList { get { return _dataBrute.Items; } }


    }
}
