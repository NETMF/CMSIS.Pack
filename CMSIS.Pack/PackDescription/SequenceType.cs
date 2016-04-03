using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class SequenceType {
    
        private SequenceBlockType[] blockField;
    
        private SequenceControlType[] controlField;
    
        private string nameField;
    
        private string pnameField;
    
        private bool disableField;
    
        private bool disableFieldSpecified;
    
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
        public string name {
            get {
                return nameField;
            }
            set {
                nameField = value;
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
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public bool disable {
            get {
                return disableField;
            }
            set {
                disableField = value;
            }
        }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool disableSpecified {
            get {
                return disableFieldSpecified;
            }
            set {
                disableFieldSpecified = value;
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