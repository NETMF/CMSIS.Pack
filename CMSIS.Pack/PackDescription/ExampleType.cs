using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    /// <remarks/>
    [GeneratedCode( "xsd", "4.6.1055.0")]
    [Serializable( )]
    [DebuggerStepThrough( )]
    [DesignerCategory( "code")]
    public partial class ExampleType {
    
        private string descriptionField;
    
        private BoardReference[] boardField;
    
        private ExampleProjectTypeEnvironment[] projectField;
    
        private ExampleAttributesType attributesField;
    
        private string nameField;
    
        private string folderField;
    
        private string archiveField;
    
        private string docField;
    
        private string versionField;
    
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
        [XmlElement( "board")]
        public BoardReference[] board {
            get {
                return boardField;
            }
            set {
                boardField = value;
            }
        }
    
        /// <remarks/>
        [XmlArrayItem( "environment", IsNullable=false)]
        public ExampleProjectTypeEnvironment[] project {
            get {
                return projectField;
            }
            set {
                projectField = value;
            }
        }
    
        /// <remarks/>
        public ExampleAttributesType attributes {
            get {
                return attributesField;
            }
            set {
                attributesField = value;
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
        public string folder {
            get {
                return folderField;
            }
            set {
                folderField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string archive {
            get {
                return archiveField;
            }
            set {
                archiveField = value;
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