using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class ApiType {
    
        private string descriptionField;
    
        private FileType[] filesField;
    
        private string cclassField;
    
        private string cgroupField;
    
        private bool exclusiveField;
    
        private string capiversionField;
    
        public ApiType() {
            exclusiveField = true;
        }
    
        /// <remarks/>
        public string description {
            get {
                return descriptionField;
            }
            set {
                descriptionField = value;
            }
        }
    
        /// <remarks/>
        [XmlArrayItem( "file", IsNullable=false)]
        public FileType[] files {
            get {
                return filesField;
            }
            set {
                filesField = value;
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
        [DefaultValue( true)]
        public bool exclusive {
            get {
                return exclusiveField;
            }
            set {
                exclusiveField = value;
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