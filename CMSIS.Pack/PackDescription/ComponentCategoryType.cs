using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    /// <remarks/>
    [Serializable( )]
    public partial class ComponentCategoryType
    {
    
        private string cvendorField;
    
        private string cbundleField;
    
        private string cclassField;
    
        private string cgroupField;
    
        private string csubField;
    
        private string cvariantField;
    
        private string cversionField;
    
        private string capiversionField;
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Cvendor {
            get {
                return cvendorField;
            }
            set {
                cvendorField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Cbundle {
            get {
                return cbundleField;
            }
            set {
                cbundleField = value;
            }
        }
    
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
        public string Csub {
            get {
                return csubField;
            }
            set {
                csubField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Cvariant {
            get {
                return cvariantField;
            }
            set {
                cvariantField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Cversion {
            get {
                return cversionField;
            }
            set {
                cversionField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Capiversion {
            get {
                return capiversionField;
            }
            set {
                capiversionField = value;
            }
        }
    }
}