using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class DebugConfigType {
    
        private DebugProtocolEnum defaultField;
    
        private bool defaultFieldSpecified;
    
        private uint clockField;
    
        private bool clockFieldSpecified;
    
        private bool swjField;
    
        private bool swjFieldSpecified;
    
        private XmlAttribute[] anyAttrField;
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public DebugProtocolEnum @default {
            get {
                return defaultField;
            }
            set {
                defaultField = value;
            }
        }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool defaultSpecified {
            get {
                return defaultFieldSpecified;
            }
            set {
                defaultFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public uint clock {
            get {
                return clockField;
            }
            set {
                clockField = value;
            }
        }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool clockSpecified {
            get {
                return clockFieldSpecified;
            }
            set {
                clockFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public bool swj {
            get {
                return swjField;
            }
            set {
                swjField = value;
            }
        }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool swjSpecified {
            get {
                return swjFieldSpecified;
            }
            set {
                swjFieldSpecified = value;
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