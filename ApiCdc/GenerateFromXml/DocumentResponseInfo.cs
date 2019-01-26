namespace ApiCdc
{
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot("file", Namespace = "", IsNullable = false)]
    public class DocumentResponseInfo
    {

        [System.Xml.Serialization.XmlAttribute("name")]
        public string FileName { get; set; }

        [System.Xml.Serialization.XmlAttribute("mime")]
        public string MimeType { get; set; }

        [System.Xml.Serialization.XmlText()]
        public string FileData { get; set; }
    }
}
