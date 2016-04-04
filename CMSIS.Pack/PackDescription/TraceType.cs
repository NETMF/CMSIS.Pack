using System;
using System.Xml;
using System.Xml.Serialization;
using Sprache;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class TraceType {
    
        private SerialWireType[] serialwireField;
    
        private TracePortType[] traceportField;
    
        private TraceBufferType[] tracebufferField;
    
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
        [XmlAttribute( "Pname", Form = System.Xml.Schema.XmlSchemaForm.Qualified )]
        public string ProcessorName
        {
            get { return ProcessorName_; }
            set { ProcessorName_ = Parsers.RestrictedString.Parse( value ); }
        }
        private string ProcessorName_;

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