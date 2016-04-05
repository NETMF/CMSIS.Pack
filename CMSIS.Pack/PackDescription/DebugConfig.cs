using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public class DebugConfig
    {
        /// <remarks/>
        [XmlAttribute( "default", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        [DefaultValue( DebugProtocolEnum.swd )]
        public DebugProtocolEnum DefaultProtocol { get; set; } = DebugProtocolEnum.swd;

        /// <remarks/>
        [XmlIgnore( )]
        public bool DefaultProtocolSpecified { get; set; }

        /// <remarks/>
        [XmlAttribute( "clock", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        [DefaultValue( 10000000 )]
        public uint Clock { get; set; } = 10000000;

        /// <remarks/>
        [ XmlIgnore( )]
        public bool ClockSpecified { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "swj", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        [DefaultValue(true)]
        public bool SWJ { get; set; } = true;
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool SWJSpecified { get; set; }
    
        /// <remarks/>
        [XmlAnyAttribute( )]
        public XmlAttribute[ ] AnyAttr { get; set; }
    }
}