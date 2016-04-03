using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class DebugPortType {
    
        private JtagType jtagField;
    
        private SwdType swdField;
    
        private uint @__dpField;
    
        private bool @__dpFieldSpecified;
    
        private XmlAttribute[] anyAttrField;
    
        /// <remarks/>
        public JtagType jtag {
            get {
                return jtagField;
            }
            set {
                jtagField = value;
            }
        }
    
        /// <remarks/>
        public SwdType swd {
            get {
                return swdField;
            }
            set {
                swdField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public uint @__dp {
            get {
                return @__dpField;
            }
            set {
                @__dpField = value;
            }
        }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool @__dpSpecified {
            get {
                return @__dpFieldSpecified;
            }
            set {
                @__dpFieldSpecified = value;
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