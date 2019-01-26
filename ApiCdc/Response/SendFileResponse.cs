
using System.Xml;
using ApiCdc.GenerateFromXml;

namespace ApiCdc
{
    public class SendFileResponse : Response<SendFileResponseData>
    {
        public override void LoadXmlData(XmlDocument doc)
        {
            Data = new SendFileResponseData(doc.InnerXml);
        }
    }

    public class SendFileResponseData
    {
        private SendFileRespopnseInfo _dataBrute;
        public SendFileResponseData(string xmlData)
        {
            _dataBrute = Tools.DeserializeXmlString(typeof(SendFileRespopnseInfo), xmlData) as SendFileRespopnseInfo;
        }

        public string ArchiveId { get { return _dataBrute.ArchiveId; } }

        public string DepositeDate { get { return _dataBrute.DepositDate; } }

        public string ApplicativeMetaDataDigest { get { return _dataBrute.Digests[0].ApplicativeMetadataDigest.Value; } }
        public string DataObjectDigest { get { return _dataBrute.Digests[0].DataObjectDigest.Value; } }
        public string DescriptiveMetaDataDigest { get { return _dataBrute.Digests[0].DescriptiveMetadataDigest.Value; } }
    }

}
