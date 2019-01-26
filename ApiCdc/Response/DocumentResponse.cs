
using System;
using System.Xml;

namespace ApiCdc
{
    public class DocumentResponse : Response<DocumentResponseData>
    {
        public override void LoadXmlData(XmlDocument doc)
        {
            Data = new DocumentResponseData(doc.InnerXml);
        }
    }

    public class DocumentResponseData
    {
        DocumentResponseInfo _dataBrute;

        public DocumentResponseData(string xmlData)
        {
            _dataBrute = Tools.DeserializeXmlString(typeof(DocumentResponseInfo), xmlData) as DocumentResponseInfo;
        }

        public string FileName { get { return _dataBrute.FileName; } }
        public string MimeType { get { return _dataBrute.MimeType; } }
        public byte[] FileData { get { return Convert.FromBase64String(_dataBrute.FileData); } }
    }
}
