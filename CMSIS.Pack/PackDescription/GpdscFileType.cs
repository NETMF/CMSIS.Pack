using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public class GpdscFileType {
    
        private string nameField;
    
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
    }
}