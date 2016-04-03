using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class DataPatchType {
    
        private DataPatchAccessTypeEnum typeField;
    
        private bool typeFieldSpecified;
    
        private string addressField;
    
        private uint @__dpField;
    
        private bool @__dpFieldSpecified;
    
        private uint @__apField;
    
        private bool @__apFieldSpecified;
    
        private string valueField;
    
        private string maskField;
    
        private string infoField;
    
        private XmlAttribute[] anyAttrField;
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public DataPatchAccessTypeEnum type {
            get {
                return typeField;
            }
            set {
                typeField = value;
            }
        }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool typeSpecified {
            get {
                return typeFieldSpecified;
            }
            set {
                typeFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string address {
            get {
                return addressField;
            }
            set {
                addressField = value;
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
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public uint @__ap {
            get {
                return @__apField;
            }
            set {
                @__apField = value;
            }
        }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool @__apSpecified {
            get {
                return @__apFieldSpecified;
            }
            set {
                @__apFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string value {
            get {
                return valueField;
            }
            set {
                valueField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string mask {
            get {
                return maskField;
            }
            set {
                maskField = value;
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