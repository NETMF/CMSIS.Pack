using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    [XmlType( AnonymousType=true)]
    public partial class BoardTypeImage {
    
        private string smallField;
    
        private string largeField;
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string small {
            get {
                return smallField;
            }
            set {
                smallField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string large {
            get {
                return largeField;
            }
            set {
                largeField = value;
            }
        }
    }
}