
namespace ApiCdc
{
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot("archive-status", Namespace = "", IsNullable = false)]
    public partial class ArchiveStatusResponseInfo
    {
        [System.Xml.Serialization.XmlArray(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItem("process", typeof(Process), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public Process[] Processes { get; set; }

        [System.Xml.Serialization.XmlAttribute("status")]
        public string Status { get; set; }
    }

}
