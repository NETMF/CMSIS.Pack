using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    [XmlType( AnonymousType = true )]
    public class Bundle 
        : ComponenOrBundleGroup
    {
        /// <remarks/>
        [XmlElement("doc")]
        public string Document { get; set; }

        /// <remarks/>
        [XmlElement( "component" )]
        public Component[ ] Component { get; set; }

        /// <remarks/>
        [XmlAttribute( "Cbundle", Form = System.Xml.Schema.XmlSchemaForm.Qualified )]
        public string Name { get; set; }

        /// <remarks/>
        [XmlAttribute( "generator", Form = System.Xml.Schema.XmlSchemaForm.Qualified )]
        public string Generator { get; set; }
    }
}