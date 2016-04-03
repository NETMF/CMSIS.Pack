using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    public partial class ComponenOrBundleGroup
    {
        [XmlAttribute("Cvendor")]
        public string Vendor { get; set; }

        [XmlAttribute("Cclass")]
        public string Class { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlAttribute( Form = System.Xml.Schema.XmlSchemaForm.Qualified )]
        public string Cversion { get; set; }
    }
}