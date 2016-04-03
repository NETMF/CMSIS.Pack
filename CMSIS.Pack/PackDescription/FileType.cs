using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    /// <remarks/>
    [Serializable( )]
    public partial class FileType {
    
        private string conditionField;
    
        private FileCategoryType categoryField;
    
        private FileAttributeType attrField;
    
        private bool attrFieldSpecified;
    
        private string selectField;
    
        private string nameField;
    
        private string copyField;
    
        private string versionField;
    
        private string srcField;
    
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
        public FileCategoryType category {
            get {
                return categoryField;
            }
            set {
                categoryField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public FileAttributeType attr {
            get {
                return attrField;
            }
            set {
                attrField = value;
            }
        }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool attrSpecified {
            get {
                return attrFieldSpecified;
            }
            set {
                attrFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string select {
            get {
                return selectField;
            }
            set {
                selectField = value;
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
        public string copy {
            get {
                return copyField;
            }
            set {
                copyField = value;
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
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string src {
            get {
                return srcField;
            }
            set {
                srcField = value;
            }
        }
    }
}