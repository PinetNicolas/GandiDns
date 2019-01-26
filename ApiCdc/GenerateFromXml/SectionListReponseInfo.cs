
namespace ApiCdc.GenerateFromXml
{
    




    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot("sections", Namespace = "", IsNullable = false)]
    public partial class SectionListReponseInfo
    {
        [System.Xml.Serialization.XmlElement("section", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Section[] Sections { get; set; }


        [System.Xml.Serialization.XmlAttribute("cfe-id")]
        public string CfeId { get; set; }


        [System.Xml.Serialization.XmlAttribute("cfe-name")]
        public string CfeName { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class Section
    {
        [System.Xml.Serialization.XmlElement("section-info", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Sectioninfo SectionInfo { get; set; }
        
        [System.Xml.Serialization.XmlElement("ra-mailing", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RaMailing RaMailing { get; set; }

        [System.Xml.Serialization.XmlElement("user-interface", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public UserInterface UserInterface { get; set; }

        [System.Xml.Serialization.XmlElement("sealing", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Sealing Sealing { get; set; }

        [System.Xml.Serialization.XmlElement("archive-metrics", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ArchiveMetrics ArchiveMetrics { get; set; }

        [System.Xml.Serialization.XmlArray("archive-formats", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItem("archive-format", typeof(ArchiveFormat), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public ArchiveFormat[] ArchiveFormats { get; set; }

        [System.Xml.Serialization.XmlElement("archive-end-of-life", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ArchiveEndOfLife ArchiveEndOfLife { get; set; }

        [System.Xml.Serialization.XmlArray("archive-deposit-filter", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItem("filter", typeof(ArchiveDepositFilterElement), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public ArchiveDepositFilterElement[] ArchiveDepositFilter { get; set; }

        [System.Xml.Serialization.XmlArray("archive-format-analysis", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItem("data-object", typeof(DataObject), IsNullable = false)]
        public DataObject[] ArchiveFormatAnalysis { get; set; }

        [System.Xml.Serialization.XmlElement("archive-signature-validation", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public sectionsSectionArchivesignaturevalidation[] ArchiveSignatureValidation { get; set; }

        [System.Xml.Serialization.XmlAttribute("id")]
        public string Id { get; set; }

        [System.Xml.Serialization.XmlAttribute("cfe-id")]
        public string CfeId { get; set; }

        [System.Xml.Serialization.XmlAttribute("ds-subject-parsing")]
        public string DsSubjectParsing { get; set; }
    }

    

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class Sectioninfo
    {
        [System.Xml.Serialization.XmlElement("name",Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Name { get; set; }

        [System.Xml.Serialization.XmlElement("creation-date", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CreationDate { get; set; }

        
        [System.Xml.Serialization.XmlElement("storage-duration", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public UnitValue StorageDuration { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class RaMailing
    {
        [System.Xml.Serialization.XmlElement("tech-ra-mailing", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RaMailingElement TechRaMailing { get; set; }
        
        [System.Xml.Serialization.XmlElement("func-ra-mailing", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RaMailingElement FuncRaMailing { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class RaMailingElement
    {   
        [System.Xml.Serialization.XmlAttribute("enabled")]
        public string Enabled { get; set; }
    }


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class UserInterface
    {
        [System.Xml.Serialization.XmlElement("search", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public UserInterfaceSearch Search { get; set; }

        
        [System.Xml.Serialization.XmlElement("retrieval", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public UserInterfaceRetrieval Retrieval { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class UserInterfaceSearch
    {
        [System.Xml.Serialization.XmlAttribute("allow-leading-wildcard")]
        public string AllowLeadingWildcard { get; set; }
        
        [System.Xml.Serialization.XmlAttribute("display-deposit-date")]
        public string displaydepositdate { get; set; }
    }

    

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class UserInterfaceRetrieval
    {
        [System.Xml.Serialization.XmlAttribute("explore-data-object")]
        public string ExploreDataObject { get; set; }

        [System.Xml.Serialization.XmlAttribute("app-metadata-simple-view")]
        public string AppMetadataSimpleView { get; set; }

        [System.Xml.Serialization.XmlAttribute("open-archival-metadata")]
        public string OpenArchivalMetadata { get; set; }

        [System.Xml.Serialization.XmlAttribute("open-dublincore-metadata")]
        public string OpenDublincoreMetadata { get; set; }

        [System.Xml.Serialization.XmlAttribute("refuse-extended-metadata")]
        public string RefuseExtendedMetadata { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class Sealing
    {
        [System.Xml.Serialization.XmlAttribute("signature")]
        public string signature { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class ArchiveMetrics
    {
        
        [System.Xml.Serialization.XmlElement("minimum-size", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public UnitValue Minimumsize { get; set; }

        [System.Xml.Serialization.XmlElement("maximum-size", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public UnitValue maximumsize { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class ArchiveFormat
    {   
        [System.Xml.Serialization.XmlElement("data-object")]
        public DataObject DataObject { get; set; }

        [System.Xml.Serialization.XmlElement("dublin-core", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DublinCore DublinCore { get; set; }

        [System.Xml.Serialization.XmlElement("app-metadata", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AppMetadata AppMetadata { get; set; }

        [System.Xml.Serialization.XmlAttribute("section-id")]
        public string Sectionid { get; set; }

        [System.Xml.Serialization.XmlAttribute("editing")]
        public string Editing { get; set; }

        [System.Xml.Serialization.XmlAttribute("valid-since")]
        public string ValidSince { get; set; }
    }

    

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DublinCore
    {
        [System.Xml.Serialization.XmlElement("title", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DublinCoreElement title { get; set; }

        [System.Xml.Serialization.XmlElement("creator", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DublinCoreElement Creator { get; set; }

        [System.Xml.Serialization.XmlElement("subject", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DublinCoreElement Subject { get; set; }

        [System.Xml.Serialization.XmlElement("description", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DublinCoreElement Description { get; set; }

        [System.Xml.Serialization.XmlElement("publisher", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DublinCoreElement Publisher { get; set; }

        [System.Xml.Serialization.XmlElement("contributor", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DublinCoreElement Contributor { get; set; }

        [System.Xml.Serialization.XmlElement("type", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DublinCoreElement Type { get; set; }

        [System.Xml.Serialization.XmlElement("format", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DublinCoreElement Format { get; set; }

        [System.Xml.Serialization.XmlElement("identifier", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DublinCoreElement Identifier { get; set; }

        [System.Xml.Serialization.XmlElement("source", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DublinCoreElement Source { get; set; }

        [System.Xml.Serialization.XmlElement("language", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DublinCoreElement Language { get; set; }

        [System.Xml.Serialization.XmlElement("relation", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DublinCoreElement Relation { get; set; }

        [System.Xml.Serialization.XmlElement("coverage", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DublinCoreElement Coverage { get; set; }

        [System.Xml.Serialization.XmlElement("rights", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DublinCoreElement Rights { get; set; }

        [System.Xml.Serialization.XmlElement("date", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DublinCoreElement Date { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DublinCoreElement
    {
        [System.Xml.Serialization.XmlElement("name",Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Name { get; set; }

        [System.Xml.Serialization.XmlElement("form-display", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string FormDisplay { get; set; }

        [System.Xml.Serialization.XmlElement("search-results")]
        public SearchResults SearchResults { get; set; }

        [System.Xml.Serialization.XmlAttribute("presence-mgmt")]
        public string PresenceMgmt { get; set; }
    }


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class AppMetadata
    {
        [System.Xml.Serialization.XmlElement("scheme", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Scheme { get; set; }
        
        [System.Xml.Serialization.XmlArray("indexed-fields", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItem("indexed-field", typeof(AppMetadataElement), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public AppMetadataElement[] indexedfields { get; set; }

        [System.Xml.Serialization.XmlAttribute("presence")]
        public string Presence { get; set; }
    }

    

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class AppMetadataElement
    {
        [System.Xml.Serialization.XmlElement("name",Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Name { get; set; }

        [System.Xml.Serialization.XmlElement("xpath-expression", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string XpathExpression { get; set; }

        [System.Xml.Serialization.XmlElement("form-display", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string FormDisplay { get; set; }

        [System.Xml.Serialization.XmlElement("search-results")]
        public SearchResults SearchResults { get; set; }

        [System.Xml.Serialization.XmlAttribute("id")]
        public string Id { get; set; }

        [System.Xml.Serialization.XmlAttribute("type")]
        public string Type { get; set; }

        [System.Xml.Serialization.XmlAttribute("presence-mgmt")]
        public string PresenceMgmt { get; set; }

        [System.Xml.Serialization.XmlAttribute("occurrence-mgmt")]
        public string OccurrenceMgmt { get; set; }

        [System.Xml.Serialization.XmlAttribute("status-mgmt")]
        public string StatusMgmt { get; set; }

        [System.Xml.Serialization.XmlAttribute("format")]
        public string Format { get; set; }
    }

    

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class ArchiveEndOfLife
    {
        [System.Xml.Serialization.XmlElement("reminders-number", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string RemindersNumber { get; set; }
        
        [System.Xml.Serialization.XmlElement("deadlines", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ArchiveEndOfLifeDeadlines Deadlines { get; set; }


        [System.Xml.Serialization.XmlElement("warning-time", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public UnitValue WarningTime { get; set; }

        [System.Xml.Serialization.XmlElement("response-time", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public UnitValue ResponseTime { get; set; }

        [System.Xml.Serialization.XmlElement("final-disposition", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ArchiveEndOfLifeFinalDisposition FinalDisposition { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class ArchiveEndOfLifeDeadlines
    {
        [System.Xml.Serialization.XmlElement("month",Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Month { get; set; }

        [System.Xml.Serialization.XmlAttribute("day")]
        public string Day { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class ArchiveEndOfLifeFinalDisposition
    {
        [System.Xml.Serialization.XmlAttribute("disposition")]
        public string Disposition { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class ArchiveDepositFilterElement
    {
        [System.Xml.Serialization.XmlAttribute("target")]
        public string Target { get; set; }

        [System.Xml.Serialization.XmlAttribute("level")]
        public string Level { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class sectionsSectionArchivesignaturevalidation
    {
        [System.Xml.Serialization.XmlAttribute("activated")]
        public string Activated { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot("data-object", Namespace = "", IsNullable = false)]
    public partial class DataObject
    {
        [System.Xml.Serialization.XmlAttribute("presence")]
        public string Presence { get; set; }

        [System.Xml.Serialization.XmlAttribute("identification")]
        public string Identification { get; set; }

        [System.Xml.Serialization.XmlAttribute("validation")]
        public string Validation { get; set; }
    }


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot("search-results", Namespace = "", IsNullable = false)]
    public partial class SearchResults
    {
        [System.Xml.Serialization.XmlAttribute("visibility")]
        public string Visibility { get; set; }
    }
}
