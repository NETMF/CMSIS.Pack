using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class JtagType {
    
        private string tapindexField;
    
        private string idcodeField;
    
        private string targetselField;
    
        private uint irlenField;
    
        private bool irlenFieldSpecified;
    
        private XmlAttribute[] anyAttrField;
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string tapindex {
            get {
                return tapindexField;
            }
            set {
                tapindexField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string idcode {
            get {
                return idcodeField;
            }
            set {
                idcodeField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string targetsel {
            get {
                return targetselField;
            }
            set {
                targetselField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public uint irlen {
            get {
                return irlenField;
            }
            set {
                irlenField = value;
            }
        }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool irlenSpecified {
            get {
                return irlenFieldSpecified;
            }
            set {
                irlenFieldSpecified = value;
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