using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public class GeneratorFileType {
    
        private string conditionField;
    
        private string categoryField;
    
        private string nameField;
    
        private string versionField;
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string condition {
            get {
                return conditionField;
            }
            set {
                conditionField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string category {
            get {
                return categoryField;
            }
            set {
                categoryField = value;
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
        public string version {
            get {
                return versionField;
            }
            set {
                versionField = value;
            }
        }
    }
}