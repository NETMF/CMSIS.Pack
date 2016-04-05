using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public class DebugPort
    {
        /// <remarks/>
        [XmlElement("jtag")]
        public JtagType JTAG { get; set; }

        /// <remarks/>
        [XmlElement("swd")]
        public SwdType SWD { get; set; }

        /// <remarks/>
        [XmlAttribute( "__dp", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public uint DebugPortId { get; set; }

        /// <remarks/>
        // SPECBUG: XSD.EXE generated this implying the schema marked the id as optional, yet the official docs indicate it is required...
        [XmlIgnore( )]
        public bool DebugPortIdSpecified { get; set; }

        // SPECBUG: CMSIS-Pack 4.5.0 documentation includes a Cjtag child element but the official PACK.XSD does not have any such element or type

        /// <remarks/>
        [XmlAnyAttribute( )]
        public XmlAttribute[ ] AnyAttr { get; set; }
    }
}