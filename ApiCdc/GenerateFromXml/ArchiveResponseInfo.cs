
namespace ApiCdc
{
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot("depositor-info", Namespace = "", IsNullable = false)]
    public partial class Depositorinfo
    {
        [System.Xml.Serialization.XmlElement("depositor-id", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DepositorId { get; set; }
        
        [System.Xml.Serialization.XmlElement("deposit-channel", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DepositChannel { get; set; }

        [System.Xml.Serialization.XmlElement("depositor-ip", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DepositorIp { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot("data-object-format", Namespace = "", IsNullable = false)]
    public partial class DataObjectFormat
    {
        [System.Xml.Serialization.XmlElement("detected", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DataObjectFormatElement Detected { get; set; }

        [System.Xml.Serialization.XmlElement("validated", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DataObjectFormatElement Validated { get; set; }

        [System.Xml.Serialization.XmlAttribute("referential")]
        public string Referential { get; set; }
    }

    
    
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DataObjectFormatElement
    {
        [System.Xml.Serialization.XmlElement("name", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Name { get; set; }

        [System.Xml.Serialization.XmlElement("version",Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Version { get; set; }

        [System.Xml.Serialization.XmlAttribute("puid")]
        public string puid { get; set; }
    }
    
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot("identified-agencies", Namespace = "", IsNullable = false)]
    public partial class IdentifiedAgencies
    {
        [System.Xml.Serialization.XmlElement("agency", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Agency[] Agency { get; set; }
    }

    
    
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class Agency
    {
        [System.Xml.Serialization.XmlElement("name", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Name { get; set; }
        
        [System.Xml.Serialization.XmlElement("identifier", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public AgencyIdentifier Identifier { get; set; }

        [System.Xml.Serialization.XmlAttribute("type")]
        public string Type { get; set; }
    }

    
    
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class AgencyIdentifier
    {
        [System.Xml.Serialization.XmlAttribute("scheme-id")]
        public string SchemeId { get; set; }

        [System.Xml.Serialization.XmlAttribute("scheme-name")]
        public string SchemeName { get; set; }

        [System.Xml.Serialization.XmlAttribute("scheme-agency-id")]
        public string SchemeAgencyId { get; set; }

        [System.Xml.Serialization.XmlAttribute("scheme-agency-name")]
        public string SchemeAgencyName { get; set; }

        [System.Xml.Serialization.XmlText()]
        public string Value { get; set; }
    }

    
    
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot("final-disposition", Namespace = "", IsNullable = false)]
    public partial class FinalDisposition
    {
        [System.Xml.Serialization.XmlAttribute("disposition")]
        public string Disposition { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public partial class Reference
    {
        [System.Xml.Serialization.XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DigestValue { get; set; }

        [System.Xml.Serialization.XmlElement("DigestMethod")]
        public Algorithm DigestMethod { get; set; }

        [System.Xml.Serialization.XmlArray(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItem("Transform", typeof(Algorithm), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public Algorithm[] Transforms { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public string URI { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public string Id { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public string Type { get; set; }
    }

    
    
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public partial class Algorithm
    {   
        [System.Xml.Serialization.XmlAttribute("Algorithm")]
        public string Attribute { get; set; }
    }
    
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot("archive-metadata-extended", Namespace = "", IsNullable = false)]
    public partial class ArchiveResponseInfo
    {
        [System.Xml.Serialization.XmlElement("archive-metadata")]
        public ArchiveMetadata ArchiveMetadata { get; set; }

        [System.Xml.Serialization.XmlElement("smart-app-meta-render")]
        public SmartAppMetaRender SmartAppMetaRender { get; set; }
    }



    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class ArchiveMetadata
    {
        [System.Xml.Serialization.XmlElement("applicative-metadata", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ApplicativeMetadata { get; set; }


        [System.Xml.Serialization.XmlElement("structured-metadata", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public StructuredMetadata structuredmetadata { get; set; }
    }

    
    
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class StructuredMetadata
    {
        [System.Xml.Serialization.XmlElement("administrative-metadata", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AdministrativeMetadata AdministrativeMetadata { get; set; }
        
        [System.Xml.Serialization.XmlElement("descriptive-metadata", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DescriptiveMetadata DescriptiveMetadata { get; set; }

        [System.Xml.Serialization.XmlElement("sealing", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Sealing Sealing { get; set; }

        [System.Xml.Serialization.XmlElement("technical-metadata", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TechnicalMetadata TechnicalMetadata { get; set; }
    }

    
    
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class AdministrativeMetadata
    {
        [System.Xml.Serialization.XmlElement("application-version", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ApplicationVersion { get; set; }
        
        [System.Xml.Serialization.XmlElement("depositor-info")]
        public Depositorinfo Depositorinfo { get; set; }

        [System.Xml.Serialization.XmlElement("digests", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Digests Digests { get; set; }

        [System.Xml.Serialization.XmlElement("protocol-info", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ProtocolInfo ProtocolInfo { get; set; }

        [System.Xml.Serialization.XmlElement("data-object-format")]
        public DataObjectFormat DataObjectFormat { get; set; }

        [System.Xml.Serialization.XmlElement("identified-agencies")]
        public IdentifiedAgencies IdentifiedAgencies { get; set; }

        [System.Xml.Serialization.XmlElement("final-disposition")]
        public FinalDisposition finaldisposition { get; set; }

        [System.Xml.Serialization.XmlAttribute("client-id")]
        public string ClientId { get; set; }

        [System.Xml.Serialization.XmlAttribute("cfe-id")]
        public string CfeId { get; set; }

        [System.Xml.Serialization.XmlAttribute("section-id")]
        public string SectionId { get; set; }

        [System.Xml.Serialization.XmlAttribute("archive-id")]
        public string ArchiveId { get; set; }

        [System.Xml.Serialization.XmlAttribute("deposit-date")]
        public string DepositDate { get; set; }

        [System.Xml.Serialization.XmlAttribute("end-of-life-date")]
        public string EndOfLifeDate { get; set; }

        [System.Xml.Serialization.XmlAttribute("status")]
        public string Status { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class Digests
    {
        [System.Xml.Serialization.XmlElement("applicative-metadata-digest", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public AlgorithmValue ApplicativeMetadataDigest { get; set; }
        
        [System.Xml.Serialization.XmlElement("data-object-digest", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public AlgorithmValue DataObjectDigest { get; set; }

        [System.Xml.Serialization.XmlElement("descriptive-metadata-digest", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public AlgorithmValue DescriptiveMetadataDigest { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class AlgorithmValue
    {
        [System.Xml.Serialization.XmlAttribute("algorithm")]
        public string Algorithm { get; set; }
        
        [System.Xml.Serialization.XmlText()]
        public string Value { get; set; }
    }
    
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class ProtocolInfo
    {
        [System.Xml.Serialization.XmlElement("content-type", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ContentType { get; set; }

        [System.Xml.Serialization.XmlElement("file-name", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Filename { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class Sealing
    {
        [System.Xml.Serialization.XmlElement("sum-up", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SumUp SumUp { get; set; }
        
        [System.Xml.Serialization.XmlElement("Manifest", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Manifest Manifest { get; set; }

        [System.Xml.Serialization.XmlElement("Signature", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Signature Signature { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class SumUp
    {
        [System.Xml.Serialization.XmlElement("application-version", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ApplicationVersion { get; set; }

        [System.Xml.Serialization.XmlElement("chaining", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Chaining Chaining { get; set; }

        [System.Xml.Serialization.XmlElement("depositor-info")]
        public Depositorinfo DepositorInfo { get; set; }

        [System.Xml.Serialization.XmlElement("data-object-format")]
        public DataObjectFormat dataobjectformat { get; set; }

        [System.Xml.Serialization.XmlElement("identified-agencies")]
        public IdentifiedAgencies identifiedagencies { get; set; }

        [System.Xml.Serialization.XmlElement("final-disposition")]
        public FinalDisposition finaldisposition { get; set; }

        [System.Xml.Serialization.XmlArray(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItem("process", typeof(Process), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public Process[] Processes { get; set; }

        [System.Xml.Serialization.XmlElement("cumulated-info", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CumulatedInfo CumulatedInfo { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public string Id { get; set; }

        [System.Xml.Serialization.XmlAttribute("client-id")]
        public string ClientId { get; set; }

        [System.Xml.Serialization.XmlAttribute("cfe-id")]
        public string CfeId { get; set; }

        [System.Xml.Serialization.XmlAttribute("section-id")]
        public string SectionId { get; set; }

        [System.Xml.Serialization.XmlAttribute("archive-id")]
        public string ArchiveId { get; set; }

        [System.Xml.Serialization.XmlAttribute("uri")]
        public string Uri { get; set; }

        [System.Xml.Serialization.XmlAttribute("deposit-date")]
        public string DepositDate { get; set; }

        [System.Xml.Serialization.XmlAttribute("end-of-life-date")]
        public string EndOfLifeDate { get; set; }

        [System.Xml.Serialization.XmlAttribute("status")]
        public string Status { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class Chaining
    {
        [System.Xml.Serialization.XmlElement("archive-id", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ArchiveId { get; set; }

        [System.Xml.Serialization.XmlElement("sealing-digest", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public AlgorithmValue[] SealingDigest { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public string Sequence { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class CumulatedInfo
    {
        [System.Xml.Serialization.XmlElement("archive-number", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ArchiveNumber { get; set; }

        [System.Xml.Serialization.XmlElement("size", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public UnitValue Size { get; set; }

        [System.Xml.Serialization.XmlElement("cumulated-size", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public UnitValue CumulatedSize { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class Manifest
    {
        [System.Xml.Serialization.XmlElement("Reference")]
        public Reference[] Reference { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public string Id { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class Signature
    {
        [System.Xml.Serialization.XmlElement("SignedInfo", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SignedInfo SignedInfo { get; set; }

        [System.Xml.Serialization.XmlElement("SignatureValue", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public SignatureValue SignatureValue { get; set; }

        [System.Xml.Serialization.XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public KeyInfo KeyInfo { get; set; }

        [System.Xml.Serialization.XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SignatureObject Object { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public string Id { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class SignedInfo
    {
        [System.Xml.Serialization.XmlElement("CanonicalizationMethod", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Algorithm CanonicalizationMethod { get; set; }
        
        [System.Xml.Serialization.XmlElement("SignatureMethod", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Algorithm SignatureMethod { get; set; }

        [System.Xml.Serialization.XmlElement("Reference")]
        public Reference[] Reference { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class SignatureValue
    {
        [System.Xml.Serialization.XmlAttribute()]
        public string Id { get; set; }

        [System.Xml.Serialization.XmlText()]
        public string Value { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class KeyInfo
    {
        [System.Xml.Serialization.XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public X509Data X509Data { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class X509Data
    {
        [System.Xml.Serialization.XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string X509Certificate { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class SignatureObject
    {
        [System.Xml.Serialization.XmlElement("QualifyingProperties", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public QualifyingProperties QualifyingProperties { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class QualifyingProperties
    {
        [System.Xml.Serialization.XmlElement("SignedProperties", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SignedProperties SignedProperties { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public string Target { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class SignedProperties
    {
        [System.Xml.Serialization.XmlElement("SignedSignatureProperties", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SignedSignatureProperties SignedSignatureProperties { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public string Id { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class SignedSignatureProperties
    {
        [System.Xml.Serialization.XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SigningTime { get; set; }

        [System.Xml.Serialization.XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SigningCertificate SigningCertificate { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class SigningCertificate
    {
        [System.Xml.Serialization.XmlElement("Cert", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SigningCertificateCert Cert { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class SigningCertificateCert
    {
        [System.Xml.Serialization.XmlElement("CertDigest", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CertDigest CertDigest { get; set; }


        [System.Xml.Serialization.XmlElement("IssuerSerial", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public IssuerSerial IssuerSerial { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class CertDigest
    {
        [System.Xml.Serialization.XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DigestValue { get; set; }

        [System.Xml.Serialization.XmlElement("DigestMethod")]
        public Algorithm DigestMethod { get; set; }
    }

    
    
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class IssuerSerial
    {
        [System.Xml.Serialization.XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string X509IssuerName { get; set; }

        [System.Xml.Serialization.XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string X509SerialNumber { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class TechnicalMetadata
    {
        [System.Xml.Serialization.XmlElement("deposit-end-date", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DepositEndDate { get; set; }

        [System.Xml.Serialization.XmlArrayItem("process", typeof(Process), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public Process[] Processes { get; set; }

        [System.Xml.Serialization.XmlElement("technical-digest", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public AlgorithmValue[] technicaldigest { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class SmartAppMetaRender
    {
        [System.Xml.Serialization.XmlElement("smart-app-meta", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SmartAppMeta[] SmartAppMeta { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class SmartAppMeta
    {
        [System.Xml.Serialization.XmlElement("label",Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Label { get; set; }

        [System.Xml.Serialization.XmlElement("value",Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Value { get; set; }

        [System.Xml.Serialization.XmlAttribute("code")]
        public string Code { get; set; }
    }
}
