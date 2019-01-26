
namespace ApiCdc
{
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot("archive-list", Namespace = "", IsNullable = false)]
    public partial class ArchiveListResponseInfo
    {
        [System.Xml.Serialization.XmlElement("archive-list-element", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ArchiveElement[] ArchiveElement { get; set; }

        [System.Xml.Serialization.XmlAttribute("num-results")]
        public string NumberResults { get; set; }

        [System.Xml.Serialization.XmlAttribute("max-results")]
        public string Maxresults { get; set; }

        [System.Xml.Serialization.XmlAttribute("range-last")]
        public string Rangelast { get; set; }

        [System.Xml.Serialization.XmlAttribute("cut-off-date")]
        public string CutOffDate { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class ArchiveElement
    {
        [System.Xml.Serialization.XmlElement("descriptive-metadata", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DescriptiveMetadata DescriptiveMetaData { get; set; }

        [System.Xml.Serialization.XmlElement("index-applicative-metadata", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public IndexApplicativeMetadata IndexApplicativeMetadata { get; set; }

        [System.Xml.Serialization.XmlAttribute("archive-id")]
        public string ArchiveId { get; set; }

        [System.Xml.Serialization.XmlAttribute("deposit-date")]
        public string DepositDate { get; set; }

        [System.Xml.Serialization.XmlAttribute("end-of-life-date")]
        public string endoflifedate { get; set; }

        [System.Xml.Serialization.XmlAttribute("size")]
        public string Size { get; set; }
    }

}
