using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public class SequenceControlType {
    
        private SequenceBlockType[] blockField;
    
        private SequenceControlType[] controlField;
    
        private string ifField;
    
        private string whileField;
    
        private uint timeoutField;
    
        private bool timeoutFieldSpecified;
    
        private string infoField;
    
        private XmlAttribute[] anyAttrField;
    
        /// <remarks/>
        [XmlElement( "block")]
        public SequenceBlockType[] block {
            get {
                return blockField;
            }
            set {
                blockField = value;
            }
        }
    
        /// <remarks/>
        [XmlElement( "control")]
        public SequenceControlType[] control {
            get {
                return controlField;
            }
            set {
                controlField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string @if {
            get {
                return ifField;
            }
            set {
                ifField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string @while {
            get {
                return whileField;
            }
            set {
                whileField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public uint timeout {
            get {
                return timeoutField;
            }
            set {
                timeoutField = value;
            }
        }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool timeoutSpecified {
            get {
                return timeoutFieldSpecified;
            }
            set {
                timeoutFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string info {
            get {
                return infoField;
            }
            set {
                infoField = value;
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