using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public class SequenceBlockType {
    
        private bool atomicField;
    
        private bool atomicFieldSpecified;
    
        private string infoField;
    
        private XmlAttribute[] anyAttrField;
    
        private string valueField;
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public bool atomic {
            get {
                return atomicField;
            }
            set {
                atomicField = value;
            }
        }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool atomicSpecified {
            get {
                return atomicFieldSpecified;
            }
            set {
                atomicFieldSpecified = value;
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
    
        /// <remarks/>
        [XmlText( )]
        public string Value {
            get {
                return valueField;
            }
            set {
                valueField = value;
            }
        }
    }
}