using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class DescriptionType {
    
        private string pnameField;
    
        private string valueField;
    
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