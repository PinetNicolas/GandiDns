
namespace ApiCdc.GenerateFromXml
{
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot("technical-ra", Namespace = "", IsNullable = false)]
    public partial class SendFileRespopnseInfo
    {

        [System.Xml.Serialization.XmlElement("digests", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Digests[] Digests { get; set; }


        [System.Xml.Serialization.XmlAttribute("archive-id")]
        public string ArchiveId { get; set; }


        [System.Xml.Serialization.XmlAttribute("deposit-date")]
        public string DepositDate { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class Digests
    {
        [System.Xml.Serialization.XmlElement("applicative-metadata-digest", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public DigestInfo ApplicativeMetadataDigest { get; set; }

        [System.Xml.Serialization.XmlElement("data-object-digest", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public DigestInfo DataObjectDigest { get; set; }

        [System.Xml.Serialization.XmlElement("descriptive-metadata-digest", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public DigestInfo DescriptiveMetadataDigest { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DigestInfo
    {
        [System.Xml.Serialization.XmlAttribute("algorithm")]
        public string Algorithm { get; set; }

        [System.Xml.Serialization.XmlText()]
        public string Value { get; set; }
    }
}
