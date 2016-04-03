using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class TraceType {
    
        private SerialWireType[] serialwireField;
    
        private TracePortType[] traceportField;
    
        private TraceBufferType[] tracebufferField;
    
        private string pnameField;
    
        private XmlAttribute[] anyAttrField;
    
        /// <remarks/>
        [XmlElement( "serialwire")]
        public SerialWireType[] serialwire {
            get {
                return serialwireField;
            }
            set {
                serialwireField = value;
            }
        }
    
        /// <remarks/>
        [XmlElement( "traceport")]
        public TracePortType[] traceport {
            get {
                return traceportField;
            }
            set {
                traceportField = value;
            }
        }
    
        /// <remarks/>
        [XmlElement( "tracebuffer")]
        public TraceBufferType[] tracebuffer {
            get {
                return tracebufferField;
            }
            set {
                tracebufferField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Pname {
            get {
                return pnameField;
            }
            set {
                pnameField = value;
            }
        }
    
        /// <remarks/>
        [XmlAnyAttribute( )]
        public XmlAttribute[ ] AnyAttr {
            get {
                return anyAttrField;
            }
            set {
                anyAttrField = value;
            }
        }
    }
}