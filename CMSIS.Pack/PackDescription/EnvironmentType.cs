using System;
using System.Xml;
using System.Xml.Serialization;
using Sprache;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class EnvironmentType {
    
        private System.Xml.XmlElement[] anyField;
    
        private string nameField;
    
        private XmlAttribute[] anyAttrField;
    
        /// <remarks/>
        [XmlAnyElement( )]
        public System.Xml.XmlElement[] Any {
            get {
                return anyField;
            }
            set {
                anyField = value;
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