using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public class DebugInterface
    {
        /// <remarks/>
        [XmlAttribute( "adapter", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Adapter { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "connector", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Connector { get; set; }
    }
}