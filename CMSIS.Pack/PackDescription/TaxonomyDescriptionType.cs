using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class TaxonomyDescriptionType {
    
        private string cclassField;
    
        private string cgroupField;
    
        private string docField;
    
        private string generatorField;
    
        private string valueField;
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Cclass {
            get {
                return cclassField;
            }
            set {
                cclassField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Cgroup {
            get {
                return cgroupField;
            }
            set {
                cgroupField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string doc {
            get {
                return docField;
            }
            set {
                docField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string generator {
            get {
                return generatorField;
            }
            set {
                generatorField = value;
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