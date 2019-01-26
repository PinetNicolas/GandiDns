using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCdc
{
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DescriptiveMetadata
    {
        [System.Xml.Serialization.XmlElement("creator", Namespace = "", IsNullable = true)]
        public string[] Creator { get; set; }

        [System.Xml.Serialization.XmlElement("subject", Namespace = "", IsNullable = true)]
        public string[] Subject { get; set; }

        [System.Xml.Serialization.XmlElement("description", Namespace = "", IsNullable = true)]
        public string[] Description { get; set; }

        [System.Xml.Serialization.XmlElement("publisher", Namespace = "", IsNullable = true)]
        public string[] Publisher { get; set; }

        [System.Xml.Serialization.XmlElement("contributor", Namespace = "", IsNullable = true)]
        public string[] Contributor { get; set; }

        [System.Xml.Serialization.XmlElement("type", Namespace = "", IsNullable = true)]
        public string[] Type { get; set; }

        [System.Xml.Serialization.XmlElement("format", Namespace = "", IsNullable = true)]
        public string[] Format { get; set; }

        [System.Xml.Serialization.XmlElement("identifier", Namespace = "", IsNullable = true)]
        public string[] Identifier { get; set; }

        [System.Xml.Serialization.XmlElement("source", Namespace = "", IsNullable = true)]
        public string[] Source { get; set; }

        [System.Xml.Serialization.XmlElement("language", Namespace = "", IsNullable = true)]
        public string[] Language { get; set; }

        [System.Xml.Serialization.XmlElement("relation", Namespace = "", IsNullable = true)]
        public string[] Relation { get; set; }

        [System.Xml.Serialization.XmlElement("coverage", Namespace = "", IsNullable = true)]
        public string[] Coverage { get; set; }

        [System.Xml.Serialization.XmlElement("rights", Namespace = "", IsNullable = true)]
        public string[] Rights { get; set; }

        [System.Xml.Serialization.XmlElement("date", Namespace = "", IsNullable = true)]
        public string[] Date { get; set; }

        [System.Xml.Serialization.XmlElement("title", Namespace = "", IsNullable = true)]
        public string[] Title { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class IndexApplicativeMetadata
    {
        [System.Xml.Serialization.XmlElement("organisation_id", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string OrganisationId { get; set; }

        [System.Xml.Serialization.XmlElement("worker_name", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string WorkerName { get; set; }

        [System.Xml.Serialization.XmlElement("period_end_date", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PeriodEndDate { get; set; }

        [System.Xml.Serialization.XmlElement("e-vault_id", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string EvaultId { get; set; }

        [System.Xml.Serialization.XmlElement("file_digest", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string FileDigest { get; set; }

        [System.Xml.Serialization.XmlElement("period_start_date", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PeriodStartDate { get; set; }

        [System.Xml.Serialization.XmlElement("organisation_name", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string OrganisationName { get; set; }

        [System.Xml.Serialization.XmlElement("title", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Title { get; set; }

        [System.Xml.Serialization.XmlElement("worker_id", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string WorkerId { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class Process
    {
        [System.Xml.Serialization.XmlAttribute("process-id")]
        public string Processid { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute("status")]
        public string Status { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute("date")]
        public string Date { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class UnitValue
    {
        [System.Xml.Serialization.XmlAttribute("unit")]
        public string Unit { get; set; }

        [System.Xml.Serialization.XmlText()]
        public string Value { get; set; }
    }
}
