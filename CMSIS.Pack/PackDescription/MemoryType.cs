using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class MemoryType {
    
        private string pnameField;
    
        private MemoryIDTypeEnum idField;
    
        private string startField;
    
        private string sizeField;
    
        private bool initField;
    
        private bool defaultField;
    
        private bool startupField;
    
        public MemoryType() {
            initField = false;
            defaultField = false;
            startupField = false;
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
        public MemoryIDTypeEnum id {
            get {
                return idField;
            }
            set {
                idField = value;
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
        [DefaultValue( false)]
        public bool init {
            get {
                return initField;
            }
            set {
                initField = value;
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
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        [DefaultValue( false)]
        public bool startup {
            get {
                return startupField;
            }
            set {
                startupField = value;
            }
        }
    }
}