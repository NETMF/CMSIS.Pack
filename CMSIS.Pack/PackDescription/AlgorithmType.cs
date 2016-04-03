using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class AlgorithmType {
    
        private string pnameField;
    
        private string nameField;
    
        private string startField;
    
        private string sizeField;
    
        private string rAMstartField;
    
        private string rAMsizeField;
    
        private bool defaultField;
    
        public AlgorithmType() {
            defaultField = false;
        }
    
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
        public string start {
            get {
                return startField;
            }
            set {
                startField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string size {
            get {
                return sizeField;
            }
            set {
                sizeField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string RAMstart {
            get {
                return rAMstartField;
            }
            set {
                rAMstartField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string RAMsize {
            get {
                return rAMsizeField;
            }
            set {
                rAMsizeField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        [DefaultValue( false)]
        public bool @default {
            get {
                return defaultField;
            }
            set {
                defaultField = value;
            }
        }
    }
}