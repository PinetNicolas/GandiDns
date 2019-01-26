
namespace ApiCdc
{
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot("cfes",Namespace = "", IsNullable = false)]
    public partial class EvaultListResponseInfo
    {
        [System.Xml.Serialization.XmlElement("cfe", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public Cfe[] Items { get; set; }
    }

    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class Cfe
    {
        [System.Xml.Serialization.XmlAttribute("id")]
        public string Id { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value { get; set; }
    }

}
