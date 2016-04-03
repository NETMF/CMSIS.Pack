using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    /// <remarks/>
    [Serializable( )]
    [XmlType( AnonymousType=true)]
    public partial class ExampleProjectTypeEnvironment {
    
        private string nameField;
    
        private string loadField;
    
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
        public string load {
            get {
                return loadField;
            }
            set {
                loadField = value;
            }
        }
    }
}