using System.Xml;
using ApiCdc.GenerateFromXml;

namespace ApiCdc
{
    /// <summary>
    /// REsponse from section request
    /// </summary>
    public class SectionListResponse : Response<SectionListResponseData>
    {
        public override void LoadXmlData(XmlDocument doc)
        {
            Data = new SectionListResponseData(doc.InnerXml);
        }
    }

    /// <summary>
    /// Response data structure
    /// </summary>
    public class SectionListResponseData
    {
        /// <summary>
        /// Section data
        /// </summary>
        private SectionListReponseInfo _dataBrute;

        /// <summary>
        /// Constructor to parse xml
        /// </summary>
        /// <param name="xmlData">xmlstring of response</param>
        public SectionListResponseData(string xmlData)
        {
            _dataBrute = Tools.DeserializeXmlString(typeof(SectionListReponseInfo), xmlData) as SectionListReponseInfo;
        }

        /// <summary>
        /// Section identifiant
        /// </summary>
        public string FirstSectionId { get { return _dataBrute.Sections[0].Id; } }


    }
}